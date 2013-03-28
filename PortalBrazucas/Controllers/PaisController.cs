using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    //public class BaseController<TClasse> : Controller where TClasse:Models.Entidade
    public class PaisController : Controller
    {
        protected Models.Contexto db = new Models.Contexto();
        //
        // GET: /Base/

        public ActionResult Index()
        {
            var lista = db.Set<Models.Pais>().ToList();
            return View(lista);
        }

        //
        // GET: /Base/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Base/Create

        public ActionResult Create()
        {
            var item = new Models.Pais();
            return View(item);
        }

        //
        // POST: /Base/Create

        [HttpPost]
        public ActionResult Create(Models.Pais item)
        {
            try
            {
                // TODO: Add insert logic here
                db.Set<Models.Pais>().Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Base/Edit/5

        public ActionResult Edit(int id)
        {
            var item = db.Paises.Find(id);
            return View(item);
        }

        //
        // POST: /Base/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Models.Pais item = null;
            try
            {
                // TODO: Add update logic here

                item = db.Paises.Find(id);
                TryUpdateModel(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Base/Delete/5

        public ActionResult Delete(int id)
        {
            var item = db.Paises.Find(id);
            return View(item);
        }

        //
        // POST: /Base/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
