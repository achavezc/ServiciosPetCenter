using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Reclamos
{
    public partial class Actividad
    {
         
        public int CodigoActividad { get; set; }

        public int CodigoFlujo { get; set; }

        public int Nivel { get; set; }
         
        public string Nombre { get; set; }
         
        public string Descripcion { get; set; }

        public int? CodigoArea { get; set; }

        public decimal? AplicarMontoMayorA { get; set; }

        public decimal? AplicarMontoMenorA { get; set; }
         
        public string CodigoMoneda { get; set; }

        public int? CodigoNotificacion { get; set; }

        public string CodigoEstadoDocumento { get; set; }

        public bool IntegracionFacturacion { get; set; }

        public bool AprobacionAutomatica { get; set; }
         
        public string UsuarioCreacion { get; set; }

        public DateTime FechaHoraCreacion { get; set; }
         
        public string UsuarioActualizacion { get; set; }

        public DateTime? FechaHoraActualizacion { get; set; }

        public bool EstadoRegistro { get; set; }
         
         
    }
}
