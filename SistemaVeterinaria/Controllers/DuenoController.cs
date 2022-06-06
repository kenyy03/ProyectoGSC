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
        private VeterinariaEntities veterinariaContext;

        public DuenoController()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        // GET: Dueno
        public ActionResult Index()
        {
            return View(veterinariaContext.TDueno.ToList());
        }

        // GET: Dueno/Details/5
        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var duenoEncontrado = veterinariaContext.TDueno.Find(id);
            bool esUnDuenoValido = duenoEncontrado != null;
            if(!esUnDuenoValido) return HttpNotFound();

            return View(duenoEncontrado);
        }

        // GET: Dueno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dueno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] tbDUENO tbDUENO)
        {
            if (ModelState.IsValid)
            {
                veterinariaContext.TDueno.Add(tbDUENO);
                veterinariaContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbDUENO);
        }

        // GET: Dueno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDUENO tbDUENO = veterinariaContext.TDueno.Find(id);
            if (tbDUENO == null)
            {
                return HttpNotFound();
            }
            return View(tbDUENO);
        }

        // POST: Dueno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] tbDUENO tbDUENO)
        {
            if (ModelState.IsValid)
            {
                veterinariaContext.Entry(tbDUENO).State = EntityState.Modified;
                veterinariaContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDUENO);
        }

        // GET: Dueno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDUENO tbDUENO = veterinariaContext.TDueno.Find(id);
            if (tbDUENO == null)
            {
                return HttpNotFound();
            }
            return View(tbDUENO);
        }

        // POST: Dueno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbDUENO tbDUENO = veterinariaContext.TDueno.Find(id);
            veterinariaContext.TDueno.Remove(tbDUENO);
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
