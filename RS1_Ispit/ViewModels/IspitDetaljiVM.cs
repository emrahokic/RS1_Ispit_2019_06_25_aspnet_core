using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitDetaljiVM
    {
        public string NazivPredmeta { get; set; }
        public int IspitID { get; set; }
        public string AkademskaGodina { get; set; }
        public string ImePrezimeNastavnik { get; set; }
        public DateTime DatumIspita { get; set; }
        public string Napomena { get; set; }
        public bool EvidentiraniRezultati { get; set; }
        
        public List<Row> rows { get; set; }

        public IspitDetaljiVM()
        {
            rows = new List<Row>();
        }

        public class Row
        {
            public int IspitStudentiID { get; set; }
            public string StudentIme { get; set; }
            public bool PristupioIspitu { get; set; }
            public string PristupioIspituString { get { return PristupioIspitu ? "Pristupio" : "Nije pristupio"; } }
            public int Ocjena { get; set; }
        }
    }
}
