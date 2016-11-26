using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Area.Response
{
    [DataContract]
    public class ConsultarAreaResponseDTO:ResponseBaseDTO 

    {
        public ConsultarAreaResponseDTO()
        {
            this.Result = new Result();
            this.AreaList = new List<AreaDTO>();
        }

        [DataMember(Order = 0)]
        public List<AreaDTO > AreaList { get; set; }
    }
}
