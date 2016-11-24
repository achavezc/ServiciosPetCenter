using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Core.Response
{

    [DataContract]
    public class ActualizarParametroNegocioResponseDTO : ResponseBaseDTO
	{
        public ActualizarParametroNegocioResponseDTO()
        {
            this.Result = new Result();
        }
    }
}