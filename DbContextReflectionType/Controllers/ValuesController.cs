using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using DbContextReflectionType.Services;
using DbContextReflectionType.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DbContextReflectionType.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _provider;

        public ValuesController(IServiceProvider provider)
        {
            _provider = provider;
        }
        [HttpPost]
        public IActionResult Get([FromBody] ConfigDto config)
        {
            var result = CastConfig.Return(config);
            
            Type generic = typeof(OperationService<>);
            Type constructed = generic.MakeGenericType(result.GetType());

            var dbContext = _provider.GetService<DatabaseDbContext>();
            
            dynamic service = Activator.CreateInstance(constructed, dbContext);
            service.Save(result as IConfiguration);
            
            return Ok();
        }


    }
}
