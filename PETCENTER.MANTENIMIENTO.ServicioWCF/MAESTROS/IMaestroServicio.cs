﻿using System;
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
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoSolicitud.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Sede.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Area.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoFichaMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales.Request;

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

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarEstadoSolicitud", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarEstadoSolicitudResponseDTO ConsultarEstadoSolicitud();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarEstadoFichaMantenimiento", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarEstadoFichaMantenimientoResponseDTO ConsultarEstadoFichaMantenimiento();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarSede", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarSedeResponseDTO ConsultarSede();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarArea", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarAreaResponseDTO ConsultarArea();

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarActividades", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarActividadResponseDTO ConsultarActividades(ConsultarActividadesRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarMateriales", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarMaterialResponseDTO ConsultarMateriales(ConsultarMaterialesRequestDTO request);
        //[WebInvoke(UriTemplate = "/ConsultarArea", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento();
    }
}
