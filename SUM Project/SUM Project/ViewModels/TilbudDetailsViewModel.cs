using SUM_Project.Models;
using System.Collections.Generic;

namespace SUM_Project.ViewModels
{
    public class TilbudDetailsViewModel
    {
        public TilbudModel tilbud { get; set; }
        public List<HåndværkstimerViewModel> håndværkstimervm { get; set; }
    }
}
