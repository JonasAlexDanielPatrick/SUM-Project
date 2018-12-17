using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUM_Project.Models
{
    public class TilbudModel
    {
        public int TilbudID { get; set; }
        public int KundeID { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Type { get; set; }
        public string StartDato { get; set; }
        public string SlutDato { get; set; }
        public double Rabat { get; set; }
        public double Pris { get; set; }
        public int ProjektAnsvarlig { get; set; }
        public TilbudHåndværkstimerModel[] Håndværkstimer { get; set; }
        public TilbudMaterialerModel[] Materialer { get; set; }
        public TilbudKørselModel[] Kørsel { get; set; }
    }
}
