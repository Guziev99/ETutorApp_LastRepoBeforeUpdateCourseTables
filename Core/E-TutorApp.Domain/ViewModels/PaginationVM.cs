using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.ViewModels
{
    public  record PaginationVM
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 0;
    }
}
