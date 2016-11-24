using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request
{
    [DataContract]
    public class CambiarClaveUsuarioRequestDTO
    {
        [DataMember(Order=0)]
        public string Usuario { get; set; }

        [DataMember(Order = 1)]
        public string ClaveAnterior { get; set; }

        [DataMember(Order = 2)]
        public string ClaveNueva { get; set; }

        [DataMember(Order = 3)]
        public string AcronimoAplicacion { get; set; }

        [DataMember(Order = 4)]
        public string DominioAplicacion { get; set; }

    }
}
