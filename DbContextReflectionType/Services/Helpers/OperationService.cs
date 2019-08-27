using System;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;

namespace DbContextReflectionType.Services.Helpers
{
    public class OperationService : IOperationService
    {
        private readonly DatabaseDbContext _database;
        private object configObject;
        private dynamic _repository;

        public OperationService(DatabaseDbContext context)
        {
            _database = context;
        }

        public OperationService Deserialize(ConfigDto rawConfig)
        {
            configObject = CastConfig.Return(rawConfig);

            return this;
        }
        
        public OperationService ActivateRepository()
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