

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
                return JsonConvert.DeserializeObject(config.ConfigJson, Type.GetType(config.TypeName));
            }
            catch (Exception c)
            {
                Console.WriteLine(c);
            }

            return null;
        }
    }
}