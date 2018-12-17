using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUM_Project.Models
{
    public class TilbudHåndværkstimerModel
    {
        public int TilbudID { get; set; }
        public int MedID { get; set; }
        public int Antal { get; set; }
        public int Brugt { get; set; }
        public double Rabat { get; set; }
    }
}

