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
    public class UsuariosController : Controller
    {
        private PUNTO_ENCUENTRO_Entidades db = new PUNTO_ENCUENTRO_Entidades();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            try
            {
                if (!String.IsNullOrEmpty(Session["Ususario"].ToString()))
                {
                    var t_Usuarios = db.t_Usuarios.Include(t => t.t_EstadoCivil).Include(t => t.t_TipoSexo);
                    return View(await t_Usuarios.ToListAsync());
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }

        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Usuarios t_Usuarios = await db.t_Usuarios.FindAsync(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(t_Usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.EstadoCivil = new SelectList(db.t_EstadoCivil, "IdEstadoCivil", "NombreEstadoCivil");
            ViewBag.Sexo = new SelectList(db.t_TipoSexo, "IdTipoSexo", "NombreTipoSexo");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "numIdUsuario,tipoIdNumUsuario,primerNombre,segundoNombre,primerApellido,segundoApellido,tipoUsuario,fechaNacimiento,Celular,NumeroFijo,CorreoElectronico,Ocupacion,Sexo,EstadoCivil")] t_Usuarios t_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.t_Usuarios.Add(t_Usuarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoCivil = new SelectList(db.t_EstadoCivil, "IdEstadoCivil", "NombreEstadoCivil", t_Usuarios.EstadoCivil);
            ViewBag.Sexo = new SelectList(db.t_TipoSexo, "IdTipoSexo", "NombreTipoSexo", t_Usuarios.Sexo);
            ViewBag.tipoUsuario = new SelectList(db.t_TipoUsuario, "Id", "Nombre", t_Usuarios.tipoUsuario);
            return View(t_Usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Usuarios t_Usuarios = await db.t_Usuarios.FindAsync(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoCivil = new SelectList(db.t_EstadoCivil, "IdEstadoCivil", "NombreEstadoCivil", t_Usuarios.EstadoCivil);
            ViewBag.Sexo = new SelectList(db.t_TipoSexo, "IdTipoSexo", "NombreTipoSexo", t_Usuarios.Sexo);
            ViewBag.tipoUsuario = new SelectList(db.t_TipoUsuario, "Id", "Nombre", t_Usuarios.tipoUsuario);
            return View(t_Usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "numIdUsuario,tipoIdNumUsuario,primerNombre,segundoNombre,primerApellido,segundoApellido,tipoUsuario,fechaNacimiento,Celular,NumeroFijo,CorreoElectronico,Ocupacion,Sexo,EstadoCivil")] t_Usuarios t_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Usuarios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoCivil = new SelectList(db.t_EstadoCivil, "IdEstadoCivil", "NombreEstadoCivil", t_Usuarios.EstadoCivil);
            ViewBag.Sexo = new SelectList(db.t_TipoSexo, "IdTipoSexo", "NombreTipoSexo", t_Usuarios.Sexo);
            ViewBag.tipoUsuario = new SelectList(db.t_TipoUsuario, "Id","Nombre",t_Usuarios.tipoUsuario);
            return View(t_Usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Usuarios t_Usuarios = await db.t_Usuarios.FindAsync(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(t_Usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            t_Usuarios t_Usuarios = await db.t_Usuarios.FindAsync(id);
            db.t_Usuarios.Remove(t_Usuarios);
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
