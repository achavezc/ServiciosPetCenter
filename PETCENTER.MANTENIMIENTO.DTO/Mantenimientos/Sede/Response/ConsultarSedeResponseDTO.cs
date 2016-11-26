using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Sede.Response
{
    [DataContract ]
    public class ConsultarSedeResponseDTO :ResponseBaseDTO 
    {

        public ConsultarSedeResponseDTO()
        {
            this.Result = new Result();
            this.SedeList = new List<SedeDTO >();
        }

        [DataMember(Order = 0)]
        public List<SedeDTO > SedeList { get; set; }

    }
}
