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
    public class IspitController : Controller
    {
        private MojContext _db;

        public IspitController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IspitDetalji(int id)
        {
            IspitDetaljiVM ispit = new IspitDetaljiVM();

            ispit = _db.Ispiti.Where(i => i.IspitID == id).Select(i => new IspitDetaljiVM
            {
                AkademskaGodina=i.Angazovan.AkademskaGodina.Opis,
                ImePrezimeNastavnik=i.Angazovan.Nastavnik.Ime+" "+ i.Angazovan.Nastavnik.Prezime,
                NazivPredmeta=i.Angazovan.Predmet.Naziv,
                DatumIspita=i.DatumIspita,
                Napomena=i.Napomena,
                IspitID=i.IspitID
            }).FirstOrDefault();

            return View(ispit);
        }
        public IActionResult IspitDetaljiPV(int id)
        {
            IspitDetaljiVM ispit = new IspitDetaljiVM();

            ispit.EvidentiraniRezultati = _db.Ispiti.Where(x => x.IspitID == id).Select(x => x.EvidentiraniRezultati).FirstOrDefault();

            ispit.rows = _db.IspitStudenti.Where(s => s.IspitID == id).Select(s => new IspitDetaljiVM.Row
            {
                Ocjena = s.Ocjena,
                PristupioIspitu = s.PristupioIspitu,
                StudentIme = s.Student.Ime + " " + s.Student.Prezime,
                IspitStudentiID = s.IspitStudentiID

            }).ToList();

            return PartialView(ispit);
        }

        public IActionResult Dodaj(int id)
        {
            IspitDodajVM ispit = new IspitDodajVM();

            ispit = _db.Angazovan.Where(a => a.Id == id).Select(a => new IspitDodajVM
            {
                AkademskaGodina = a.AkademskaGodina.Opis,
                AngazovanID = a.Id,
                ImePrezimeNastavnik = a.Nastavnik.Ime + " " + a.Nastavnik.Prezime,
                NazivPredmeta = a.Predmet.Naziv
            }).FirstOrDefault();

            return View(ispit);
        }
        [HttpPost]
        public IActionResult Dodaj(int id ,IspitDodajVM model)
        {
            Ispit noviIspit = new Ispit
            {
                DatumIspita=model.DatumIspita,
                Napomena=model.Napomena,
                AngazovanId=model.AngazovanID,
                EvidentiraniRezultati=false
            };

            noviIspit.StudentiNaIspitu = _db.SlusaPredmet.Where(s => s.AngazovanId == noviIspit.AngazovanId).Select(s => new IspitStudenti
            {
                Ocjena=0,
                PristupioIspitu=false,
                StudentID=s.UpisGodine.StudentId
            }).ToList();

            _db.Ispiti.Add(noviIspit);
            _db.SaveChanges();


            return RedirectToActionPermanent("PredmetIspiti", "Predmet", new { id = model.AngazovanID });
        }
    }
}