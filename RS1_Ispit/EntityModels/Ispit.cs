using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class Ispit
    {
        public int IspitID { get; set; }
        public int AngazovanId { get; set; }
        public Angazovan Angazovan { get; set; }
        public DateTime DatumIspita { get; set; }
        public string Napomena { get; set; }
        public bool EvidentiraniRezultati { get; set; }
   
        public List<IspitStudenti> StudentiNaIspitu { get; set; }

        public Ispit()
        {
            StudentiNaIspitu = new List<IspitStudenti>();
        }
    }
}
