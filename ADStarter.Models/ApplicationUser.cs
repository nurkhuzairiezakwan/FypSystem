using ADStarter.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ADStarter.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "The IC number is required.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid fill. Must follow IC format.")]
        [StringLength(100)]
        public string user_IC { get; set; }
        [DisplayName("Matric Number")]
        public string user_matric { get; set; }
        [DisplayName("Full Name")]
        public string user_name { get; set; }
        [DisplayName("Contact")]
        public string user_contact { get; set; }
        [DisplayName("Address")]
        public string user_address { get; set; }
        public string pt_ID { get; set; }
        public int? course_ID { get; set; }

        [ForeignKey("course_ID")]
        public virtual Course course { get; set; }


    }
}