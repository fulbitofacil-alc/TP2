using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PS.Web.Areas.Prestadora.Models;
using PS.Web.Models;
using PS.DAL;
using System.Data.Entity.Validation;

namespace PS.Web.Areas.Prestadora.Controllers
{
    public class GestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prestadora/Gestion
        public ActionResult Index()
        {
            return View(db.Prestadoras.ToList());
        }

        // GET: Prestadora/Gestion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestadoraViewModel prestadoraViewModel = db.Prestadoras.Find(id);
            if (prestadoraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(prestadoraViewModel);
        }

        // GET: Prestadora/Gestion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestadora/Gestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUC,Nombre,Direccion,Tipo,TelefonoContacto,Representante,Observaciones")] PrestadoraViewModel prestadoraViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tipo = db.TiposPrestadora.FirstOrDefault(x => x.Id == prestadoraViewModel.Tipo.Id);

                    var prestadora = db.Prestadoras.FirstOrDefault(x => x.RUC == prestadoraViewModel.RUC);
                    prestadora.Tipo = tipo;
                    prestadora.TelefonoContacto = prestadoraViewModel.TelefonoContacto;
                    prestadora.Representante = prestadoraViewModel.Representante;

                    var solicitudAfiliacion = db.SolicitudesAfiliacion.FirstOrDefault(x => x.Prestadora.RUC == prestadora.RUC);
                    if (solicitudAfiliacion == null)
                    {
                        solicitudAfiliacion = new SolicitudAfiliacion() { FechaIngreso = DateTime.Today, Prestadora = prestadora, Observaciones = prestadoraViewModel.Observaciones };
                        db.SolicitudesAfiliacion.Add(solicitudAfiliacion);
                        db.SaveChanges();
                        return View("Confirmacion");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ya se creó una solicitud de afiliación para dicha prestadora.");
                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }


            }

            return View(prestadoraViewModel);
        }

        // GET: Prestadora/Gestion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestadoraViewModel prestadoraViewModel = db.Prestadoras.Find(id);
            if (prestadoraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(prestadoraViewModel);
        }

        // POST: Prestadora/Gestion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RUC,Nombre,Direccion,TelefonoContacto,Representante")] PrestadoraViewModel prestadoraViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestadoraViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prestadoraViewModel);
        }

        // GET: Prestadora/Gestion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestadoraViewModel prestadoraViewModel = db.Prestadoras.Find(id);
            if (prestadoraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(prestadoraViewModel);
        }

        // POST: Prestadora/Gestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrestadoraViewModel prestadoraViewModel = db.Prestadoras.Find(id);
            db.Prestadoras.Remove(prestadoraViewModel);
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

        [HttpGet]
        public ActionResult ValidarRUC(string RUC)
        {
            var prestadoraInvitada = db.Invitaciones.FirstOrDefault(x => x.Prestadora.RUC == RUC);

            if (prestadoraInvitada != null)
            {
                var prestadora = prestadoraInvitada.Prestadora;
                return Json(prestadora, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
