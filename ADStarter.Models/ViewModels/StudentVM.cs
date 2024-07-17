using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public string user_name { get; set; }
        public string SupervisorName { get; set; } // Add this property
        public ApplicationUser User {  get; set; }
        public IList<string> Roles { get; set; }
    }
}
