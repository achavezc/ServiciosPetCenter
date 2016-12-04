using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.FICHAMANTENIMIENTO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFichaMantenimientoServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFichaMantenimientoServicio
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ConsultarFichaMantenimieto", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ConsultarFichaMantenimientoResponseDTO ConsultarFichaMantenimieto(ConsultarFichaMantenimientoRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/RegistrarFichaMantenimiento", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RegistrarFichaMantenimientoResponseDTO RegistrarFichaMantenimiento(RegistrarFichaMantenimientoRequestDTO request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ObtenerFichaMantenimiento", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObtenerFichaMantenimientoResponseDTO ObtenerFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO request);
    }
}
