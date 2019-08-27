

using System;
using DbContextReflectionType.Models;
using DbContextReflectionType.Models.Abstracts;
using Newtonsoft.Json;

namespace DbContextReflectionType.Services.Helpers
{
    public static class CastConfig
    {
        public static object Return(ConfigDto config)
        {
            try
            {
                var result = JsonConvert.DeserializeObject(config.ConfigJson, Type.GetType(config.TypeName));
                Console.WriteLine("----> " + result.GetType().FullName);
                return result;
            }
            catch (Exception c)
            {
                Console.WriteLine(c);
            }

            return null;
        }
    }
}