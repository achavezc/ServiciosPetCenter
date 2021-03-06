﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.LogicaNegocio;
using Newtonsoft.Json;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales;
using PETCENTER.MANTENIMIENTO.DTO.Core.Response;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using PETCENTER.MANTENIMIENTO.DTO.Core.Request;
using System.Reflection;
using System.ServiceModel.Activation;
using AutoMapper;
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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MaestroServicio : IMaestroServicio
    {
        
        public Result LimpiarCache()
        {
            var oResult = new Result();
            try
            {
                foreach (var value in Enum.GetValues(typeof(KeyCache)))
                {
                    ManejadorCache manejadorCache = new ManejadorCache();
                    manejadorCache.EliminarValorCache(value.ToString());
                    oResult.Mensajes.Add(new Result()
                    {
                        Mensaje = value.ToString()
                    });
                }
                oResult.Satisfactorio = true;
                oResult.Mensaje = "El caché se ha limpiado correctamente. Revise la lista de mensajes donde figura las variables eliminadas.";
                return oResult;
            }
            catch (ResultException ex)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, ex.Result.Mensaje));
                oResult.Satisfactorio=false;
                oResult.Mensaje="Ocurrio un problema interno en el servicio";
            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
                oResult.Satisfactorio = false;
                oResult.Mensaje = "Ocurrio un problema interno en el servicio";
            }
            return oResult;
        }
        
        public Result GetResult(Result result)
        {
            try
            {
                return new Result { Satisfactorio = true };
            }
            catch (Exception)
            {
                return new Result { Satisfactorio = false };
            }

        }

        public ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento()
        {
            ConsultarTipoMantenimientoResponseDTO response = new ConsultarTipoMantenimientoResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarTipoMantenimiento();

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

        public ConsultarEstadoSolicitudResponseDTO ConsultarEstadoSolicitud()
        {
            ConsultarEstadoSolicitudResponseDTO response = new ConsultarEstadoSolicitudResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarEstadoSolicitud ();

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

        public ConsultarEstadoFichaMantenimientoResponseDTO ConsultarEstadoFichaMantenimiento()
        {
            ConsultarEstadoFichaMantenimientoResponseDTO response = new ConsultarEstadoFichaMantenimientoResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarEstadoFichaMantenimiento();

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

        public ConsultarSedeResponseDTO ConsultarSede()
        {
            ConsultarSedeResponseDTO response = new ConsultarSedeResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarSede();

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

        public ConsultarAreaResponseDTO ConsultarArea()
        {
            ConsultarAreaResponseDTO response = new ConsultarAreaResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarArea();

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


        public ConsultarActividadResponseDTO ConsultarActividades(ConsultarActividadesRequestDTO request)
        {
            ConsultarActividadResponseDTO response = new ConsultarActividadResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarActividad(request);

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

        public ConsultarMaterialResponseDTO ConsultarMateriales(ConsultarMaterialesRequestDTO request)
        {
            ConsultarMaterialResponseDTO response = new ConsultarMaterialResponseDTO();
            try
            {
                MaestrosBL maestrosBL = new MaestrosBL();
                response = maestrosBL.ConsultarMaterial (request);

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
