using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Response
{
    [DataContract ]
   public  class ConsultarActividadResponseDTO: ResponseBaseDTO 
    {
       public ConsultarActividadResponseDTO()
        {
            this.Result = new Result();
            this.ActividadList = new List<ActividadDTO>();
        }

        [DataMember(Order = 0)]
       public List<ActividadDTO> ActividadList { get; set; }
    }
}
