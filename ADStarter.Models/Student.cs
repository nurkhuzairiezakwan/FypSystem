using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models
{
    public class Student
    {
        [Key]
        public int s_id { get; set; }
        public string s_user { get; set; }
        public string s_evaluator1 { get; set; }
        public string s_evaluator2 { get; set; }
        public string s_SV { get; set; }
        public string s_statusSV { get; set; } // Nullable
        public string s_academic_session { get; set; }
        public string s_semester { get; set; }
        public string s_SVagreement { get; set; }
        public ApplicationUser User { get; set; }

        // Navigation properties
        public ICollection<Proposal> Proposals { get; set; }
    }
}
