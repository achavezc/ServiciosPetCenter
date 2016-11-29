using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Request;
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
    public class RepositorioSolicitud : RepositorioBase<RepositorioSolicitud>
    {
        public RepositorioSolicitud(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<SolicitudDTO> ConsultarSolicitud(ConsultarSolicitudRequestDTO request, out int totalRegistros, out int cantidadPaginas)
        {
            List<SolicitudDTO> Lista = new List<SolicitudDTO>();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                Dictionary<string, object> parametrosOut = new Dictionary<string, object>();
                int totRegs = 0;
                int cantRegs = 0;


                parametrosIn.Add("@CodigoSolicitud", request.CodigoSolicitud);
                parametrosIn.Add("@CodigoTipoMantenimiento", request.CodigoTipoMantenimiento);
                parametrosIn.Add("@FechaInicio", request.FechaInicio );
                parametrosIn.Add("@FechaFin", request.FechaFin);
                parametrosIn.Add("@Estado", request.Estado);
                parametrosIn.Add("@CodigoSede", request.CodigoSede);
                parametrosIn.Add("@CodigoArea", request.CodigoArea);

                parametrosIn.Add("@OrdenCampo", request.OrdenCampo);
                parametrosIn.Add("@OrdenOrientacion", request.OrdenOrientacion);
                parametrosIn.Add("@PaginaActual", request.PaginaActual);
                parametrosIn.Add("@NroRegistrosPorPagina", request.NroRegistrosPorPagina);

                parametrosOut.Add("@TotalRegistros", totRegs);
                parametrosOut.Add("@CantidadPaginas", cantRegs);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("USP_CONSULTA_SOLICITUDES", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SolicitudDTO solicitud = new SolicitudDTO()
                            {
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSolicitud")),
                                DescripcionSolicitud = dr.IsDBNull(dr.GetOrdinal("DescripcionSolicitud")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionSolicitud")).Trim(),
                                FechaSolicitud = dr.IsDBNull(dr.GetOrdinal("FechaSolicitud")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaSolicitud")),
                                CodigoEstadoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoEstadoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEstadoSolicitud")),
                                DescripcionEstadoSolicitud = dr.IsDBNull(dr.GetOrdinal("DescripcionEstadoSolicitud")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionEstadoSolicitud")).Trim(),

                                CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                                DescripcionSedeSolicitud = dr.IsDBNull(dr.GetOrdinal("DescripcionSedeSolicitud")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionSedeSolicitud")).Trim(),
                                
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                DescripcionAreaSolicitud = dr.IsDBNull(dr.GetOrdinal("DescripcionAreaSolicitud")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionAreaSolicitud")).Trim(),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),
                                DescripcionTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionTipoMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionTipoMantenimiento")).Trim(),
                                CodigoEmpleadoRegistra = dr.IsDBNull(dr.GetOrdinal("CodigoEmpleadoRegistra")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEmpleadoRegistra")),
                                NombreEmpleadoRegistra = dr.IsDBNull(dr.GetOrdinal("NombreEmpleadoRegistra")) ? "" : dr.GetString(dr.GetOrdinal("NombreEmpleadoRegistra")).Trim(),
                                CodigoEmpleadoAprueba = dr.IsDBNull(dr.GetOrdinal("CodigoEmpleadoAprueba")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEmpleadoAprueba")),
                                NombreEmpleadoAprueba = dr.IsDBNull(dr.GetOrdinal("NombreEmpleadoAprueba")) ? "" : dr.GetString(dr.GetOrdinal("NombreEmpleadoAprueba")).Trim(),
                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")).Trim(),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")).Trim(),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))                                
                            };

                            Lista.Add(solicitud);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }

                    totalRegistros = Int32.Parse(cmd.Parameters["@TotalRegistros"].Value.ToString());
                    cantidadPaginas = Int32.Parse(cmd.Parameters["@CantidadPaginas"].Value.ToString());
                }
            }

            return Lista;

        }

        public int RegistrarSolicitud(RegistrarSolicitud request)
        {
            int CodigoSolicitudOut = 0;
            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                using (SqlCommand cmd = SqlHelper.CreateCommand("USP_REGISTRAR_SOLICITUD", conexion, true))
                {
                    SqlParameterCollection parametrosIn = cmd.Parameters;
                    parametrosIn.AddWithValue("@CodigoSolicitud", request.CodigoSolicitud);
                    parametrosIn.AddWithValue("@Descripcion", request.Descripcion);
                    parametrosIn.AddWithValue("@Fecha", request.Fecha);
                    parametrosIn.AddWithValue("@Estado", request.Estado);
                    parametrosIn.AddWithValue("@CodigoSede", request.CodigoSede);
                    parametrosIn.AddWithValue("@CodigoArea", request.CodigoArea);
                    parametrosIn.AddWithValue("@CodigoTipoMantenimiento", request.CodigoTipoMantenimiento);
                    parametrosIn.AddWithValue("@CodigoEmpleado1", request.CodigoEmpleado1);
                    parametrosIn.AddWithValue("@UsuarioRegistro", request.UsuarioRegistro );
                    parametrosIn.AddWithValue("@FechaHoraRegistro", DateTime.Now);
                    parametrosIn.AddWithValue("@Accion", request.Accion);
                    parametrosIn.Add("@CodigoSolicitudOut", DbType.Int32).Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    CodigoSolicitudOut = int.Parse(cmd.Parameters["@CodigoSolicitudOut"].Value.ToString());
                    SqlHelper.CloseConnection(conexion);
                }

            }

            return CodigoSolicitudOut;

        }
        public void RegistrarMantenimiento(List<MantenimientoList> Mantenimiento)
        {
            if (Mantenimiento.Count > 0)
            {
                SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB"));
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                var dtmantenimieto = (from origin in Mantenimiento 
                                              select new
                                              {
                                               CodigoMantenimiento =origin.CodigoMantenimiento ,
                                               Nombre=origin.Nombre ,
                                               Fecha=origin.Fecha,
                                               Descripcion =origin.Descripcion ,
                                               CodigoSolicitud =origin.CodigoSolicitud ,
                                               //CodigoTipoMantenimiento =origin.CodigoTipoMantenimiento ,
                                               //CodigoArea =origin.CodigoArea ,
                                               UsuarioCreacion=origin.UsuarioCreacion ,
                                               FechaHoraCreacion =origin.FechaHoraCreacion ,
                                               Accion =origin.Accion 
                                              }).ToList().ToDataTable();

                parametrosIn.Add("@lista", dtmantenimieto);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("USP_REGISTRAR_MANTENIMIENTO", conexion, parametrosIn, true))
                {
                    cmd.ExecuteNonQuery();
                    SqlHelper.CloseConnection(conexion);
                }
            }
        }



    }
}
