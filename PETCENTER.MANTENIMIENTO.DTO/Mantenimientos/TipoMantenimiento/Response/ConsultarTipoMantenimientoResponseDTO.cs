using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento.Response
{
    [DataContract]
    public class ConsultarTipoMantenimientoResponseDTO : ResponseBaseDTO
    {
        public ConsultarTipoMantenimientoResponseDTO()
        {
            this.Result = new Result();
            this.TipoMantenimientoList = new List<TipoMantenimientoDTO >();
        }

        [DataMember(Order = 0)]
        public List<TipoMantenimientoDTO> TipoMantenimientoList { get; set; }
    }
}
