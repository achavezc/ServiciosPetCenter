using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.SOLICITUDMANTENIMIENTO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISolicitudMantenimientoServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISolicitudMantenimientoServicio
    {
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarSolicitud", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarSolicitudResponseDTO ConsultarSolicitud(ConsultarSolicitudRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarSolicitud", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RegistrarSolicitudResponseDTO RegistrarSolicitud(RegistrarSolicitudRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerSolicitud", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObtenerSolicitudResponseDTO ObtenerSolicitud(ObtenerSolicitudRequestDTO request);
    }
}
