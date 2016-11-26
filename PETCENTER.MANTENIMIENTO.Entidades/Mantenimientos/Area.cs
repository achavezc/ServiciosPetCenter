using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos
{
   public  class Area
    {

        public int CodigoArea { get; set; }
        public int CodigoSede { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public String UsuarioActualizacion { get; set; }
        public DateTime FechaHoraActualizacion { get; set; }
        public Boolean EstadoRegistro { get; set; }
    }
}
