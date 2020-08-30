using GitRepositoryAPI.Entities;
using GitRepositoryAPI.Helpers;
using GitRepositoryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GitRepositoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        FavoritesUsersRepository _favoritesUsersRepository;
        public UserController(FavoritesUsersRepository favoritesUsersRepository)
        {
            _favoritesUsersRepository = favoritesUsersRepository;
        }

        [Authorize]
        [HttpGet("Favorites")]
        public IActionResult GetFavorites()
        {
            try
            {
                var userId = (int)HttpContext.Items["UserId"];
                return Ok(_favoritesUsersRepository.GetFavorites(userId));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }


        [Authorize]
        [HttpPost("Favorites")]
        public IActionResult AddFavorites(Models.AddFavoritesRequest AddFavoritesRequest)
        {
            try
            {
                var userId = (int)HttpContext.Items["UserId"];
                _favoritesUsersRepository.AddFavorites(userId, AddFavoritesRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
