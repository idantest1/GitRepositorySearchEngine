using GitRepositoryAPI.Models;
using GitRepositoryAPI.Repositories;
using GitRepositoryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GitRepositoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private readonly UserRepository _userRepository;

        public AuthController(IUserService userService, UserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var user = _userRepository.GetUser(model.UserName, model.Password);
                if (user == null)
                    return BadRequest(new { message = "UserName or password is incorrect" });
                var response = _userService.Authenticate(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(AuthenticateRequest model)
        {
            try
            {
                var response = _userRepository.CreateUser(model.UserName, model.Password);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
