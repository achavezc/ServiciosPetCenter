using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Response
{
    [DataContract]
    public class ConsultarFichaMantenimientoResponseDTO :ResponsePaginacionBaseDTO 
    {
        public ConsultarFichaMantenimientoResponseDTO()
            {
                this.Result = new Result();
                this.FichaMantenimientoList = new List<FichaMantenimientoDTO>();
            }
        [DataMember(Order = 0)]
        public List<FichaMantenimientoDTO > FichaMantenimientoList { get; set; }
    }
}
