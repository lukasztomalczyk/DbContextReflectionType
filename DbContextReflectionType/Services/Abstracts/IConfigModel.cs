using DbContextReflectionType.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextReflectionType.Services.Abstracts
{
    public interface IConfigModel
    {
        IActiveRepository ActivateRepository();
    }
}
