using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Flujo
{
    public class Notificacion
    {
        public int CodigoNotificacion { get; set; }
        public int CodigoSociedad { get; set; }
        public int CodigoNegocio { get; set; }
        public int CodigoSede { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }
        public bool EstadoRegistro { get; set; }
        public string ConCopia { get; set; }
    }
}
