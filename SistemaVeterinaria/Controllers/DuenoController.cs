using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class DuenoController : Controller
    {
        public readonly VeterinariaEntities veterinariaContext;

        public DuenoController()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public ActionResult Index()
        {
            return View(veterinariaContext.TDueno.ToList());
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var duenoEncontrado = veterinariaContext.TDueno.Find(id);
            bool esUnDuenoValido = duenoEncontrado != null;
            if(!esUnDuenoValido) return HttpNotFound();

            return View(duenoEncontrado);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] 
        tbDUENO Dueno)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            veterinariaContext.TDueno.Add(Dueno);
            veterinariaContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] 
        tbDUENO Dueno)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            veterinariaContext.Entry(Dueno).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var duenoEncontrado = veterinariaContext.TDueno.Find(id);
            bool esUnDuenoValido = duenoEncontrado != null;
            if(!esUnDuenoValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            veterinariaContext.TDueno.Remove(duenoEncontrado);
            veterinariaContext.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                veterinariaContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
