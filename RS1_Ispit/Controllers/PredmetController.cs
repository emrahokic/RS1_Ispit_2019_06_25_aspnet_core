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
    public class PredmetController : Controller
    {
        private MojContext _db;

        public PredmetController(MojContext db)
        {
            _db = db;
        }
        public IActionResult PredmetDetalji()
        {
            PredmetDetaljiVM predmet = new PredmetDetaljiVM();

            predmet.rows = _db.Angazovan.OrderBy(a=>a.Predmet.Naziv).Select(a => new PredmetDetaljiVM.Row
            {
                NazivPredmeta = a.Predmet.Naziv,
                AkademskaGodina = a.AkademskaGodina.Opis,
                BrojOdrzanihCasova = _db.OdrzaniCas.Where(o => o.AngazovaniId == a.Id).Select(o => o.Id).Count(),
                BrojStudenata = _db.SlusaPredmet.Where(s => s.AngazovanId == a.Id).Select(s => s.Id).Count(),
                AngazovanID = a.Id,
                ImePrezimeNastavnik = a.Nastavnik.Ime + " " + a.Nastavnik.Prezime
            }).ToList();

            return View(predmet);
        }

        public IActionResult PredmetIspiti(int id)
        {
            PredmetIspitiVM ispit = new PredmetIspitiVM();

            ispit = _db.Angazovan.Where(a => a.Id == id).Select(a => new PredmetIspitiVM
            {
                AkademskaGodina = a.AkademskaGodina.Opis,
                AngazovanID = a.Id,
                ImePrezimeNastavnik = a.Nastavnik.Ime + " " + a.Nastavnik.Prezime,
                NazivPredmeta = a.Predmet.Naziv
            }).FirstOrDefault();


            ispit.rows = _db.Ispiti.Include(i=>i.StudentiNaIspitu).Where(i => i.AngazovanId == id).Select(i => new PredmetIspitiVM.Row
            {
                IspitID = i.IspitID,
                DatumIspita = i.DatumIspita,
                BrojNepolozenih = i.StudentiNaIspitu.Where(s => s.Ocjena < 6).Count(),
                BrojPrijavljenih = i.StudentiNaIspitu.Count(),
                EvidentiraniRezultati = i.EvidentiraniRezultati
            }).ToList();


            return View(ispit);
        }
        public IActionResult Zakljucaj(int id)
        {
            Ispit i = _db.Ispiti.Include(x => x.StudentiNaIspitu).Where(x => x.IspitID == id).FirstOrDefault();

            i.EvidentiraniRezultati = true;
            _db.SaveChanges();

            for (int y = 0; y < i.StudentiNaIspitu.Count(); y++)
            {
                if (i.StudentiNaIspitu[y].Ocjena == 0)
                {
                    i.StudentiNaIspitu[y].Ocjena = 5;
                }
            }
            _db.SaveChanges();

            return RedirectToActionPermanent(nameof(PredmetIspiti), new { id = i.AngazovanId  });
        }
    }
}