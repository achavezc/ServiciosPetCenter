
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Response;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using PETCENTER.MANTENIMIENTO.Framework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

namespace PETCENTER.MANTENIMIENTO.LogicaNegocio.MANTENIMIETO
{
    public class SolicitudBL
    {
        public ConsultarSolicitudResponseDTO ConsultarSolicitud(ConsultarSolicitudRequestDTO req)
        {
            ConsultarSolicitudResponseDTO response = new ConsultarSolicitudResponseDTO();
            try
            {

                List<SolicitudDTO> lista_solicitud = new List<SolicitudDTO>();
                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioSolicitud(contextoParaBaseDatos);
                int totalRegistros, cantPaginas;
                lista_solicitud = repo.ConsultarSolicitud(req, out totalRegistros, out cantPaginas);

                response.SolicitudList = lista_solicitud;
                response.TotalRegistros = totalRegistros;
                response.CantidadPaginas = cantPaginas;

            }
            catch (Exception e)
            {
                response.Result = new Result { IdError = Guid.NewGuid(), Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio" };
                ManejadorExcepciones.PublicarExcepcion(e, PoliticaExcepcion.LogicaNegocio);
            }

            return response;
        }


        public RegistrarSolicitudResponseDTO RegistraSolicitud(RegistrarSolicitudRequestDTO request)
        {

            var response = new RegistrarSolicitudResponseDTO();
            var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Reclamos);
            var repo = new RepositorioSolicitud(contextoParaBaseDatos);
            int CodigoSolicitud = 0;

            Mapper.CreateMap<MantenimientoListDTO, MantenimientoList>();
            var requestBE = Helper.MiMapper<RegistrarSolicitudRequestDTO, RegistrarSolicitud>(request);

            requestBE.FechaHoraCreacion = DateTime.Now;

            //AdjuntarArchivo(request.ReclamoAdjuntoList);

            using (TransactionScope Transaccion = new TransactionScope())
            {
                CodigoSolicitud = repo.RegistrarSolicitud(requestBE);
                if (!CodigoSolicitud.Equals(0))
                {
                    ////Informacion Devolucion
                    //requestBE.MantenimientoList.CodigoSolicitud = CodigoSolicitud;
                    //requestBE.MantenimientoList.UsuarioCreacion = request.UsuarioRegistro;
                    //requestBE.MantenimientoList.FechaHoraCreacion = request.FechaHoraRegistro;
                    ////Informacion Devolucion

                    requestBE.MantenimientoList.ForEach(x =>
                    {
                        x.CodigoSolicitud  = CodigoSolicitud;
                        x.UsuarioCreacion  = requestBE.UsuarioCreacion ;
                        x.FechaHoraCreacion = request.FechaHoraRegistro;
                    });

                    repo.RegistrarMantenimientto(requestBE.MantenimientoList);

                }
                Transaccion.Complete();
            }
            return response;
        }


        public ObtenerSolicitudResponseDTO ObtenerSolicitud(ObtenerSolicitudRequestDTO req)
        {
            var lstDatos = new Solicitud();
            var lstDatosMantenimiento = new List<Mantenimiento>();
            var result = new ObtenerSolicitudResponseDTO();
            try
            {

                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioObtenerSolicitud(contextoParaBaseDatos);
                lstDatos = repo.ObtenerSolicitud(req);
                lstDatosMantenimiento = ObtenerMantenimientoSolicitud(req);

                result.CodigoSolicitud = lstDatos.CodigoSolicitud;
                result.DescripcionSolicitud = lstDatos.Descripcion ;
                result.FechaSolicitud = lstDatos.Fecha ;
                result.CodigoEstadoSolicitud = lstDatos.Estado;
                result.CodigoArea  = lstDatos.CodigoArea;
                result.CodigoTipoMantenimiento = lstDatos.CodigoTipoMantenimiento;
                result.CodigoEmpleadoRegistra = lstDatos.CodigoEmpleado1;
                result.CodigoEmpleadoAprueba = lstDatos.CodigoEmpleado2;

                result.UsuarioCreacion = lstDatos.UsuarioCreacion;
                result.FechaHoraCreacion = lstDatos.FechaHoraCreacion;
                result.UsuarioActualizacion = lstDatos.UsuarioActualizacion;
                result.FechaHoraActualizacion = lstDatos.FechaHoraActualizacion;
                //result.EstadoRegistro = lstDatos.EstadoRegistro;
                result.ListaMantenimientos = (from Origen in lstDatosMantenimiento
                                              select Helper.MiMapper<Mantenimiento, MantenimientoDTO>(Origen)).ToList();

                

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;
        }

        public List<Mantenimiento> ObtenerMantenimientoSolicitud(ObtenerSolicitudRequestDTO req)
        {
            var lstDatos = new List<Mantenimiento>();
            try
            {

                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioObtenerSolicitud(contextoParaBaseDatos);
                lstDatos = repo.ObtenerMantenimiento(req);


            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return lstDatos;
        }
    }
}
