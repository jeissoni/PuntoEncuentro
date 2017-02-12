using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PuntoEncuentro.Entidades;

namespace PuntoEncuentro.Models
{
    public class ListaAsistenciaEventoModelo
    {
        public List<t_Usuarios> ListaUsuarios { get; set; }
        public List<t_Evento> ListaEventos { get; set; }
        public int IdEvento { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistra { get; set; }
    }
}