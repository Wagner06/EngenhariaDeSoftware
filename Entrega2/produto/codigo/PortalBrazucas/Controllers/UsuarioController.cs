using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class UsuarioController : Controller
    {
        private bdportalEntities db = new bdportalEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u=> u.tiposusuario);
            return View(usuarios.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int idUsuario)
        {
            usuarios usuarios = db.usuarios.Find(idUsuario);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.idTipoUsuario = new SelectList(db.tiposusuario.Where<tiposusuario>(u => u.idtipoUsuario != 1), "idtipoUsuario", "descricaoTipoUsuario");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoUsuario = new SelectList(db.tiposusuario.Where<tiposusuario>(u => u.idtipoUsuario != 1), "idtipoUsuario", "descricaoTipoUsuario", usuarios.idTipoUsuario);
            return View(usuarios);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int idUsuario)
        {
            usuarios usuarios = db.usuarios.Find(idUsuario);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoUsuario = new SelectList(db.tiposusuario.Where<tiposusuario>(u => u.idtipoUsuario != 1), "idtipoUsuario", "descricaoTipoUsuario", usuarios.idTipoUsuario);
            return View(usuarios);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoUsuario = new SelectList(db.tiposusuario.Where<tiposusuario>(u => u.idtipoUsuario != 1), "idtipoUsuario", "descricaoTipoUsuario", usuarios.idTipoUsuario);
            return View(usuarios);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int idUsuario)
        {
            usuarios usuarios = db.usuarios.Find(idUsuario);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int idUsuario)
        {
            usuarios usuarios = db.usuarios.Find(idUsuario);
            db.usuarios.Remove(usuarios);
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