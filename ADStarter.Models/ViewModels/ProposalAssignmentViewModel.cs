using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class ProposalAssignmentViewModel
    {
        public int p_id { get; set; }
        public int s_id { get; set; }
        public string StudentName { get; set; }
        public string p_title { get; set; }
        public string p_file { get; set; }
        public string st_id { get; set; }
        public string s_SV { get; set; }
        public string s_evaluator1 { get; set; }
        public string s_evaluator2 { get; set; }
        public string pt_ID { get; set; } // Project Type from ApplicationUser
    }
}
