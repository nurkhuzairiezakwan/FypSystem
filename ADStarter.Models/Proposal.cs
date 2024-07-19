using ADStarter.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ADStarter.Models
{
    public partial class Proposal
    {
        [Key]
        public int p_id { get; set; }

        public int s_id { get; set; }

        [DisplayName("Title")]
        public string p_title { get; set; }

        [DisplayName("Proposal (only PDF is accepted)")]
        public string p_file { get; set; }

        [DisplayName("Evaluation Result")]
        public string? st_id { get; set; }  //status id

        [DisplayName("Supervisor Comment")]
        public string? p_sv_comment { get; set; }

        [DisplayName("Evaluator 1 Comment")]
        public string? p_evaluator1_comment { get; set; }

        [DisplayName("Evaluator 2 Comment")]
        public string? p_evaluator2_comment { get; set; }

        [ForeignKey("s_id")]
        public Student Student { get; set; }

        public bool IsResubmission { get; set; } // New property for resubmission tracking
    }


}
