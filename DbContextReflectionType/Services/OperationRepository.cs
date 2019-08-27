using System;
using System.Collections.Generic;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using DbContextReflectionType.Services.Helpers;

namespace DbContextReflectionType.Services
{
    internal class OperationRepository<T> where T : class, IConfiguration
    {
        private readonly DatabaseDbContext _context;

        public OperationRepository(DatabaseDbContext context)    
        {
            _context = context;
        }

        public bool Save(IConfiguration configToSave)
        {
            Console.WriteLine(" ---- > Enter to Save method");
            _context.Set<T>();
            Console.WriteLine(" ---- > Set entity....");
            
            _context.Add(configToSave);
            Console.WriteLine(" ---- > Add to context");
            
            _context.SaveChanges();
            
            Console.WriteLine("Save to Database....");
            return true;
        }
    }
}