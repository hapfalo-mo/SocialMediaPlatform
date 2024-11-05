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

namespace Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        /*---------Configration Site---------*/
        private readonly IUserService _userService;
        public UserService( LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /*---------Code Site---------*/
        public async Task<User> createUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.PasswordHash = hassPassWord(userDTO.password_hash);
                user.PhoneNumber = userDTO.phone_number;
                user.Status = 1; // Create New Account always Active
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
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
                foreach(byte b in hashBytes)
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
    }
}
