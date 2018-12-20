using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class MaterialeforbrugModel
    {
        [Display(Name = "Tilbud ID")]
        public int tilbud_id { get; set; }
        [Display(Name = "Materiale ID")]
        public int mat_id { get; set; }
        [Display(Name = "Fordelt Antal")]
        public int antal { get; set; }
        [Display(Name = "Brugt Antal")]
        public int brugt { get; set; }
        [Display(Name = "Rabat")]
        public double rabat { get; set; }

    }
}

