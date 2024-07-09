using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models
{
    public class Student
    {
        public int s_id { get; set; }
        public string s_user { get; set; }
        public int s_evaluator1 { get; set; }
        public int s_evaluator2 { get; set; }
        public int s_SV { get; set; }
        public int? s_statusSV { get; set; } // Nullable
        public string s_academic_session { get; set; }
        public string s_semester { get; set; }
        public bool s_SVagreement { get; set; }

        // Navigation properties
        public ICollection<Proposal> Proposals { get; set; }
    }
}
