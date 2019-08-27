using System;
using System.Collections.Generic;
using System.Linq;
using DbContextReflectionType.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace DbContextReflectionType.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly DatabaseDbContext _database;

        public ListController(IServiceProvider provider)
        {
            _database = provider.GetRequiredService<DatabaseDbContext>();
        }
        
        [HttpGet]
        public List<EntityOne> GetEntityOne()
        {
            return _database.One.ToList();
        }
        
        [HttpGet]
        public List<EntityTwo> GetEntityTwo()
        {
            return _database.Two.ToList();
        }
    }
}