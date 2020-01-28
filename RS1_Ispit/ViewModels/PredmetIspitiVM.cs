using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PredmetIspitiVM
    {
        public int AngazovanID { get; set; }
        public string NazivPredmeta { get; set; }
        public string AkademskaGodina { get; set; }
        public string ImePrezimeNastavnik { get; set; }

        public List<Row> rows { get; set; }

        public PredmetIspitiVM()
        {
            rows = new List<Row>();
        }

        public class Row
        {
            public int IspitID { get; set; }
            public DateTime DatumIspita { get; set; }
            public int BrojNepolozenih { get; set; }
            public int BrojPrijavljenih { get; set; }
            public bool EvidentiraniRezultati { get; set; }
        }
    }
}
