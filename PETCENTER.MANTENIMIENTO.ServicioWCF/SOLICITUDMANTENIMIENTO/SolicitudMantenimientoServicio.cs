using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.LogicaNegocio.MANTENIMIETO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.SOLICITUDMANTENIMIENTO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SolicitudMantenimientoServicio" en el código y en el archivo de configuración a la vez.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SolicitudMantenimientoServicio : ISolicitudMantenimientoServicio 
    {
        public ConsultarSolicitudResponseDTO ConsultarSolicitud(ConsultarSolicitudRequestDTO request)
        {
            ConsultarSolicitudResponseDTO result = new ConsultarSolicitudResponseDTO();
            try
            {
                SolicitudBL solicitud = new SolicitudBL();
                result = solicitud.ConsultarSolicitud(request);
            }
            catch (ResultException ex)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name,
                    ex.Result.Mensaje));
                ex.Result.Satisfactorio = false;
                result.Result = ex.Result;

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                result.Result = new Result
                {
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio",
                    IdError = Guid.NewGuid()
                };

            }
            return result;
        }

        public RegistrarSolicitudResponseDTO RegistrarSolicitud(RegistrarSolicitudRequestDTO request)
        {

            RegistrarSolicitudResponseDTO response = new RegistrarSolicitudResponseDTO();
            try
            {
                //Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var solicitudBL = new SolicitudBL();
                response = solicitudBL.RegistraSolicitud(request);
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                response.Result = new Result
                {
                    Satisfactorio = false,
                    Mensaje = "Ocurrio un problema interno en el servicio",
                    IdError = Guid.NewGuid()
                };
            }
            return response;
        }

        public ObtenerSolicitudResponseDTO ObtenerSolicitud(ObtenerSolicitudRequestDTO request)
        {
            ObtenerSolicitudResponseDTO response = new ObtenerSolicitudResponseDTO();
            try
            {
                var solicitudBL = new SolicitudBL();
                response = solicitudBL.ObtenerSolicitud(request);


                return response;
            }
            catch (ResultException ex)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, ex.Result.Mensaje));
                ex.Result.Satisfactorio = false;
                response.Result = ex.Result;

                return response;
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                response.Result = new Result { Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio", IdError = Guid.NewGuid() };

                return response;
            }
        }
    }
}
