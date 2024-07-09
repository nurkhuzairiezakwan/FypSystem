#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADStarter.Models
{
    public partial class Course
    {
        [Key]
        public int course_ID { get; set; }
        public string course_code { get; set; }
        public string course_count { get; set; }
        public string course_desc { get; set; } // Change data type to string

    }
}
