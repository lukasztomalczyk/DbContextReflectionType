using System;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using DbContextReflectionType.Services.Abstracts;

namespace DbContextReflectionType.Services.Helpers
{
    public class OperationService : IOperationService, IConfigModel, IActiveRepository
    {
        private readonly DatabaseDbContext _database;
        private IConfiguration configObject;
        private dynamic _repository;

        public OperationService(DatabaseDbContext context)
        {
            _database = context;
        }

        public IConfigModel Deserialize(ConfigDto rawConfig)
        {
            configObject = CastConfig.Return(rawConfig) as IConfiguration;
            return this;
        }
        
        public IActiveRepository ActivateRepository()
        {
            Type generic = typeof(OperationRepository<>);
            Type constructed = generic.MakeGenericType(configObject.GetType());
            
            _repository = Activator.CreateInstance(constructed, _database);

            return this;
        }

        public void SaveConfig()
        {
            _repository.Save(configObject as IConfiguration);
        }
    }
}