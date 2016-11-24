//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response
{
    [DataContract]
    public class ConsultarSolicitudResponseDTO : ResponsePaginacionBaseDTO
    {
        public ConsultarSolicitudResponseDTO()
            {
                this.Result = new Result();
                this.SolicitudList = new List<SolicitudDTO>();
            }
        [DataMember(Order = 0)]
        public List<SolicitudDTO> SolicitudList { get; set; }
       
    }
}
