using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.AcuerdoComercial;
using TRAMARSA.RECLAMOS.DTO;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Tarifa.Response;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Response;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion.Response;

namespace TRAMARSA.RECLAMOS.ServicioWCF.ACUERDOCOMERCIAL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILiberacionBLServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAcuerdoComercialServicio
    {
        
     

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/ConsultarClienteCorreo", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ConsultaClienteCorreoResponseDTO ConsultarClienteCorreo(List<ConsultaClienteCorreoDTO> request);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/ConsultarContenedoresNoDevueltos", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ConsultaContenedoresNoDevueltosResponseDTO ConsultarContenedoresNoDevueltos(ConsultaContenedoresNoDevueltosRequestDTO request);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/NotificarContenedoresNoDevueltos", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //NotificarContenedoresNoDevueltosResponseDTO NotificarContenedoresNoDevueltos(string codigoLinea);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/ConsultarDetalleContenedoresNoDevueltos", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ConsultaDetalleContenedorNoDevueltoDTO ConsultarDetalleContenedoresNoDevueltos(ConsultaContenedoresNoDevueltosRequestDTO request);

        
 
    }
}
