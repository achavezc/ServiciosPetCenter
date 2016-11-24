using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Reclamos
{
    public partial class ResponsableTarea
    { 
        public int CodigoResponsableTarea { get; set; }

        public int CodigoTarea { get; set; }
         
        public string Nombre { get; set; }
         
        public string CodigoEstado { get; set; }
         
        public string UsuarioRegistro { get; set; }

        public DateTime FechaHoraRegistro { get; set; }

        public string Accion { get; set; }
    }
}
