using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class TilbudModel
    {
        [Key]
        public int tilbud_id { get; set; }
        public int kunde_id { get; set; }
        public string titel { get; set; }
        public string beskrivelse { get; set; }
        public string type { get; set; }
        public string start_dato { get; set; }
        public string slut_dato { get; set; }
        public double rabat { get; set; }
        public double pris { get; set; }
        public int projekt_ansvarlig { get; set; }
    }
}
