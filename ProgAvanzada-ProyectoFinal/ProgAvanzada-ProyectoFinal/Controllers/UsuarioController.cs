using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgAvanzada_ProyectoFinal.Models;
using System.Web.Security;

namespace ProgAvanzada_ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private MagnaEnciclopediaAnimalTurboEntities db = new MagnaEnciclopediaAnimalTurboEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            //var usuario = db.Usuario.Include(u => u.TipoUsuario);
            //return View(usuario.ToList());
            return View();
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Nombre");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Nombre", usuario.IdTipoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Nombre", usuario.IdTipoUsuario);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.IdTipoUsuario = new SelectList(db.TipoUsuario, "IdTipoUsuario", "Nombre", usuario.IdTipoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            if (ModelState.IsValid)
            {
                if (Usuario.Login(user.Usuario1, user.Contraseña))
                {
                    FormsAuthentication.SetAuthCookie(user.Usuario1, false);
                    return RedirectToAction("Index", "Usuario");
                }
            }

            return View(user);
        }

        public ActionResult Logout(Usuario user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}