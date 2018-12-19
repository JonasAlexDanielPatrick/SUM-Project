using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class MaterialeforbrugModel
    {
        [Key]
        public int tilbud_id { get; set; }
        public int mat_id { get; set; }
        public int antal { get; set; }
        public int brugt { get; set; }
        public double rabat { get; set; }
    }
}
