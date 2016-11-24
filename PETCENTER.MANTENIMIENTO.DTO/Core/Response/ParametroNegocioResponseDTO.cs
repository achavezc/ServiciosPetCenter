using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Core.Response
{

    [DataContract]
    public class ParametroNegocioResponseDTO : ResponseBaseDTO
	{
        public ParametroNegocioResponseDTO()
        {
            this.Result = new Result();
            this.ParametrosNegocioList = new List<ParametroNegocioDTO>();
        }

        [DataMember(Order = 0)]
        public List<ParametroNegocioDTO> ParametrosNegocioList { get; set; }
	}
}