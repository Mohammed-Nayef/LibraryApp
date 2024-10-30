using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryApp.API.HttpClients
{
    public class StackOverflowClient
    {
        private  string url = "";
        private readonly static HttpClient _httpClient = new HttpClient(new SocketsHttpHandler()
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(1)
        });

        public StackOverflowClient()
        {
            url = "http://api.stackexchange.com";
            _httpClient.BaseAddress = new Uri(url);
        }
        public async Task<Questions?> GetQuestions(string userAgent)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

            return await _httpClient.GetFromJsonAsync<Questions>("/2.3/search/advanced?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");
        }
    }
}
