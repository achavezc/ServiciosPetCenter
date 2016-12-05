using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Response;
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

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.FICHAMANTENIMIENTO
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FichaMantenimientoServicio" en el código y en el archivo de configuración a la vez.
    public class FichaMantenimientoServicio : IFichaMantenimientoServicio
    {

         
        public ConsultarFichaMantenimientoResponseDTO ConsultarFichaMantenimiento(ConsultarFichaMantenimientoRequestDTO request)
        {

            ManejadorLog manejadorLog = new ManejadorLog();

            manejadorLog.GrabarLog(request.FechaFin.ToString());
            manejadorLog.GrabarLog(request.FechaFin.ToString());

            ConsultarFichaMantenimientoResponseDTO result = new ConsultarFichaMantenimientoResponseDTO();
            try
            {
                FichaMantenimientoBL solicitud = new FichaMantenimientoBL();
                result = solicitud.ConsultarFichaMantenimeinto(request);
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

        public ConsultarMantenimientoResponseDTO ConsultarMantenimiento(ConsultarMantenimientoRequestDTO request)
        {

            ManejadorLog manejadorLog = new ManejadorLog();

            manejadorLog.GrabarLog(request.FechaFin.ToString());
            manejadorLog.GrabarLog(request.FechaFin.ToString());

            ConsultarMantenimientoResponseDTO result = new ConsultarMantenimientoResponseDTO();
            try
            {
                FichaMantenimientoBL mantenimiento = new FichaMantenimientoBL();
                result = mantenimiento.ConsultarMantenimiento(request);
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

   
        public ObtenerFichaMantenimientoResponseDTO ObtenerFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO request)
        {

            ObtenerFichaMantenimientoResponseDTO response = new ObtenerFichaMantenimientoResponseDTO();
            try
            {
                var ficha_mantenimientoBL = new FichaMantenimientoBL();
                response = ficha_mantenimientoBL.ObtenerFichaMantenimiento(request);


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


        public RegistrarFichaMantenimientoResponseDTO RegistrarFichaMantenimiento(RegistrarFichaMantenimientoRequestDTO request)
        {
            RegistrarFichaMantenimientoResponseDTO response = new RegistrarFichaMantenimientoResponseDTO();
            try
            {
                //Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var ficha_mantenimientoBL = new FichaMantenimientoBL();
                response = ficha_mantenimientoBL.RegistraFichaMantenimiento(request);
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
    }
}
