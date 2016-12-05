using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Response
{
    [DataContract]
    public class ConsultarMantenimientoResponseDTO : ResponsePaginacionBaseDTO 
    {
        
        public ConsultarMantenimientoResponseDTO()
            {
                this.Result = new Result();
                this.MantenimientoList = new List<MantenimientoDTO>();
            }
        [DataMember(Order = 0)]
        public List<MantenimientoDTO> MantenimientoList { get; set; }
    }
}
