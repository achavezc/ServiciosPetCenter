using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Reclamos
{
    public partial class Tarea
    { 
        public int CodigoTarea { get; set; }
         
        public string Nombre { get; set; }
         
        public string Descripcion { get; set; }

        public int CodigoActividad { get; set; }

        public int CodigoReclamo { get; set; }
         
        public string CodigoEstadoDocumento { get; set; }
         
        public string CodigoEstado { get; set; }

        public DateTime FechaAsignacion { get; set; }
         
        public string UsuarioEjecucion { get; set; }

        public DateTime? FechaEjecucion { get; set; }
         
        public string UsuarioCreacion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }
         
        public string UsuarioActualizacion { get; set; }

        public DateTime? FechaHoraActualizacion { get; set; }

        public string Accion { get; set; }
    }
}
