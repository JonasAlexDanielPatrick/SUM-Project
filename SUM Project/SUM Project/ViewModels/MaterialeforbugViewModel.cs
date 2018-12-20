using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SUM_Project.Models;

namespace SUM_Project.ViewModels
{
    public class MaterialeforbrugViewModel
    {
        [Display(Name = "Navn")]
        public string navn { get; set; }
        public MaterialeforbrugModel forbrug { get; set; }


    }
}
