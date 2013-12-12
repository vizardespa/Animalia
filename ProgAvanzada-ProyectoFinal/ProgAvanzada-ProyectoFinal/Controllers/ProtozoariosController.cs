using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgAvanzada_ProyectoFinal.Models;

namespace ProgAvanzada_ProyectoFinal.Controllers
{
    public class ProtozoariosController : Controller
    {
        private MagnaEnciclopediaAnimalTurboEntities db = new MagnaEnciclopediaAnimalTurboEntities();

        //
        // GET: /Protozoarios/
        private static List<Protozoarios> list;
        public ActionResult Index()
        {
            var protozoarios = db.Protozoarios.Include(p => p.Habitat).Include(p => p.TipoReproduccion).Include(p => p.TipoAlimentacion).Include(p => p.TipoRespiracion);
            list = protozoarios.ToList();
            ViewBag.table = ConvertToTable(list);
            //return View(protozoarios.ToList());
            return View();
        }

        //
        // GET: /Protozoarios/Details/5

        public ActionResult Details(int id = 0)
        {
            Protozoarios protozoarios = db.Protozoarios.Find(id);
            if (protozoarios == null)
            {
                return HttpNotFound();
            }
            return View(protozoarios);
        }

        //
        // GET: /Protozoarios/Create

        public ActionResult Create()
        {
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre");
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre");
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre");
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre");
            return View();
        }

        //
        // POST: /Protozoarios/Create

        [HttpPost]
        public ActionResult Create(Protozoarios protozoarios)
        {
            if (ModelState.IsValid)
            {
                db.Protozoarios.Add(protozoarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", protozoarios.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", protozoarios.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", protozoarios.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", protozoarios.IdTipoRespiracion);
            return View(protozoarios);
        }

        //
        // GET: /Protozoarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Protozoarios protozoarios = db.Protozoarios.Find(id);
            if (protozoarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", protozoarios.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", protozoarios.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", protozoarios.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", protozoarios.IdTipoRespiracion);
            return View(protozoarios);
        }

        //
        // POST: /Protozoarios/Edit/5

        [HttpPost]
        public ActionResult Edit(Protozoarios protozoarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protozoarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", protozoarios.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", protozoarios.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", protozoarios.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", protozoarios.IdTipoRespiracion);
            return View(protozoarios);
        }

        //
        // GET: /Protozoarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Protozoarios protozoarios = db.Protozoarios.Find(id);
            if (protozoarios == null)
            {
                return HttpNotFound();
            }
            return View(protozoarios);
        }

        //
        // POST: /Protozoarios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Protozoarios protozoarios = db.Protozoarios.Find(id);
            db.Protozoarios.Remove(protozoarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private System.Data.DataTable ConvertToTable(List<Protozoarios> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("IdProtozoarios");
            dt.Columns.Add("Nombre Comun");
            dt.Columns.Add("Nombre Cientifico");
            dt.Columns.Add("Numero de Patas");
            dt.Columns.Add("Habitat");
            dt.Columns.Add("Tipo de Reproduccion");
            dt.Columns.Add("Tipo de Alimentacion");
            dt.Columns.Add("Tipo de Respiracion");
            dt.Columns.Add("¿Vive en agua dulce?");

            foreach (Protozoarios p in list)
            {
                dt.Rows.Add(new object[9]
                {
                    p.IdProtozoarios,
                    p.NombreComun== null? "N/A":p.NombreComun,
                    p.NombreCientifico== null? "N/A":p.NombreCientifico,
                    p.NumeroPatas,
                    p.Habitat== null? "N/A":p.Habitat.Nombre,
                    p.TipoReproduccion== null? "N/A": p.TipoReproduccion.Nombre,
                    p.TipoAlimentacion== null? "N/A":p.TipoAlimentacion.Nombre,
                    p.TipoRespiracion== null? "N/A":p.TipoRespiracion.Nombre,
                    p.VivirAguaDulce== true? "Si": "No",
                });

            }
            return dt;
        }


    }
}