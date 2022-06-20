namespace NightSkyApp.Data
{
    public class GalaxyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalaxyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<List<Galaxy>> GetGalaxiesAsync()
        {
            var client = _httpClientFactory.CreateClient("GalaxiesClient");
            var response = await client.GetAsync("api/galaxies");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<Galaxy>>();
            if(content is not null)
                return content.ToList();
            return null;
        }

        public async Task<Galaxy> GetGalaxyAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("galaxyClient");
            var response = await client.GetAsync($"api/galaxies/{id}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadFromJsonAsync<Galaxy>().Result;
            if (content is not null)
                return content;
            return null;
        }

        public async Task<Galaxy> CreateGalaxyAsync(Galaxy galaxy)
        {
            var client = _httpClientFactory.CreateClient("galaxyClient");
            var response = await client.PostAsJsonAsync("api/galaxies", galaxy);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadFromJsonAsync<Galaxy>().Result;
            if (content is not null)
                return content;
            return null;
        }
    }
}
