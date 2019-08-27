using DbContextReflectionType.Models.Abstracts;

namespace DbContextReflectionType.Models
{
    public class EntityTwo : IConfiguration
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ConfigTypeName { get; set; }
    }
}