using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud.Request;

namespace PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO
{
  public   class RepositorioObtenerSolicitud : RepositorioBase<RepositorioObtenerSolicitud>
    {
      public RepositorioObtenerSolicitud(ContextoParaBaseDatos contexto) : base(contexto) { }




        public Solicitud ObtenerSolicitud(ObtenerSolicitudRequestDTO request)
        {
            var objeto = new Solicitud();

            using (var conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                var parametrosIn = new Dictionary<string, object>();
                var parametrosOut = new Dictionary<string, object>();
                parametrosIn.Add("@CodigoSolicitud", request.CodigoSolicitud);
                using (var cmd = SqlHelper.CreateCommandWithParameters("USP_GETSOLICITUD", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Solicitud ()
                            {
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSolicitud")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("DescripcionSolicitud")) ? string.Empty : dr.GetString(dr.GetOrdinal("DescripcionSolicitud")),
                                Fecha = dr.IsDBNull(dr.GetOrdinal("FechaSolicitud")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaSolicitud")),
                                Estado = dr.IsDBNull(dr.GetOrdinal("CodigoEstadoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEstadoSolicitud")),
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),
                                CodigoEmpleado1 = dr.IsDBNull(dr.GetOrdinal("CodigoEmpleadoRegistra")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEmpleadoRegistra")),
                                CodigoEmpleado2 = dr.IsDBNull(dr.GetOrdinal("CodigoEmpleadoAprueba")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEmpleadoAprueba")),
                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion")),
                                
                            };
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return objeto;
        }

        public List<Mantenimiento> ObtenerMantenimiento(ObtenerSolicitudRequestDTO request)
        {
            var lista = new List<Mantenimiento>();

            using (var conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                var parametrosIn = new Dictionary<string, object>();
                var parametrosOut = new Dictionary<string, object>();
                parametrosIn.Add("@CodigoSolicitud", request.CodigoSolicitud);
                using (var cmd = SqlHelper.CreateCommandWithParameters("USP_GETMANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var objeto = new Mantenimiento()
                            {

                                CodigoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoMantenimiento")),
                                Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre")),
                                Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("Fecha")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion")),
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSolicitud")),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? string.Empty  : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion")),
                                EstadoRegistro = !dr.IsDBNull(dr.GetOrdinal("EstadoRegistro")) && dr.GetBoolean(dr.GetOrdinal("EstadoRegistro")),

                            };
                            lista.Add(objeto);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return lista;
        }
    }
}
