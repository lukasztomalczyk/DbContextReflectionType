using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using DbContextReflectionType.Models;
using DbContextReflectionType.Services;
using DbContextReflectionType.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DbContextReflectionType.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        [HttpPost]
        public IActionResult Get([FromBody] ConfigDto config)
        {
            Console.WriteLine(typeof(EntityOne).FullName);
            var result = CastConfig.Return(config);
            
            Type generic = typeof(OperationService<>);
            Type constructed = generic.MakeGenericType(result.GetType());
            dynamic service = Activator.CreateInstance(constructed);
            service.Save(result);
            
            return Ok();
            //  var service = Activator.CreateInstance(typeof(OperationService<    >), new object[] 
        }


    }
}
