using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoSolicitud.Response
{
    [DataContract]
    public class ConsultarEstadoSolicitudResponseDTO : ResponseBaseDTO
    {

        public ConsultarEstadoSolicitudResponseDTO()
        {
            this.Result = new Result();
            this.EstadoSilicitudList = new List<EstadoSolicitudDTO>();
        }

        [DataMember(Order = 0)]
        public List<EstadoSolicitudDTO> EstadoSilicitudList { get; set; }

    }
}
