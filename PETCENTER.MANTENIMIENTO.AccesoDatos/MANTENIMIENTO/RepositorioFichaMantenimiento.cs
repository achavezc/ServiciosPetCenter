using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Request;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.Framework;

namespace PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO
{
    public class RepositorioFichaMantenimiento : RepositorioBase<RepositorioFichaMantenimiento>
    {

        public RepositorioFichaMantenimiento(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<FichaMantenimientoDTO> ConsultarFichaMantenimiento(ConsultarFichaMantenimientoRequestDTO request, out int totalRegistros, out int cantidadPaginas)
        {
            List<FichaMantenimientoDTO> Lista = new List<FichaMantenimientoDTO>();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                Dictionary<string, object> parametrosOut = new Dictionary<string, object>();
                int totRegs = 0;
                int cantRegs = 0;


                parametrosIn.Add("@CodigoFichaMantenimiento", request.CodigoFichaMantenimiento);
                parametrosIn.Add("@DescripcionFicha", request.DescripcionFicha);
                parametrosIn.Add("@CodigoTipoMantenimiento", request.CodigoTipoMantenimiento);
                parametrosIn.Add("@FechaInicio", request.FechaInicio);
                parametrosIn.Add("@FechaFin", request.FechaFin);
                parametrosIn.Add("@EstadoFichaMantenimiento", request.EstadoFichaMantenimiento);
                parametrosIn.Add("@CodigoSede", request.CodigoSede);
                parametrosIn.Add("@CodigoArea", request.CodigoArea);

                parametrosIn.Add("@OrdenCampo", request.OrdenCampo);
                parametrosIn.Add("@OrdenOrientacion", request.OrdenCampo);
                parametrosIn.Add("@PaginaActual", request.OrdenOrientacion);
                parametrosIn.Add("@NroRegistrosPorPagina", request.PaginaActual);

                parametrosOut.Add("@TotalRegistros", totRegs);
                parametrosOut.Add("@CantidadPaginas", cantRegs);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("dbo.USP_CONSULTA_FICHA_MANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FichaMantenimientoDTO ficha_mantenimiento = new FichaMantenimientoDTO()
                            {
                                CodigoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoFichaMantenimiento")),
                                CodigoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoMantenimiento")),
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSolicitud")),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),
                                DescripcionTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionTipoMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionTipoMantenimiento")).Trim(),

                                CodigoEmpleadoAprueba = dr.IsDBNull(dr.GetOrdinal("CodigoEmpleadoAprueba")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEmpleadoAprueba")),
                                NombreEmpleadoAprueba = dr.IsDBNull(dr.GetOrdinal("NombreEmpleadoAprueba")) ? "" : dr.GetString(dr.GetOrdinal("NombreEmpleadoAprueba")).Trim(),

                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                DescripcionAreaMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionAreaMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionAreaMantenimiento")).Trim(),
                                DescripcionFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescrpcionFichaMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescrpcionFichaMantenimiento")).Trim(),
                                FechaFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("FechaFichaMantenimiento")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaFichaMantenimiento")),
                                FechaInicioFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("FechaInicioFichaMantenimiento")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaInicioFichaMantenimiento")),
                                FechaFinFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("FechaFinFichaMantenimiento")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaFinFichaMantenimiento")),
                                CantidadTecnicosFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CantidadTecnicosFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CantidadTecnicosFichaMantenimiento")),
                                CodigoEstadoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoEstadoFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEstadoFichaMantenimiento")),
                                DescrpcionEstadoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescrpcionEstadoFichaMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescrpcionEstadoFichaMantenimiento")).Trim(),
                                CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                                DescripcionSedeMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionSedeMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionSedeMantenimiento")).Trim(),

                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")).Trim(),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")).Trim(),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))                                
                            };

                            Lista.Add(ficha_mantenimiento);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }

                    totalRegistros = Int32.Parse(cmd.Parameters["@TotalRegistros"].Value.ToString());
                    cantidadPaginas = Int32.Parse(cmd.Parameters["@CantidadPaginas"].Value.ToString());
                }
            }

            return Lista;

        }

        public int RegistrarFichaMantenimiento(RegistrarFichaMantenimiento request)
        {
            int CodigoFichaMantenimientoOut = 0;
            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                using (SqlCommand cmd = SqlHelper.CreateCommand("dbo.USP_REGISTRAR_FICHA_MANTENIMIENTO", conexion, true))
                {
                    SqlParameterCollection parametrosIn = cmd.Parameters;
                    parametrosIn.AddWithValue("@CodigoFichaMantenimiento", request.CodigoFichaMantenimiento);
                    parametrosIn.AddWithValue("@CodigoMantenimiento", request.CodigoMantenimiento);
                    //parametrosIn.AddWithValue("@CodigoSolicitud", request.CodigoSolicitud);
                    //parametrosIn.AddWithValue("@CodigoTipoMantenimiento", request.CodigoTipoMantenimiento);
                    parametrosIn.AddWithValue("@CodigoEmpleado", request.CodigoEmpleado);
                    //parametrosIn.AddWithValue("@CodigoSede", request.CodigoSede);
                    //parametrosIn.AddWithValue("@CodigoArea", request.CodigoArea);
                    parametrosIn.AddWithValue("@Descripcion", request.Descripcion);
                    parametrosIn.AddWithValue("@Fecha", request.Fecha);
                    parametrosIn.AddWithValue("@FechaInicio", request.FechaInicio);
                    parametrosIn.AddWithValue("@FechaFin", request.FechaFin);
                    parametrosIn.AddWithValue("@CantidadTecnicos", request.CantidadTecnicos);
                    parametrosIn.AddWithValue("@Estado", request.Estado);

                    parametrosIn.AddWithValue("@UsuarioRegistro", request.UsuarioRegistro );
                    parametrosIn.AddWithValue("@FechaHoraRegistro", DateTime.Now);
                    parametrosIn.AddWithValue("@Accion", request.Accion);
                    parametrosIn.Add("@CodigoFichaMantenimientoOut", DbType.Int32).Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    CodigoFichaMantenimientoOut = int.Parse(cmd.Parameters["@CodigoFichaMantenimientoOut"].Value.ToString());
                    SqlHelper.CloseConnection(conexion);
                }

            }

            return CodigoFichaMantenimientoOut;

        }
        public void RegistrarActividadesxFichaMantenimiento(List<ActividadesxFichaMantenimientoList> ActividadesxFichaMantenimiento)
        {
            if (ActividadesxFichaMantenimiento.Count > 0)
            {
                SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB"));
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                var dtActividadesxFichaMantenimiento = (from origin in ActividadesxFichaMantenimiento 
                                              select new
                                              {
                                                  CodigoActividadxFichaMantenimiento = origin.CodigoActividadxFichaMantenimiento,
                                                  Descripcion = origin.Descripcion,
                                                  CodigoFichaMantenimiento = origin.CodigoFichaMantenimiento,
                                                  CodigoActividad = origin.CodigoActividad,
                                               UsuarioCreacion=origin.UsuarioCreacion ,
                                               FechaHoraCreacion =origin.FechaHoraCreacion ,
                                               Accion =origin.Accion 
                                              }).ToList().ToDataTable();

                parametrosIn.Add("@lista", dtActividadesxFichaMantenimiento);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("USP_REGISTRAR_ACTIVIDAD_X_FICHA", conexion, parametrosIn, true))
                {
                    cmd.ExecuteNonQuery();
                    SqlHelper.CloseConnection(conexion);
                }
            }
        }

        public void RegistrarMaterialesxFichaMantenimiento(List<MaterialesxFichaMantenimientoList> MaterialesxFichaMantenimiento)
        {
            if (MaterialesxFichaMantenimiento.Count > 0)
            {
                SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB"));
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                var dtMaterialesxFichaMantenimiento = (from origin in MaterialesxFichaMantenimiento
                                                        select new
                                                        {
                                                            CodigoMaterialxFichaMantenimiento = origin.CodigoMaterialxFichaMantenimiento,
                                                            Descripcion = origin.Descripcion,
                                                            Cantidad = origin.Cantidad,
                                                            CodigoFichaMantenimiento = origin.CodigoFichaMantenimiento,
                                                            CodigoMaterial = origin.CodigoMaterial,
                                                            Accion = origin.Accion
                                                        }).ToList().ToDataTable();

                parametrosIn.Add("@lista", dtMaterialesxFichaMantenimiento);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("USP_REGISTRAR_MATERIAL_X_FICHA", conexion, parametrosIn, true))
                {
                    cmd.ExecuteNonQuery();
                    SqlHelper.CloseConnection(conexion);
                }
            }
        }
    }
}
