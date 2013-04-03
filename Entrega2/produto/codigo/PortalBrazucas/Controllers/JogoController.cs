using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class JogoController : Controller
    {
        private bdportalEntities db = new bdportalEntities();

        //
        // GET: /Jogo/

        public ActionResult Index()
        {
            var jogos = db.jogos.Include(j => j.estadios).Include(j => j.selecoes).Include(j => j.selecoes1);
            return View(jogos.ToList());
        }

        //
        // GET: /Jogo/Details/5

        public ActionResult Details(int id = 0)
        {
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        //
        // GET: /Jogo/Create

        public ActionResult Create()
        {
            ViewBag.estadioJogo = new SelectList(db.estadios, "idEstadio", "nomeEstadio");
            ViewBag.equipeAJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao");
            ViewBag.equipeBJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao");
            return View();
        }

        //
        // POST: /Jogo/Create

        [HttpPost]
        public ActionResult Create(jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.jogos.Add(jogos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estadioJogo = new SelectList(db.estadios, "idEstadio", "nomeEstadio", jogos.estadioJogo);
            ViewBag.equipeAJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeAJogo);
            ViewBag.equipeBJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeBJogo);
            return View(jogos);
        }

        //
        // GET: /Jogo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            ViewBag.estadioJogo = new SelectList(db.estadios, "idEstadio", "nomeEstadio", jogos.estadioJogo);
            ViewBag.equipeAJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeAJogo);
            ViewBag.equipeBJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeBJogo);
            return View(jogos);
        }

        //
        // POST: /Jogo/Edit/5

        [HttpPost]
        public ActionResult Edit(jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estadioJogo = new SelectList(db.estadios, "idEstadio", "nomeEstadio", jogos.estadioJogo);
            ViewBag.equipeAJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeAJogo);
            ViewBag.equipeBJogo = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", jogos.equipeBJogo);
            return View(jogos);
        }

        //
        // GET: /Jogo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            jogos jogos = db.jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        //
        // POST: /Jogo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            jogos jogos = db.jogos.Find(id);
            db.jogos.Remove(jogos);
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