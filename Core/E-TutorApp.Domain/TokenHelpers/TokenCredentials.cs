using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Domain.TokenHelpers
{
    public class TokenCredentials
    {
        // Fields
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
