using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUM_Project.Models
{
    public class TilbudMaterialerModel
    {
        public int TilbudID { get; set; }
        public int MatID { get; set; }
        public int Antal { get; set; }
        public int Brugt { get; set; }
        public double Rabat { get; set; }
    }
}
