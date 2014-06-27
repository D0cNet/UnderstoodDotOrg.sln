using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Services
{
    public class ContentServiceResult
    {
        public bool IsSuccessful { get; set; }
        public bool IsLoggedIn { get; set; }
        public string Message { get; set; }
    }
}
