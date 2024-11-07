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
                if (userDTO.password_hash != userDTO.re_password_hash)
                {
                    throw new Exception("Mật khẩu không trùng khớp");
                }
                user.PasswordHash = hassPassWord(userDTO.password_hash);
                user.PhoneNumber = userDTO.phone_number;
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
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                if (!verifyPassword(password, user.PasswordHash))
                {
                    throw new Exception("Password is incorrect");
                }
                return await generateToken(user.UserId);
            }
            catch (Exception ex)
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
