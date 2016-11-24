using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response
{
    public class ResponseCambioClaveDTO
    {
        public ResponseCambioClaveDTO()
        {
            this.Result = new Result();
        }

        public Result Result { get; set; }
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public string CodigoUsuario { get; set; }
    }
}
