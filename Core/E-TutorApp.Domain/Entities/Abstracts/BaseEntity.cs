using E_TutorApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.Entities.Abstracts
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt {  get; set; }
    }
}
