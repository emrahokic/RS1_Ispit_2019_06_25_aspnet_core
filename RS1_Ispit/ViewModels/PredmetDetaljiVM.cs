using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PredmetDetaljiVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int AngazovanID { get; set; }
            public string NazivPredmeta { get; set; }
            public string AkademskaGodina { get; set; }
            public string ImePrezimeNastavnik { get; set; }
            public int BrojOdrzanihCasova { get; set; }
            public int BrojStudenata { get; set; }
        }
     
    }
}
