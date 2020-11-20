using PSIShoppingEngine.DTOs.User;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UserLoginDto newUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser();
        Task<bool> UserExists(string username);
    }
}
