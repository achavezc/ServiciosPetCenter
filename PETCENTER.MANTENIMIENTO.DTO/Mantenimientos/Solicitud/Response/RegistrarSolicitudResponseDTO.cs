using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response
{
    public class RegistrarSolicitudResponseDTO : ResponseBaseDTO
    {
        public RegistrarSolicitudResponseDTO()
        {
            this.Result = new Result();
        }
    }
}
