using GitRepositoryAPI.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace GitRepositoryAPI.Helpers
{
    public class GitClient
    {
        RestClient _client = null;
        public GitClient(IOptions<AppSettings> appSettings)
        {
            _client = new RestClient(appSettings.Value.GitApiUrl);
        }

        public GitRepositoriesSearchResponse GetRepositories(string searchTerm)
        {
            var request = new RestRequest($"search/repositories?q={searchTerm}");
            var response = _client.Get(request);
            if (response.IsSuccessful)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GitRepositoriesSearchResponse>(response.Content);
            }
            return null;
        }


    }
}
