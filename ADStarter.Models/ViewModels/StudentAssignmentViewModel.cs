using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class StudentAssignmentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ProjectType { get; set; }
        public string SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public List<string> AvailableEvaluators { get; set; }
        public string Evaluator1Id { get; set; }
        public string Evaluator2Id { get; set; }
    }
}

