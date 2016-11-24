using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
using PETCENTER.MANTENIMIENTO.DTO.Core.Request;
using PETCENTER.MANTENIMIENTO.DTO.Core.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento.Response;

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.MAESTROS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILiberacionBLServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaestroServicio
    {
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetResult", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result GetResult(Result result);


        [OperationContract]
        [WebInvoke(UriTemplate = "/LimpiarCache", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result LimpiarCache();  


        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarTipoMantenimiento", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento();

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/ConsultarArea", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento();
    }
}
