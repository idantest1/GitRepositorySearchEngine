namespace GitRepositoryAPI.Models
{
    public class GitRepositoriesSearchResponse
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
    }
}
