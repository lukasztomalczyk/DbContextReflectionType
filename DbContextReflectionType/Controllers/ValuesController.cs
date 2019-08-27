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
        private readonly IOperationService _operationService;

        public ValuesController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        
        [HttpPost]
        
        public IActionResult Get([FromBody] ConfigDto config)
        {
            _operationService.Deserialize(config)
                .ActivateRepository()
                .SaveConfig();
           
            return Ok();
        }
    }
}
