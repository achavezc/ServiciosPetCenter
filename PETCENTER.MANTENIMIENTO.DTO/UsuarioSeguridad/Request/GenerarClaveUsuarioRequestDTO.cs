using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request
{
    [DataContract]
    public class GenerarClaveUsuarioRequestDTO
    {
        [DataMember(Order=0)]
        public string Usuario { get; set; }

        [DataMember(Order = 1)]
        public string AcronimoAplicacion { get; set; }

        [DataMember(Order = 2)]
        public string DominioAplicacion { get; set; }
    }
}
