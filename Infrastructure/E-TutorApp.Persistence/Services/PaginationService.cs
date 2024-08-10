using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Persistence.Services
{
    public static class PaginationService
    {

        public static IQueryable<T> Paginate <T>(this IQueryable<T> items ,PaginationVM paginationVM)
        {

            var itemsOnPage = items.Skip(paginationVM.Page * paginationVM.PageSize).Take(paginationVM.PageSize);
            
            return itemsOnPage;
        }

        public static IEnumerable<T> Paginate<T> (this IEnumerable<T> items ,PaginationVM paginationVM)
        {
            var itemsOnPage = items.Skip(paginationVM.Page * paginationVM.PageSize).Take(paginationVM.PageSize);
            return itemsOnPage;
        }

        
        
       
    }
}
