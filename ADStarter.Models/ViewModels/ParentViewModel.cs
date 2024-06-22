﻿using System.ComponentModel.DataAnnotations;

namespace ADStarter.Models.ViewModels
{
    public class ParentViewModel
    {
        [Required]
        [StringLength(100)]
        public string f_name { get; set; }

        [Required]
        [StringLength(15)]
        public string f_phoneNum { get; set; }

        [StringLength(50)]
        public string f_race { get; set; }

        [StringLength(255)]
        public string f_address { get; set; }

        [StringLength(255)]
        public string f_Waddress { get; set; }

        [StringLength(100)]
        public string f_email { get; set; }

        [StringLength(100)]
        public string f_occupation { get; set; }

        [StringLength(50)]
        public string f_status { get; set; }

        [StringLength(100)]
        public string m_name { get; set; }

        [StringLength(15)]
        public string m_phoneNum { get; set; }

        [StringLength(50)]
        public string m_race { get; set; }

        [StringLength(255)]
        public string m_address { get; set; }

        [StringLength(255)]
        public string m_Waddress { get; set; }

        [StringLength(100)]
        public string m_email { get; set; }

        [StringLength(50)]
        public string m_status { get; set; }

        [Required]
        public double fm_income { get; set; }
    }
}
