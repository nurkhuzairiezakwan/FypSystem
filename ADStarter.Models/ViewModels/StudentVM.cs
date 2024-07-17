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
        public int s_id { get; set; }
        public string s_user { get; set; }
        public string s_evaluator1 { get; set; }
        public string s_evaluator2 { get; set; }
        public string s_SV { get; set; }
        public string s_statusSV { get; set; } 
        public string s_academic_session { get; set; }
        public string s_semester { get; set; }
        public string s_SVagreement { get; set; }
        public string user_IC { get; set; }
        public string user_matric { get; set; }
        public string user_name { get; set; }
        public string user_contact { get; set; }
        public string st_id { get; set; } 
        public Student Student { get; set; }
        public string SupervisorName { get; set; }
        public string EvaluatorName1 { get; set; }
        public string EvaluatorName2 { get; set; }
        public ApplicationUser User {  get; set; }
        public IList<string> Roles { get; set; }
    }
}
