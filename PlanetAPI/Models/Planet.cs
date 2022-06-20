namespace PlanetAPI.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasLife { get; set; }
        public int DistanceFromSun { get; set; }
    }
}
