

using DbContextReflectionType.Models.Abstracts;

namespace DbContextReflectionType.Models
{
    public class EntityOne : IConfiguration
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string ConfigTypeName { get; set; }
    }
}