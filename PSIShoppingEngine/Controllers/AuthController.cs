using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Username = request.Username}, request.Password, request.Email
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.Username, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            var serviceResponse = await _authRepo.DeleteUser();

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRegisterDto newUser)
        {
            var serviceResponse = await _authRepo.UpdateUser(newUser);

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

    }
}
