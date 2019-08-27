using System;
using System.Linq;
using System.Reflection;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;


namespace DbContextReflectionType.Services.Helpers
{
    public class ContextBuilder
    {
        private DbContext _context;

        public ContextBuilder()
        {
        }

        public ContextBuilder SetContext(DbContext context)
        {
            _context = context;
            return this;
        }
        public ContextBuilder RecognitionType(IConfiguration configType)
        {
            _context.Add(new EntityOne());
            return this;
        }

        public DbContext Build() => _context;

        public Type GetType(string nameType)
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == nameType);
        }
    }
}