using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntoEncuentro.Entidades;

namespace PuntoEncuentro.Controllers
{
    public class EventoController : Controller
    {
        private PUNTO_ENCUENTRO_Entidades db = new PUNTO_ENCUENTRO_Entidades();

        // GET: Evento
        public async Task<ActionResult> Index()
        {
            return View(await db.t_Evento.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Evento t_Evento = await db.t_Evento.FindAsync(id);
            if (t_Evento == null)
            {
                return HttpNotFound();
            }
            return View(t_Evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEvento,NombreEvento,FechaInicio,HoraIncio,FechaFin,HoraFin")] t_Evento t_Evento)
        {
            if (ModelState.IsValid)
            {
                db.t_Evento.Add(t_Evento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_Evento);
        }

        // GET: Evento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Evento t_Evento = await db.t_Evento.FindAsync(id);
            if (t_Evento == null)
            {
                return HttpNotFound();
            }
            return View(t_Evento);
        }

        // POST: Evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEvento,NombreEvento,FechaInicio,HoraIncio,FechaFin,HoraFin")] t_Evento t_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_Evento);
        }

        // GET: Evento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Evento t_Evento = await db.t_Evento.FindAsync(id);
            if (t_Evento == null)
            {
                return HttpNotFound();
            }
            return View(t_Evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            t_Evento t_Evento = await db.t_Evento.FindAsync(id);
            db.t_Evento.Remove(t_Evento);
            await db.SaveChangesAsync();
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
