using System;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PuntoEncuentro.Entidades;
using PuntoEncuentro.Helpers;
using PuntoEncuentro.Models;

namespace PuntoEncuentro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModelo usuarioModelo)
        {
            // Si el modelo esta ok
            if (!ModelState.IsValid) return RedirectToAction("Index", "Login");
            var usuario = new Usuario();
            using (PUNTO_ENCUENTRO_Entidades contexto = new PUNTO_ENCUENTRO_Entidades())
            {
                try
                {
                    var consultaUsusrio = (from uc in contexto.t_UsuarioLogin
                                           join us in contexto.t_Usuarios on uc.IdNumUsuario equals us.numIdUsuario
                                           where uc.Contrasena == usuarioModelo.InputPassword &&
                                                 uc.UsuarioLogin == usuarioModelo.InputUsuario
                                           select new
                                           {
                                               us.numIdUsuario,
                                               us.primerNombre,
                                               us.primerApellido,
                                           }).ToList();

                    if (consultaUsusrio.Any())
                    {
                        usuario.Nombre = consultaUsusrio[0].primerNombre;
                        usuario.Apellido = consultaUsusrio[0].primerApellido;
                        Session["Ususario"] = usuario;
                        return RedirectToAction("Index", "Usuarios");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario y/o Contraseña no encontados");
                    }

             
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message + " -- -- " + ex.StackTrace);
                }
            }

            return View();
        }
    }
}