using System;
using System.Collections.Generic;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using DbContextReflectionType.Services.Helpers;

namespace DbContextReflectionType.Services
{
    public class OperationService<T> where T : class, IConfiguration
    {
        private IConfiguration entity;
        private readonly DatabaseDbContext _context;

        public OperationService(DatabaseDbContext context)    
        {
            _context = context;
        }

        public bool Save(T configToSave)
        {

            _context.Set<T>();
            _context.Add(configToSave);
            _context.SaveChanges();
            
            Console.WriteLine("Save to Database....");
            return true;
        }
    }
}