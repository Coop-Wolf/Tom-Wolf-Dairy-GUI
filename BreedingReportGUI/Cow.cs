using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedingReportGUI
{
    internal class Cow
    {
        public int CowID { get; set; }
        public DateTime BreedDate { get; set; }
        public string Sire { get; set; }

        // Calculated properties | Implementation from ChatGPT
        public DateTime CalfDate => BreedDate.AddDays(285);       // 285 days gestation
        public DateTime DryDate => CalfDate.AddDays(-55);         // 55 days before calf
        public DateTime BringInDate => CalfDate.AddDays(-14);     // 14 days before calf
        public bool IsOld => DateTime.Now > CalfDate;             // Has the cow already calved?
    }
}
