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
    [Authorize]
    public class VertebradosController : Controller
    {
        private MagnaEnciclopediaAnimalTurboEntities db = new MagnaEnciclopediaAnimalTurboEntities();

        //
        // GET: /Vertebrados/

        private static List<Vertebrados> list;
        public ActionResult Index()
        {
            var vertebrados = db.Vertebrados.Include(v => v.EstructuraPiel).Include(v => v.Habitat).Include(v => v.TipoAlimentacion).Include(v => v.TipoExtremidad).Include(v => v.TipoReproduccion).Include(v => v.TipoRespiracion).Include(v => v.TipoSangre);
            /*list = vertebrados.ToList();
            ViewBag.table = ConvertToTable(list);*/
            return View(vertebrados.ToList());
            //return View();
        }

        //
        // GET: /Vertebrados/Details/5

        public ActionResult Details(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Create

        public ActionResult Create()
        {
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre");
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre");
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre");
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre");
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre");
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre");
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre");
            return View();
        }

        //
        // POST: /Vertebrados/Create

        [HttpPost]
        public ActionResult Create(Vertebrados vertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Vertebrados.Add(vertebrados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // POST: /Vertebrados/Edit/5

        [HttpPost]
        public ActionResult Edit(Vertebrados vertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vertebrados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            return View(vertebrados);
        }

        //
        // POST: /Vertebrados/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            db.Vertebrados.Remove(vertebrados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private System.Data.DataTable ConvertToTable(List<Vertebrados> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("IdVertebrados");
            dt.Columns.Add("Nombre Comun");
            dt.Columns.Add("Nombre Cientifico");
            dt.Columns.Add("Numero de Patas");
            dt.Columns.Add("Habitat");
            dt.Columns.Add("Tipo de Reproduccion");
            dt.Columns.Add("Tipo de Alimentacion");
            dt.Columns.Add("Tipo de Respiracion");
            dt.Columns.Add("Tipo de Extremidad");
            dt.Columns.Add("Estructura de Piel");
            dt.Columns.Add("Tipo de Sangre");

            foreach (Vertebrados v in list)
            {
                dt.Rows.Add(new object[11]
                {
                    v.IdVertebrados,
                    v.NombreComun== null? "N/A":v.NombreComun,
                    v.NombreCientifico== null? "N/A":v.NombreCientifico,
                    v.NumeroPatas,
                    v.Habitat== null? "N/A":v.Habitat.Nombre,
                    v.TipoReproduccion== null? "N/A": v.TipoReproduccion.Nombre,
                    v.TipoAlimentacion== null? "N/A":v.TipoAlimentacion.Nombre,
                    v.TipoRespiracion== null? "N/A":v.TipoRespiracion.Nombre,
                    v.TipoExtremidad== null? "N/A":v.TipoExtremidad.Nombre,
                    v.EstructuraPiel== null? "N/A":v.EstructuraPiel.Nombre,
                    v.TipoSangre== null? "N/A": v.TipoSangre.Nombre,
                });

            }
            return dt;
        }
    }
}