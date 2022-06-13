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
    public class TelefonoDuenoController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: TelefonoDueno
        public ActionResult Index()
        {
            var tbTelefonoDuenoes = db.TbTelefonoDuenoes.Include(t => t.tbDUENO);
            return View(tbTelefonoDuenoes.ToList());
        }

        // GET: TelefonoDueno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbTelefonoDueno tbTelefonoDueno = db.TbTelefonoDuenoes.Find(id);
            if (tbTelefonoDueno == null)
            {
                return HttpNotFound();
            }
            return View(tbTelefonoDueno);
        }

        // GET: TelefonoDueno/Create
        public ActionResult Create()
        {
            ViewBag.cod_dueno = new SelectList(db.TDueno, "cod_dueno", "nombre");
            return View();
        }

        // POST: TelefonoDueno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_dueno,telefono")] TbTelefonoDueno tbTelefonoDueno)
        {
            if (ModelState.IsValid)
            {
                db.TbTelefonoDuenoes.Add(tbTelefonoDueno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_dueno = new SelectList(db.TDueno, "cod_dueno", "nombre", tbTelefonoDueno.cod_dueno);
            return View(tbTelefonoDueno);
        }

        // GET: TelefonoDueno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbTelefonoDueno tbTelefonoDueno = db.TbTelefonoDuenoes.Find(id);
            if (tbTelefonoDueno == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dueno = new SelectList(db.TDueno, "cod_dueno", "nombre", tbTelefonoDueno.cod_dueno);
            return View(tbTelefonoDueno);
        }

        // POST: TelefonoDueno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_dueno,telefono")] TbTelefonoDueno tbTelefonoDueno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTelefonoDueno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dueno = new SelectList(db.TDueno, "cod_dueno", "nombre", tbTelefonoDueno.cod_dueno);
            return View(tbTelefonoDueno);
        }

        // GET: TelefonoDueno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbTelefonoDueno tbTelefonoDueno = db.TbTelefonoDuenoes.Find(id);
            if (tbTelefonoDueno == null)
            {
                return HttpNotFound();
            }
            return View(tbTelefonoDueno);
        }

        // POST: TelefonoDueno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TbTelefonoDueno tbTelefonoDueno = db.TbTelefonoDuenoes.Find(id);
            db.TbTelefonoDuenoes.Remove(tbTelefonoDueno);
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
