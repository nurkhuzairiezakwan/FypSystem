using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.Models.ViewModels
{
    public class CommitteeVM
    {
        public string? User { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]

        public string Email { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid fill. Must follow IC format.")]
        [StringLength(100)]
        public string user_IC {  get; set; }
        public string user_matric { get; set; }
        public string user_name { get; set; }
        public string user_address { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string user_contact { get; set; }
        public string? pt_ID { get; set; }
        public string? course_name { get; set; }
        public IList<string>? Roles { get; set; }
        public int course_ID { get; set; }
        public string SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem>? Courses { get; set; }
        public IEnumerable<SelectListItem>? RolesList { get; set; }
    }
}
