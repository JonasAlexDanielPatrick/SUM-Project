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
        public string Navn { get; set; }

        public string Tlf { get; set; }

        public string Email { get; set; }

        public decimal TimePris { get; set; }
    }
}
