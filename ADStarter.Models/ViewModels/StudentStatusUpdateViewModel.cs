using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class StudentStatusUpdateViewModel
    {
        public int s_id { get; set; }
        public string s_SV { get; set; }
        public string s_statusSV { get; set; }
        public string s_academic_session { get; set; }
        public string s_semester { get; set; }
        public string UserName { get; set; }
        public string UserMatric { get; set; }
    }
}
