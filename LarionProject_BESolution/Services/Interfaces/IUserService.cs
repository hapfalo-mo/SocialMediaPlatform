using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<User> createUser(UserDTO userDTO);
        Task<ActionResult<UserValidDTO>> loginUser(string username, string password);
        Task<ActionResult<IEnumerable<UserValidDTO>>> getAllUser(int userId);
        Task<ActionResult<User>> getUserByUserId(int userId);
    }
}
