using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales.Response
{
    [DataContract ]
   public  class ConsultarMaterialResponseDTO: ResponseBaseDTO 
    {
        public ConsultarMaterialResponseDTO()
        {
            this.Result = new Result();
            this.MaterialList = new List<MaterialDTO>();
        }

        [DataMember(Order = 0)]
       public List<MaterialDTO> MaterialList { get; set; }
    }
}
