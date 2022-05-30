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
    public class PacienteController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Paciente
        public ActionResult Index()
        {
            var tbpacientes = db.Tbpacientes.Include(t => t.tbDUENO).Include(t => t.tbEmpleado).Include(t => t.tbespecie);
            return View(tbpacientes.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbpaciente tbpaciente = db.Tbpacientes.Find(id);
            if (tbpaciente == null)
            {
                return HttpNotFound();
            }
            return View(tbpaciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.cod_dueno = new SelectList(db.tbDUENOes, "cod_dueno", "nombre");
            ViewBag.cod_medico = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE");
            ViewBag.cod_especie = new SelectList(db.tbespecies, "cod_especie", "nombre");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_paciente,nombre,fecha_nac,cod_especie,cod_dueno,cod_medico")] Tbpaciente tbpaciente)
        {
            if (ModelState.IsValid)
            {
                db.Tbpacientes.Add(tbpaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_dueno = new SelectList(db.tbDUENOes, "cod_dueno", "nombre", tbpaciente.cod_dueno);
            ViewBag.cod_medico = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbpaciente.cod_medico);
            ViewBag.cod_especie = new SelectList(db.tbespecies, "cod_especie", "nombre", tbpaciente.cod_especie);
            return View(tbpaciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbpaciente tbpaciente = db.Tbpacientes.Find(id);
            if (tbpaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dueno = new SelectList(db.tbDUENOes, "cod_dueno", "nombre", tbpaciente.cod_dueno);
            ViewBag.cod_medico = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbpaciente.cod_medico);
            ViewBag.cod_especie = new SelectList(db.tbespecies, "cod_especie", "nombre", tbpaciente.cod_especie);
            return View(tbpaciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_paciente,nombre,fecha_nac,cod_especie,cod_dueno,cod_medico")] Tbpaciente tbpaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbpaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dueno = new SelectList(db.tbDUENOes, "cod_dueno", "nombre", tbpaciente.cod_dueno);
            ViewBag.cod_medico = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbpaciente.cod_medico);
            ViewBag.cod_especie = new SelectList(db.tbespecies, "cod_especie", "nombre", tbpaciente.cod_especie);
            return View(tbpaciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbpaciente tbpaciente = db.Tbpacientes.Find(id);
            if (tbpaciente == null)
            {
                return HttpNotFound();
            }
            return View(tbpaciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbpaciente tbpaciente = db.Tbpacientes.Find(id);
            db.Tbpacientes.Remove(tbpaciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
