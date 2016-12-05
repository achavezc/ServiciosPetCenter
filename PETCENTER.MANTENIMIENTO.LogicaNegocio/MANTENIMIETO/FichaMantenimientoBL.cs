using AutoMapper;
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Request;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Response;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using PETCENTER.MANTENIMIENTO.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PETCENTER.MANTENIMIENTO.LogicaNegocio.MANTENIMIETO
{
    public class FichaMantenimientoBL
    {
        public ConsultarFichaMantenimientoResponseDTO ConsultarFichaMantenimeinto(ConsultarFichaMantenimientoRequestDTO req)
        {
            ConsultarFichaMantenimientoResponseDTO response = new ConsultarFichaMantenimientoResponseDTO();
            try
            {

                List<FichaMantenimientoDTO> lista_fichamantenimiento = new List<FichaMantenimientoDTO>();
                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioFichaMantenimiento(contextoParaBaseDatos);
                int totalRegistros, cantPaginas;
                lista_fichamantenimiento = repo.ConsultarFichaMantenimiento(req, out totalRegistros, out cantPaginas);

                response.FichaMantenimientoList = lista_fichamantenimiento;
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

        public ConsultarMantenimientoResponseDTO ConsultarMantenimiento(ConsultarMantenimientoRequestDTO req)
        {
            ConsultarMantenimientoResponseDTO response = new ConsultarMantenimientoResponseDTO();
            try
            {

                List<MantenimientoDTO> lista_mantenimiento = new List<MantenimientoDTO>();
                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioMantenimiento(contextoParaBaseDatos);
                int totalRegistros, cantPaginas;
                lista_mantenimiento = repo.ConsultarMantenimiento(req, out totalRegistros, out cantPaginas);

                response.MantenimientoList = lista_mantenimiento;
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


        public RegistrarFichaMantenimientoResponseDTO RegistraFichaMantenimiento(RegistrarFichaMantenimientoRequestDTO request)
        {

            var response = new RegistrarFichaMantenimientoResponseDTO();
            var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
            var repo = new RepositorioFichaMantenimiento(contextoParaBaseDatos);
            int CodigoFichaMantenimiento = 0;

            Mapper.CreateMap<ActividadxFichaMantenimientoListDTO, ActividadesxFichaMantenimientoList>();
            Mapper.CreateMap<MaterialesxFichaMantenimientoListDTO, MaterialesxFichaMantenimientoList>();

            var requestBE = Helper.MiMapper<RegistrarFichaMantenimientoRequestDTO, RegistrarFichaMantenimiento>(request);

            requestBE.FechaHoraRegistro = DateTime.Now;

            //AdjuntarArchivo(request.ReclamoAdjuntoList);

            using (TransactionScope Transaccion = new TransactionScope())
            {
                CodigoFichaMantenimiento = repo.RegistrarFichaMantenimiento(requestBE);
                if (!CodigoFichaMantenimiento.Equals(0))
                {
                    ////Informacion Devolucion
                    //requestBE.MantenimientoList.CodigoSolicitud = CodigoSolicitud;
                    //requestBE.MantenimientoList.UsuarioCreacion = request.UsuarioRegistro;
                    //requestBE.MantenimientoList.FechaHoraCreacion = request.FechaHoraRegistro;
                    ////Informacion Devolucion
                    
                    //=======Registrando Actividades
                    requestBE.ActividadxFichaMantenimientoList.ForEach(x =>
                    {
                        x.CodigoFichaMantenimiento = CodigoFichaMantenimiento;
                        x.UsuarioCreacion = requestBE.UsuarioRegistro;
                        x.FechaHoraCreacion = requestBE.FechaHoraRegistro;
                    });

                    repo.RegistrarActividadesxFichaMantenimiento(requestBE.ActividadxFichaMantenimientoList);
                    //=======Registrando Materiales

                    requestBE.MaterialesxFichaMantenimientoList.ForEach(x =>
                    {
                        x.CodigoFichaMantenimiento = CodigoFichaMantenimiento;
                    });

                    repo.RegistrarMaterialesxFichaMantenimiento(requestBE.MaterialesxFichaMantenimientoList);

                }
                Transaccion.Complete();
            }
            return response;
        }


        public ObtenerFichaMantenimientoResponseDTO ObtenerFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO req)
        {
            var lstDatos = new FichaMantenimientoDTO();
            var lstDatosActividadxFichaMantenimiento = new List<ActividadxFichaMantenimiento>();
            var lstDatosMaterialesxFichaMantenimiento = new List<MaterialesxFichaMantenimiento>();
            var result = new ObtenerFichaMantenimientoResponseDTO();
            try
            {

                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioObtenerFichaMantenimiento(contextoParaBaseDatos);
                lstDatos = repo.ObtenerFichaMantenimiento (req);
                lstDatosActividadxFichaMantenimiento = ObtenerActividadxFichaMantenimiento(req);
                lstDatosMaterialesxFichaMantenimiento = ObtenerMaterialesxFichaMantenimiento (req);

                result.CodigoFichaMantenimiento=lstDatos.CodigoFichaMantenimiento; 
                result.CodigoMantenimiento=lstDatos.CodigoMantenimiento;
                result.CodigoSolicitud=lstDatos.CodigoSolicitud;
                result.CodigoTipoMantenimiento=lstDatos.CodigoTipoMantenimiento;
                result.DescripcionTipoMantenimiento=lstDatos.DescripcionTipoMantenimiento;

                result.CodigoArea=lstDatos.CodigoArea;
                result.DescripcionAreaMantenimiento=lstDatos.DescripcionAreaMantenimiento;
                result.DescrpcionFichaMantenimiento=lstDatos.DescripcionFichaMantenimiento;
                result.FechaFichaMantenimiento=lstDatos.FechaFichaMantenimiento;
                result.FechaInicioFichaMantenimiento=lstDatos.FechaInicioFichaMantenimiento;
                result.FechaFinFichaMantenimiento=lstDatos.FechaFinFichaMantenimiento;
                result.CantidadTecnicosFichaMantenimiento=lstDatos.CantidadTecnicosFichaMantenimiento;
                result.CodigoEstadoFichaMantenimiento=lstDatos.CodigoEstadoFichaMantenimiento;
                result.DescrpcionEstadoFichaMantenimiento=lstDatos.DescrpcionEstadoFichaMantenimiento;

                result.EstadoRegistro=lstDatos.EstadoRegistro;
                result.CodigoSede=lstDatos.CodigoSede;
                result.DescripcionSedeMantenimiento = lstDatos.DescripcionSedeMantenimiento;

                result.UsuarioCreacion = lstDatos.UsuarioCreacion;
                result.FechaHoraCreacion = lstDatos.FechaHoraCreacion;
                result.UsuarioActualizacion = lstDatos.UsuarioActualizacion;
                result.FechaHoraActualizacion = lstDatos.FechaHoraActualizacion;
                //result.EstadoRegistro = lstDatos.EstadoRegistro;
                result.ListaActividadxFichaMantenimiento = (from Origen in lstDatosActividadxFichaMantenimiento
                                                            select Helper.MiMapper<ActividadxFichaMantenimiento, ActividadxFichaMantenimientoDTO>(Origen)).ToList();
                result.ListaMaterialxFichaMantenimiento = (from Origen in lstDatosMaterialesxFichaMantenimiento
                                                           select Helper.MiMapper<MaterialesxFichaMantenimiento, MaterialxFichaMantenimientoDTO>(Origen)).ToList();



            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;
        }

        public List<ActividadxFichaMantenimiento> ObtenerActividadxFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO req)
        {
            var lstDatos = new List<ActividadxFichaMantenimiento>();
            try
            {

                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioObtenerFichaMantenimiento(contextoParaBaseDatos);
                lstDatos = repo.ObtenerActividadesxFichaMantenimiento(req);


            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return lstDatos;
        }
        public List<MaterialesxFichaMantenimiento> ObtenerMaterialesxFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO req)
        {
            var lstDatos = new List<MaterialesxFichaMantenimiento>();
            try
            {

                var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                var repo = new RepositorioObtenerFichaMantenimiento(contextoParaBaseDatos);
                lstDatos = repo.ObtenerMaterialesxFichaMantenimiento(req);


            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return lstDatos;
        }
    }
}
