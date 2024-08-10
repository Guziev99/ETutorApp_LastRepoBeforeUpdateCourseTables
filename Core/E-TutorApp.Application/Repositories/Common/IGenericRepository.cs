using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Application.Repositories.Common
{
    public  interface IGenericRepository <T>  where T : class, IBaseEntity, new()
    {
    }
}
