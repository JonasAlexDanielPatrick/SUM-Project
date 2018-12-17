using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUM_Project.Models
{
    public class TilbudKørselModel
    {
        public int TilbudID { get; set; }
        public int BilID { get; set; }
        public string Type { get; set; }
        public int Antal { get; set; }
        public double Brugt { get; set; }
    }
}

