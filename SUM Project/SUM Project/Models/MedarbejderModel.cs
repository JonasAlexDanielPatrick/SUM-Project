using System.ComponentModel.DataAnnotations;


namespace SUM_Project.Models
{
    public class MedarbejderModel
    {
        [Key]
        public int med_id { get; set; }

        
        [Display(Name = "Navn")]
        public string navn { get; set; }


        [RegularExpression(@"^+\d{0,9}", ErrorMessage = "Telefon består er numre!!")]
        [Display(Name = "Telefon")]
        public int tlf { get; set; }


        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Dette er ikke en mail!!")]
        [Display(Name = "Email")]
        public string email { get; set; }


        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$", ErrorMessage = "Pris skal være et nummer!!")]
        [DataType(DataType.Currency)]
        [Display(Name = "Time Pris")]
        public double timepris { get; set; }
    }
}
