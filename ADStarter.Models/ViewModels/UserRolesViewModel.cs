using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public string Id { get; set; }
        public string user_matric { get; set; }
        public string user_name { get; set; }
        public string pt_ID { get; set; }
        public string course_desc { get; set; } // New property for course name
        public IList<string> roles { get; set; }
    }
}

