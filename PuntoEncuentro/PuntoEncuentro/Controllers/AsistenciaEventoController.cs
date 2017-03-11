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
    public class AsistenciaEventoController : Controller
    {
        private PUNTO_ENCUENTRO_Entidades db = new PUNTO_ENCUENTRO_Entidades();

        // GET: AsistenciaEvento
        public async Task<ActionResult> Index()
        {
            var t_AsistenciaEvento = db.t_AsistenciaEvento.Include(t => t.t_Evento).Include(t => t.t_Usuarios).Include(t => t.t_Usuarios1);
            return View(await t_AsistenciaEvento.ToListAsync());
        }

        // GET: AsistenciaEvento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_AsistenciaEvento t_AsistenciaEvento = await db.t_AsistenciaEvento.FindAsync(id);
            if (t_AsistenciaEvento == null)
            {
                return HttpNotFound();
            }
            return View(t_AsistenciaEvento);
        }

        // GET: AsistenciaEvento/Create
        public ActionResult Create()
        {
            ViewBag.IdEvento = new SelectList(db.t_Evento, "IdEvento", "NombreEvento");
            ViewBag.Usuario = db.t_Usuarios.ToList();
            //ViewBag.IdUsuario = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario");
            //ViewBag.IdUsuarioRegistra = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario");
            return View();
        }


        public ActionResult Registrar( string usu, string usuCrea, string evento)
        {
            var mire = evento;
            var otro1 = usu;
            var otro2 = usuCrea;
            return null;
        }

        // POST: AsistenciaEvento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEvento,IdUsuario,FechaRegistro,IdUsuarioRegistra")] t_AsistenciaEvento t_AsistenciaEvento)
        {
            if (ModelState.IsValid)
            {
                db.t_AsistenciaEvento.Add(t_AsistenciaEvento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEvento = new SelectList(db.t_Evento, "IdEvento", "NombreEvento", t_AsistenciaEvento.IdEvento);
            ViewBag.IdUsuario = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuario);
            ViewBag.IdUsuarioRegistra = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuarioRegistra);
            return View(t_AsistenciaEvento);
        }

        // GET: AsistenciaEvento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_AsistenciaEvento t_AsistenciaEvento = await db.t_AsistenciaEvento.FindAsync(id);
            if (t_AsistenciaEvento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEvento = new SelectList(db.t_Evento, "IdEvento", "NombreEvento", t_AsistenciaEvento.IdEvento);
            ViewBag.IdUsuario = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuario);
            ViewBag.IdUsuarioRegistra = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuarioRegistra);
            return View(t_AsistenciaEvento);
        }

        // POST: AsistenciaEvento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEvento,IdUsuario,FechaRegistro,IdUsuarioRegistra")] t_AsistenciaEvento t_AsistenciaEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_AsistenciaEvento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEvento = new SelectList(db.t_Evento, "IdEvento", "NombreEvento", t_AsistenciaEvento.IdEvento);
            ViewBag.IdUsuario = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuario);
            ViewBag.IdUsuarioRegistra = new SelectList(db.t_Usuarios, "numIdUsuario", "tipoIdNumUsuario", t_AsistenciaEvento.IdUsuarioRegistra);
            return View(t_AsistenciaEvento);
        }

        // GET: AsistenciaEvento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_AsistenciaEvento t_AsistenciaEvento = await db.t_AsistenciaEvento.FindAsync(id);
            if (t_AsistenciaEvento == null)
            {
                return HttpNotFound();
            }
            return View(t_AsistenciaEvento);
        }

        // POST: AsistenciaEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            t_AsistenciaEvento t_AsistenciaEvento = await db.t_AsistenciaEvento.FindAsync(id);
            db.t_AsistenciaEvento.Remove(t_AsistenciaEvento);
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
