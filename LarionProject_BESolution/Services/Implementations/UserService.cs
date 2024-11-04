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
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
