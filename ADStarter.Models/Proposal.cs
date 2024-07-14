using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models
{
    public partial class Proposal
    {
        [Key]
        public int p_id { get; set; }

        [DisplayName("Title")]
        public string p_title { get; set; }

        [DisplayName("Proposal (only PDF is accepted)")]
        public string p_file { get; set; }

        [DisplayName("Evaluation Result")]
        public string? st_id { get; set; }

        [DisplayName("Supervisor Comment")]
        public string p_sv_comment { get; set; }
        [DisplayName("Evaluator 1 Comment")]
        public string p_evaluator1_comment { get; set; }
        [DisplayName("Evaluator 2 Comment")]
        public string p_evaluator2_comment { get; set; }

        public int s_id { get; set; }
        
        [ForeignKey("s_id")]
        public virtual Student Student { get; set; }
    }
}
