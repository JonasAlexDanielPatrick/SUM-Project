using System.ComponentModel.DataAnnotations;


namespace SUM_Project.Models
{
    public class MedarbejderModel
    {
        [Key]
        public int med_id { get; set; }

        [Display(Name = "Navn")]
        public string navn { get; set; }

        [Display(Name = "Telefon")]
        public int tlf { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Time Pris")]
        public double timepris { get; set; }
    }
}
