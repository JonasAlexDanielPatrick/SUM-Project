using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class KørselModel
    {
        [Key]
        public int tilbud_id { get; set; }
        public int bil_id { get; set; }
        public string type { get; set; }
        public int antal { get; set; }
        public double brugt { get; set; }
    }
}

