using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Core;
using PETCENTER.MANTENIMIENTO.DTO.Core.Request;
using PETCENTER.MANTENIMIENTO.DTO.Core.Response;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Request;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoSolicitud.Response;
using PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoSolicitud;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Sede.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Area.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Sede;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Area;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoFichaMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.EstadoFichaMantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Materiales;

namespace PETCENTER.MANTENIMIENTO.LogicaNegocio
{

    public class MaestrosBL
    {        

        //mantenimineto
        public ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento()
        {

            ConsultarTipoMantenimientoResponseDTO result = new ConsultarTipoMantenimientoResponseDTO();
            List<TipoMantenimiento> lstDatos = new List<TipoMantenimiento>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.Sede);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<TipoMantenimiento>>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioTipoMantenimiento(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarTipoMantenimiento();
                }

                result.TipoMantenimientoList = (from Origen in lstDatos
                                                select Helper.MiMapper<TipoMantenimiento, TipoMantenimientoDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarEstadoSolicitudResponseDTO ConsultarEstadoSolicitud()
        {

            ConsultarEstadoSolicitudResponseDTO result = new ConsultarEstadoSolicitudResponseDTO();
            List<EstadoSolicitud> lstDatos = new List<EstadoSolicitud>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.EstadoSolicitud);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<EstadoSolicitud >>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioEstadoSolicitud(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarEstadoSolicitud();
                }

                result.EstadoSilicitudList = (from Origen in lstDatos
                                              select Helper.MiMapper<EstadoSolicitud, EstadoSolicitudDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarEstadoFichaMantenimientoResponseDTO ConsultarEstadoFichaMantenimiento()
        {

            ConsultarEstadoFichaMantenimientoResponseDTO result = new ConsultarEstadoFichaMantenimientoResponseDTO();
            List<EstadoFichaMantenimiento> lstDatos = new List<EstadoFichaMantenimiento>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.EstadoSolicitud);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<EstadoFichaMantenimiento>>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioEstadoFichaMantenimiento(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarEstadoFichaMantenimiento();
                }

                result.EstadoFichaMatenimientoList= (from Origen in lstDatos
                                                     select Helper.MiMapper<EstadoFichaMantenimiento, EstadoFichaMantenimientoDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarSedeResponseDTO ConsultarSede()
        {

            ConsultarSedeResponseDTO result = new ConsultarSedeResponseDTO();
            List<Sede > lstDatos = new List<Sede>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.Sede);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<Sede>>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioSede(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarSede ();
                }

                result.SedeList = (from Origen in lstDatos
                                              select Helper.MiMapper<Sede, SedeDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarAreaResponseDTO ConsultarArea()
        {

            ConsultarAreaResponseDTO result = new ConsultarAreaResponseDTO();
            List<Area> lstDatos = new List<Area >();

            try
            {
                string keyCache = Convert.ToString(KeyCache.Area);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<Area>>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioArea (contextoParaBaseDatos);
                    lstDatos = repo.ConsultarArea();
                }

                result.AreaList = (from Origen in lstDatos
                                              select Helper.MiMapper<Area , AreaDTO >(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarActividadResponseDTO ConsultarActividad(ConsultarActividadesRequestDTO request)
        {

            ConsultarActividadResponseDTO result = new ConsultarActividadResponseDTO();
            List<Actividad> lstDatos = new List<Actividad>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.Sede);

                //ManejadorCache manejadorCache = new ManejadorCache();

                //lstDatos = manejadorCache.ObtenerValorCache<List<Actividad >>(keyCache);

                //if (lstDatos == null || lstDatos.Count == 0)
                //{
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioActividad(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarActividad(request);
                //}

                result.ActividadList = (from Origen in lstDatos
                                   select Helper.MiMapper<Actividad, ActividadDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }

        public ConsultarMaterialResponseDTO ConsultarMaterial(ConsultarMaterialesRequestDTO request)
        {

            ConsultarMaterialResponseDTO result = new ConsultarMaterialResponseDTO();
            List<Material> lstDatos = new List<Material>();

            try
            {
                
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioMaterial(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarMaterial(request);
                

                result.MaterialList  = (from Origen in lstDatos
                                   select Helper.MiMapper<Material , MaterialDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }
    }
}

