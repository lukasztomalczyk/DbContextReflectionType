using DbContextReflectionType.Models;

namespace DbContextReflectionType.Services.Helpers
{
    public interface IOperationService
    {
        OperationService Deserialize(ConfigDto rawConfig);
        OperationService ActivateRepository();
        void SaveConfig();
    }
}