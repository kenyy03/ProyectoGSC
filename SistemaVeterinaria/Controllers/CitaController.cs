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
    public class CitaController : Controller
    {
        private VeterinariaEntities veterinariaContext;
        
        public CitaController()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        // GET: Cita
        public ActionResult Index()
        {
            var tbCitas = veterinariaContext.tbCitas.Include(t => t.tbEmpleado).Include(t => t.Tbpaciente);
            return View(tbCitas.ToList());
        }

        // GET: Cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCita tbCita = veterinariaContext.tbCitas.Find(id);
            if (tbCita == null)
            {
                return HttpNotFound();
            }
            return View(tbCita);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.cod_medico = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE");
            ViewBag.cod_paciente = new SelectList(veterinariaContext.Tbpacientes, "cod_paciente", "nombre");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_cita,fecha_cita,hora_cita,cod_paciente,descrip_cita,fecha,cod_medico")] tbCita tbCita)
        {
            if (ModelState.IsValid)
            {
                veterinariaContext.tbCitas.Add(tbCita);
                veterinariaContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_medico = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE", tbCita.cod_medico);
            ViewBag.cod_paciente = new SelectList(veterinariaContext.Tbpacientes, "cod_paciente", "nombre", tbCita.cod_paciente);
            return View(tbCita);
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCita tbCita = veterinariaContext.tbCitas.Find(id);
            if (tbCita == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_medico = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE", tbCita.cod_medico);
            ViewBag.cod_paciente = new SelectList(veterinariaContext.Tbpacientes, "cod_paciente", "nombre", tbCita.cod_paciente);
            return View(tbCita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_cita,fecha_cita,hora_cita,cod_paciente,descrip_cita,fecha,cod_medico")] tbCita tbCita)
        {
            if (ModelState.IsValid)
            {
                veterinariaContext.Entry(tbCita).State = EntityState.Modified;
                veterinariaContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_medico = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE", tbCita.cod_medico);
            ViewBag.cod_paciente = new SelectList(veterinariaContext.Tbpacientes, "cod_paciente", "nombre", tbCita.cod_paciente);
            return View(tbCita);
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCita tbCita = veterinariaContext.tbCitas.Find(id);
            if (tbCita == null)
            {
                return HttpNotFound();
            }
            return View(tbCita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCita tbCita = veterinariaContext.tbCitas.Find(id);
            veterinariaContext.tbCitas.Remove(tbCita);
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
