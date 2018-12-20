using System.ComponentModel.DataAnnotations;

namespace SUM_Project.Models
{
    public class MaterialerModel
    {
        [Key]
        public int mat_id { get; set; }
        [Display(Name = "Navn")]
        public string navn { get; set; }
        [Display(Name = "Indkøbs Pris")]
        public double indkøbspris { get; set; }
        [Display(Name = "Salgs Pris")]
        public double salgspris { get; set; }
    }
}
