using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class IspitStudenti
    {
        public int IspitStudentiID { get; set; }
        public int IspitID { get; set; }
        public Ispit Ispit { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public bool PristupioIspitu { get; set; }
        public int Ocjena { get; set; }
    }
}
