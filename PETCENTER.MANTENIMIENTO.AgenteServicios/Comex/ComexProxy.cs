using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Request;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Response;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response;
using PETCENTER.MANTENIMIENTO.Entidades.UsuarioSeguridad;
using PETCENTER.MANTENIMIENTO.Framework;

namespace PETCENTER.MANTENIMIENTO.AgenteServicios.Comex
{
    public class ComexProxy : ProxyBaseRest
    {
        public ResponseConsultaRolesClientesSapDTO ObtenerRolCliente()
        {

            RequestRolesClientesSAPDTO request = new RequestRolesClientesSAPDTO();
            request.codigo = new Codigo { SociedadPropietaria = WebConfigReader.Ambiente.SociedadPropietaria };

            var response = DeserializarJSON<RequestRolesClientesSAPDTO, ResponseConsultaRolesClientesSapDTO>(request, WebConfigReader.ServicesHost.ComexRolCliente);
            if (response == null)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("El servicio: {0} no esta disponible o tiene un formato no válido", WebConfigReader.ServicesHost.ComexRolCliente));
                return new ResponseConsultaRolesClientesSapDTO();
            }

            return response;
        }
    }
}
