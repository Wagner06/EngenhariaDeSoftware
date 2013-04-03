using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class NoticiaController : Controller
    {
        private bdportalEntities db = new bdportalEntities();

        //
        // GET: /Noticia/

        public ActionResult Index()
        {
            var noticias = db.noticias.Include(n => n.usuarios);
            return View(noticias.ToList());
        }

        //
        // GET: /Noticia/Details/5

        public ActionResult Details(int id = 0)
        {
            noticias noticias = db.noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        //
        // GET: /Noticia/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario");
            return View();
        }

        //
        // POST: /Noticia/Create

        [HttpPost]
        public ActionResult Create(noticias noticias)
        {
            if (ModelState.IsValid)
            {
                db.noticias.Add(noticias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", noticias.idUsuario);
            return View(noticias);
        }

        //
        // GET: /Noticia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            noticias noticias = db.noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", noticias.idUsuario);
            return View(noticias);
        }

        //
        // POST: /Noticia/Edit/5

        [HttpPost]
        public ActionResult Edit(noticias noticias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nomeUsuario", noticias.idUsuario);
            return View(noticias);
        }

        //
        // GET: /Noticia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            noticias noticias = db.noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        //
        // POST: /Noticia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            noticias noticias = db.noticias.Find(id);
            db.noticias.Remove(noticias);
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