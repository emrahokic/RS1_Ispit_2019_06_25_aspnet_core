using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class IspitStudentController : Controller
    {
        private MojContext _db;

        public IspitStudentController(MojContext db)
        {
            _db = db;
        }
        public IActionResult UpdateOcjena(int id)
        {
            UpdateOcjenaVM model = new UpdateOcjenaVM();

            model = _db.IspitStudenti.Where(x => x.IspitStudentiID == id).Select(x => new UpdateOcjenaVM
            {
                Ocjena = x.Ocjena,
                StudentIme = x.Student.Ime + " " + x.Student.Prezime,
                IspitStudentiID = x.IspitStudentiID,
                IspitID = x.IspitID
            }).FirstOrDefault();

            return PartialView("UpdateOcjena", model);
        }

        public IActionResult Prisustvo(int id)
        {
            IspitStudenti ispit = _db.IspitStudenti.Include(i => i.Ispit).Where(i => i.IspitStudentiID == id).FirstOrDefault();

            if (!ispit.Ispit.EvidentiraniRezultati)
            {
                ispit.PristupioIspitu = !ispit.PristupioIspitu;
                _db.SaveChanges();
            }

            return RedirectToActionPermanent("IspitDetaljiPV", "Ispit", new { id = ispit.IspitID });
        }


        [HttpPost]
        public IActionResult UpdateOcjena(UpdateOcjenaVM model,int Ocjena,int IspitStudentiID)
        {
            
            IspitStudenti ispit = _db.IspitStudenti.Where(i => i.IspitStudentiID == IspitStudentiID).FirstOrDefault();
            ispit.Ocjena = Ocjena;
            _db.SaveChanges();

            return RedirectToActionPermanent("IspitDetaljiPV", "Ispit", new { id = ispit.IspitID });
        }
    }
}