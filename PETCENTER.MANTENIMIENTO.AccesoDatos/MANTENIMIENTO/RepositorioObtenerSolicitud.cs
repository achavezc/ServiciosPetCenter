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
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoReclamo")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoReclamo")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("CodigoSociedad")) ? string.Empty  : dr.GetString (dr.GetOrdinal("CodigoSociedad")),
                                Fecha = dr.IsDBNull(dr.GetOrdinal("CodigoNegocio")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("CodigoNegocio")),
                                Estado = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoTipoReclamo")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoReclamo")),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoSubTipoReclamo")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSubTipoReclamo")),
                                CodigoEmpleado1 = dr.IsDBNull(dr.GetOrdinal("CodigoCliente")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoCliente")),
                                CodigoEmpleado2 = dr.IsDBNull(dr.GetOrdinal("Cliente")) ? 0 : dr.GetInt32(dr.GetOrdinal("Cliente")),
                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion")),
                                EstadoRegistro = !dr.IsDBNull(dr.GetOrdinal("EstadoRegistro")) && dr.GetBoolean(dr.GetOrdinal("EstadoRegistro"))
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
                                Nombre = dr.IsDBNull(dr.GetOrdinal("CodigoReclamo")) ? string.Empty  : dr.GetString(dr.GetOrdinal("CodigoReclamo")),
                                Fecha = dr.IsDBNull(dr.GetOrdinal("NombreArchivo")) ? new DateTime()  : dr.GetDateTime(dr.GetOrdinal("NombreArchivo")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("NombreArchivo")) ? string.Empty : dr.GetString(dr.GetOrdinal("NombreArchivo")),
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("Extension")) ? 0 : dr.GetInt32(dr.GetOrdinal("Extension")),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("NombreArchivoInterno")) ? 0: dr.GetInt32(dr.GetOrdinal("NombreArchivoInterno")),
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoTipo")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipo")),

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
