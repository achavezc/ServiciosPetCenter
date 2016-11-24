using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response;
using PETCENTER.MANTENIMIENTO.Entidades.UsuarioSeguridad;
using PETCENTER.MANTENIMIENTO.Framework;

namespace PETCENTER.MANTENIMIENTO.AgenteServicios.Seguridad
{
    public class SeguridadProxy : ProxyBaseRest
    {
        public ResponseInfoBasicaUsuarioDTO ListarUsuarios(RequestInfoBasicaUsuarioDTO request)
        {
            var response = DeserializarJSON<RequestInfoBasicaUsuarioDTO, ResponseInfoBasicaUsuarioDTO>(request, WebConfigReader.ServicesHost.SeguridadInfoUsuario);
            if (response == null)
                return new ResponseInfoBasicaUsuarioDTO { Result = new Result { Mensaje = "Servicio no disponible." } };

            return response;
        }

        public ResponseCambioClaveDTO CambiarClaveWeb(RequestCambioClaveDTO request)
        {
            var response = DeserializarJSON<RequestCambioClaveDTO, ResponseCambioClaveDTO>(request, WebConfigReader.ServicesHost.SeguridadCambiarClaveWeb);
            if (response == null)
                return new ResponseCambioClaveDTO { Result = new Result { Mensaje = "Servicio no disponible." } };

            return response;
        }

    }
}
