using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Response
{
    public class RegistrarFichaMantenimientoResponseDTO :ResponseBaseDTO 
    {

        public RegistrarFichaMantenimientoResponseDTO()
        {
            this.Result = new Result();
        }
    }
}
