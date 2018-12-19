using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class HåndværkstimerModel
    {
        [Display(Name = "Tilbud ID")]
        public int tilbud_id { get; set; }
        [Display(Name = "Medarbejder ID")]
        public int med_id { get; set; }
        [Display(Name = "Fordelte Timer")]
        public int antal { get; set; }
        [Display(Name = "Brugte Timer")]
        public int brugt { get; set; }
        [Display(Name = "Rabat")]
        public double rabat { get; set; }
    }
}

