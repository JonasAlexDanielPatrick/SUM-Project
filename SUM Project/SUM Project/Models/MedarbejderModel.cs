using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SUM_Project.Models
{
    public class MedarbejderModel
    {
        public int Id { get; set; }

        [Display(Name = "Navn")]
        public string Navn { get; set; }

        [Display(Name = "Telefon")]
        public string Tlf { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Time Pris")]
        public int TimePris { get; set; }
    }
}
