using DbContextReflectionType.Models;
using DbContextReflectionType.Services.Abstracts;

namespace DbContextReflectionType.Services.Helpers
{
    public interface IOperationService
    {
        IConfigModel Deserialize(ConfigDto rawConfig);
    }
}