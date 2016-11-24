using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response
{
    public class ResponseInfoBasicaUsuarioDTO
    {
        public ResponseInfoBasicaUsuarioDTO()
        {
            this.Result = new Result();
            this.ListaInfoBasicaUsuarios = new List<ResponseListaUsuarios>();
        }
        public List<ResponseListaUsuarios> ListaInfoBasicaUsuarios { get; set; }

        public Result Result { get; set; }
    }
}
