using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class TilbudModel
    {
        [Key]
        public int tilbud_id { get; set; }
        [Display(Name = "Kunde ID")]
        public int kunde_id { get; set; }
        [Display(Name = "Titel")]
        public string titel { get; set; }
        [Display(Name = "Beskrivelse")]
        public string beskrivelse { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Start Dato")]
        public string start_dato { get; set; }
        [Display(Name = "Slut Dato")]
        public string slut_dato { get; set; }
        [Display(Name = "Rabat")]
        public double rabat { get; set; }
        [Display(Name = "Pris")]
        public double pris { get; set; }
        [Display(Name = "Projekt Ansvarlig")]
        public int projekt_ansvarlig { get; set; }
    }
}
