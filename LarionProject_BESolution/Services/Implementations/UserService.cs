using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        /*---------Configration Site---------*/
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserService(LarionDatabaseContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper)
        {
            _configuration = configuration;
        }

        /*---------Code Site---------*/
        public async Task<User> createUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                // Check duplicate Username 
                var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDTO.Username);
                if (checkUser != null)
                {
                    throw new Exception("Tên tài khoản đã tồn tại");
                }
                // Check user password
                if (userDTO.PasswordHash != userDTO.re_password_hash)
                {
                    throw new Exception("Mật khẩu không trùng khớp");
                }
                user.PasswordHash = hassPassWord(userDTO.PasswordHash);
                user.CreatedAt = DateTime.UtcNow;
                user.AvatarUrl = "https://i.ibb.co/r7Zr6gg/avatar.png";
                user.Status = 1;
                user.Role = 1;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*--------- Login ----------*/
        public async Task<ActionResult<UserValidDTO>> loginUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || username.Equals("") || password.Equals(""))
                {
                    throw new Exception("Tên tài khoản hoặc mật khẩu không được để trống");
                }
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user == null)
                {
                    throw new Exception("Không tìm thấy người dùng");
                }
                else if (user.Status == 0)
                {
                    throw new Exception("Hiện tại người dùng đang bị khóa tài khoản");
                }
                else if (!verifyPassword(password, user.PasswordHash))
                {
                    throw new Exception("Mật khẩu hiện không đúng");
                }
                return await generateToken(user.UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*--------- Get All Users-----*/
        public async Task<ActionResult<IEnumerable<UserValidDTO>>> getAllUser(int userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var userFavorites = await _context.UserFavorites.Where(uf => uf.UserId == userId).ToListAsync();
                var uniqueUserId = new HashSet<int>();
                var users = await _context.Users
                    .Where(u => u.UserId != userId && u.Role != 0 && u.Status == 1).ToListAsync();
                var result = new List<UserValidDTO>();
                foreach (var userFavorite in userFavorites)
                {
                    var listUserFavorite = await _context.UserFavorites.Where(uf => uf.FavoriteId == userFavorite.FavoriteId && uf.UserId != userId).ToListAsync();
                    foreach (var item in listUserFavorite)
                    {
                        var userFavoriteId = item.UserId;
                        if (!uniqueUserId.Contains(userFavoriteId))
                        {
                            var userFavoritePerson = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userFavoriteId);
                            if (userFavoritePerson != null)
                            {
                                var userValidDTO = _mapper.Map<UserValidDTO>(userFavoritePerson);
                                result.Add(userValidDTO);
                                uniqueUserId.Add(userFavoriteId);
                            }
                        }
                    }
                }
                var random = new Random();
                var randomUsers = result.OrderBy(x => random.Next()).Take(6).ToList();
                return randomUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get User By UserId
        public async Task<ActionResult<UserResponseDTO>> getUserByUserId(int userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
                userResponseDTO.FollowedCount = await _context.Follows.CountAsync(f => f.FollowedUserId == userId);
                userResponseDTO.FollowingCount = await _context.Follows.CountAsync(f => f.FollowingUserId == userId);
                userResponseDTO.PostCount = await _context.Posts.CountAsync(p => p.UserId == userId);
                return userResponseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Check User Create Favorite 
        public async Task<bool> checkUserHaveFavorite (int userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    throw new Exception("Không tìm thấy người dùng");
                } 
                var favorite = await _context.UserFavorites.FirstOrDefaultAsync(u => u.UserId == userId);
                if (favorite == null)
                {
                    return false;
                }
                return true;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*---------Internal Site---------*/
        // Hash Password
        private String hassPassWord(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                // Hash password
                byte[] passwordbytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha512.ComputeHash(passwordbytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();

            }
        }

        // Verify password_hash 
        private bool verifyPassword(string password, string passwordhash)
        {
            string hashPassword = hassPassWord(password);
            return hashPassword.Equals(passwordhash, StringComparison.OrdinalIgnoreCase);
        }

        // Generate User Token
        private async Task<UserValidDTO> generateToken(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var key = Encoding.UTF8.GetBytes(_configuration["JWtSettings:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim("UsereId", user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            UserValidDTO userValidDTO = new UserValidDTO
            {
                accessToken = accessToken,
                userId = user.UserId,
                role = user.Role
            };
            return userValidDTO;
        }
    }
}
