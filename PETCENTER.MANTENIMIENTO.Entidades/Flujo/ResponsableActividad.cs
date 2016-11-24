using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Reclamos
{
    public partial class ResponsableActividad
    { 
        public int CodigoResponsableActividad { get; set; }

        public int CodigoActividad { get; set; }
         
        public string CodigoTipoResponsable { get; set; }
         
        public string Nombre { get; set; }
         
        public string UsuarioCreacion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }
         
        public string UsuarioActualizacion { get; set; }

        public DateTime? FechaHoraActualizacion { get; set; }

        public bool EstadoRegistro { get; set; }
         
    }
}
