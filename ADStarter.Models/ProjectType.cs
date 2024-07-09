#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADStarter.Models
{
    public partial class ProjectType
    {
        [Key]
        public int pt_ID { get; set; }

        public string pt_desc { get; set; } // Change data type to string

    }
}
