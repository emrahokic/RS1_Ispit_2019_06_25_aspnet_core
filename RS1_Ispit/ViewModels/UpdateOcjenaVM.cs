using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UpdateOcjenaVM
    {
        public int IspitStudentiID { get; set; }
        public int IspitID { get; set; }
        public string StudentIme { get; set; }
        public int Ocjena { get; set; }
    }
}
