using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request
{
    public class RequestInfoBasicaUsuarioDTO2
    {
        public RequestInfoBasicaUsuarioDTO2()
        {
            this.Usuarios = new List<RequestUsuarioDTO>();
        }

        public List<RequestUsuarioDTO> Usuarios { get; set; }
    }
}
