namespace NightSkyApp.Data
{
    public class PlanetService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlanetService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Planet>> GetPlanetsAsync()
        {
            var client = _httpClientFactory.CreateClient("PlanetsClient");
            var response = await client.GetAsync("api/planets");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<Planet>>();
            if (content is not null)
                return content.ToList();
            return null;
        }

        public async Task<Planet> GetPlanetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("PlanetClient");
            var response = await client.GetAsync($"api/planets/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<Planet>();
            if (content is not null)
                return content;
            return null;
        }

        public async Task<Planet> CreatePlanetAsync(Planet planet)
        {
            var client = _httpClientFactory.CreateClient("PlanetClient");
            var response = await client.PostAsJsonAsync("api/planets", planet);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<Planet>();
            if (content is not null)
                return content;
            return null;
        }

    }
}
