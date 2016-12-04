using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos
{
   public  class ActividadxFichaMantenimiento
    {
        public int CodigoActividadxFichaMantenimiento { get; set; }
        public string Descripcion { get; set; }
        public int CodigoFichaMantenimiento { get; set; }
        public int CodigoActividad { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaHoraActualizacion{ get; set; }
        public Boolean EstadoRegistro { get; set; }
       public string DescripcionActividad {get;set;}

    }
}
