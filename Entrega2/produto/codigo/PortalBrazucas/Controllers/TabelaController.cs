using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class TabelaController : Controller
    {
        private bdportalEntities db = new bdportalEntities();

        //
        // GET: /Tabela/

        public ActionResult Index()
        {
            var tabela = db.tabela.Include(t => t.selecoes);
            return View(tabela.ToList());
        }

        //
        // GET: /Tabela/Details/5

        public ActionResult Details(int id = 0)
        {
            tabela tabela = db.tabela.Find(id);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            return View(tabela);
        }

        //
        // GET: /Tabela/Create

        public ActionResult Create()
        {
            ViewBag.selecaoTabela = new SelectList(db.selecoes, "idSelecao", "nomeSelecao");
            return View();
        }

        //
        // POST: /Tabela/Create

        [HttpPost]
        public ActionResult Create(tabela tabela)
        {
            if (ModelState.IsValid)
            {
                db.tabela.Add(tabela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.selecaoTabela = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", tabela.selecaoTabela);
            return View(tabela);
        }

        //
        // GET: /Tabela/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tabela tabela = db.tabela.Find(id);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            ViewBag.selecaoTabela = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", tabela.selecaoTabela);
            return View(tabela);
        }

        //
        // POST: /Tabela/Edit/5

        [HttpPost]
        public ActionResult Edit(tabela tabela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.selecaoTabela = new SelectList(db.selecoes, "idSelecao", "nomeSelecao", tabela.selecaoTabela);
            return View(tabela);
        }

        //
        // GET: /Tabela/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tabela tabela = db.tabela.Find(id);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            return View(tabela);
        }

        //
        // POST: /Tabela/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tabela tabela = db.tabela.Find(id);
            db.tabela.Remove(tabela);
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