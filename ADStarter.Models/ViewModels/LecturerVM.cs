using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class LecturerVM
    {
        public string user_matric { get; set; }
        public string user_name { get; set; }
        public string pt_ID { get; set; }
        public IList<string> Roles { get; set; }
        public bool HasDetails { get; set; }
    }
}
