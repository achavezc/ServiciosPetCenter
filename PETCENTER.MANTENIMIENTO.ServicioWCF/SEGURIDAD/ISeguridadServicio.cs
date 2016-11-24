using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PETCENTER.MANTENIMIENTO.DTO.Core.Response;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response;


namespace PETCENTER.MANTENIMIENTO.ServicioWCF.SEGURIDAD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILiberacionBLServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISeguridadServicio
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/GenerarClaveUsuario", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        GenerarClaveUsuarioResponseDTO GenerarClaveUsuario(GenerarClaveUsuarioRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/CambiarClaveUsuario", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CambiarClaveUsuarioResponseDTO CambiarClaveUsuario(CambiarClaveUsuarioRequestDTO request);
    }
}
