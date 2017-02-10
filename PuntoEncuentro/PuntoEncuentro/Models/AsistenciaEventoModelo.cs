using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PuntoEncuentro.Entidades;

namespace PuntoEncuentro.Models
{
    public class AsistenciaEventoModelo
    {
        public List<t_Usuarios> ListaUsuarios { get; set; }
        public List<t_Evento> ListaEventos { get; set; } 
    }
}