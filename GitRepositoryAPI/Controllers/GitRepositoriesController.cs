using GitRepositoryAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GitRepositoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitRepositoriesController : ControllerBase
    {
        GitClient _gitClient;
        public GitRepositoriesController(GitClient gitClient)
        {
            _gitClient = gitClient;
        }

        [Authorize]
        [HttpGet("Search/{searchTerm}")]
        public IActionResult Search(string searchTerm)
        {
            try
            {
                return Ok(_gitClient.GetRepositories(searchTerm));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
