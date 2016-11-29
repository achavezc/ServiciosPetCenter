using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response
{
    [DataContract]
    public class ObtenerSolicitudResponseDTO : ResponseBaseDTO
    {
        public ObtenerSolicitudResponseDTO()
        {
            this.Result = new Result();
            this.ListaMantenimientos = new List<MantenimientoDTO>();
        }
        [DataMember(Order = 0)]
        public int CodigoSolicitud { get; set; }
        [DataMember(Order = 1)]
        public string DescripcionSolicitud { get; set; }
        [DataMember(Order = 2)]
        public DateTime FechaSolicitud { get; set; }
        [DataMember(Order = 3)]
        public int CodigoEstadoSolicitud { get; set; }
        [DataMember(Order = 4)]
        public string DescripcionEstadoSolicitud { get; set; }

        [DataMember(Order = 5)]
        public int CodigoSede { get; set; }
        [DataMember(Order = 6)]
        public string DescripcionSedeSolicitud { get; set; }

        [DataMember(Order = 7)]
        public int CodigoArea { get; set; }
        [DataMember(Order = 8)]
        public string DescripcionAreaSolicitud { get; set; }
        [DataMember(Order = 9)]
        public int CodigoTipoMantenimiento { get; set; }
        [DataMember(Order = 10)]
        public string DescripcionTipoMantenimiento { get; set; }
        [DataMember(Order = 11)]
        public int CodigoEmpleadoRegistra { get; set; }
        [DataMember(Order = 12)]
        public string NombreEmpleadoRegistra { get; set; }
        [DataMember(Order = 13)]
        public int CodigoEmpleadoAprueba { get; set; }
        [DataMember(Order = 14)]
        public string NombreEmpleadoAprueba { get; set; }
        [DataMember(Order = 15)]
        public string UsuarioCreacion { get; set; }
        [DataMember(Order = 16)]
        public DateTime FechaHoraCreacion { get; set; }
        [DataMember(Order = 17)]
        public string UsuarioActualizacion { get; set; }
        [DataMember(Order = 18)]
        public DateTime FechaHoraActualizacion { get; set; }
        [DataMember(Order = 19)]
        public List<MantenimientoDTO> ListaMantenimientos { get; set; }

    }
}
