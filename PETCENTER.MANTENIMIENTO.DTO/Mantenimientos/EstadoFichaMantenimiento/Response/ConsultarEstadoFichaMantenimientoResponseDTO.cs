using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoFichaMantenimiento.Response
{
    [DataContract]
    public class ConsultarEstadoFichaMantenimientoResponseDTO : ResponseBaseDTO
    {

        public ConsultarEstadoFichaMantenimientoResponseDTO()
        {
            this.Result = new Result();
            this.EstadoFichaMatenimientoList = new List<EstadoFichaMantenimientoDTO>();
        }

        [DataMember(Order = 0)]
        public List<EstadoFichaMantenimientoDTO > EstadoFichaMatenimientoList { get; set; }
    }
}
