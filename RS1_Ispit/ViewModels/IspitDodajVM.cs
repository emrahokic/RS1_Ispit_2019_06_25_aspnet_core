using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitDodajVM
    {
        public int AngazovanID { get; set; }
        public int IspitID { get; set; }
        public string NazivPredmeta { get; set; }
        public string AkademskaGodina { get; set; }
        public string ImePrezimeNastavnik { get; set; }
        public DateTime DatumIspita { get; set; }
        public string Napomena { get; set; }
    }
}
