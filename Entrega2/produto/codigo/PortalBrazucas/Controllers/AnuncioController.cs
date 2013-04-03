using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class AnuncioController : Controller
    {
        private bdportalEntities db = new bdportalEntities();

        //
        // GET: /Anuncio/

        public ActionResult Index()
        {
            var anuncios = db.anuncios.Include(a => a.usuarios);
            return View(anuncios.ToList());
        }

        //
        // GET: /Anuncio/Details/5

        public ActionResult Details(int id = 0)
        {
            anuncios anuncios = db.anuncios.Find(id);
            if (anuncios == null)
            {
                return HttpNotFound();
            }
            return View(anuncios);
        }

        //
        // GET: /Anuncio/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario");
            return View();
        }

        //
        // POST: /Anuncio/Create

        [HttpPost]
        public ActionResult Create(anuncios anuncios)
        {
            if (ModelState.IsValid)
            {
                db.anuncios.Add(anuncios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", anuncios.idUsuario);
            return View(anuncios);
        }

        //
        // GET: /Anuncio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            anuncios anuncios = db.anuncios.Find(id);
            if (anuncios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", anuncios.idUsuario);
            return View(anuncios);
        }

        //
        // POST: /Anuncio/Edit/5

        [HttpPost]
        public ActionResult Edit(anuncios anuncios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", anuncios.idUsuario);
            return View(anuncios);
        }

        //
        // GET: /Anuncio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            anuncios anuncios = db.anuncios.Find(id);
            if (anuncios == null)
            {
                return HttpNotFound();
            }
            return View(anuncios);
        }

        //
        // POST: /Anuncio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            anuncios anuncios = db.anuncios.Find(id);
            db.anuncios.Remove(anuncios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}