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

namespace PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO
{
    public class RepositorioObtenerFichaMantenimiento : RepositorioBase<RepositorioObtenerFichaMantenimiento>
    {
        public RepositorioObtenerFichaMantenimiento(ContextoParaBaseDatos contexto) : base(contexto) { }




      public FichaMantenimientoDTO ObtenerFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO request)
        {
            var objeto = new FichaMantenimientoDTO();

            using (var conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                var parametrosIn = new Dictionary<string, object>();
                var parametrosOut = new Dictionary<string, object>();
                parametrosIn.Add("@CodigoFichaMantenimiento", request.CodigoFichaMantenimiento);
                using (var cmd = SqlHelper.CreateCommandWithParameters("USP_GET_FICHAMANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new FichaMantenimientoDTO()
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
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return objeto;
        }

      public List<ActividadxFichaMantenimiento> ObtenerActividadesxFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO request)
        {
            var lista = new List<ActividadxFichaMantenimiento>();

            using (var conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                var parametrosIn = new Dictionary<string, object>();
                var parametrosOut = new Dictionary<string, object>();
                parametrosIn.Add("@CodigoFichaMantenimiento", request.@CodigoFichaMantenimiento);
                using (var cmd = SqlHelper.CreateCommandWithParameters("USP_GET_ACTIVIDADES_X_FICHAMANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var objeto = new ActividadxFichaMantenimiento()
                            {

                                CodigoActividadxFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoActividadxFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoActividadxFichaMantenimiento")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion")).Trim (),
                                CodigoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoFichaMantenimiento")) ? 0: dr.GetInt32 (dr.GetOrdinal("CodigoFichaMantenimiento")),
                                CodigoActividad = dr.IsDBNull(dr.GetOrdinal("CodigoActividad")) ? 0: dr.GetInt32(dr.GetOrdinal("CodigoActividad")),
                                DescripcionActividad = dr.IsDBNull(dr.GetOrdinal("DescripcionActividad")) ? "": dr.GetString(dr.GetOrdinal("DescripcionActividad")).Trim() ,
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

      public List<MaterialesxFichaMantenimiento> ObtenerMaterialesxFichaMantenimiento(ObtenerFichaMantenimientoRequestDTO request)
      {
          var lista = new List<MaterialesxFichaMantenimiento>();

          using (var conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
          {
              var parametrosIn = new Dictionary<string, object>();
              var parametrosOut = new Dictionary<string, object>();
              parametrosIn.Add("@CodigoFichaMantenimiento", request.@CodigoFichaMantenimiento);
              using (var cmd = SqlHelper.CreateCommandWithParameters("USP_GET_MATERIALES_X_FICHAMANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
              {
                  using (IDataReader dr = cmd.ExecuteReader())
                  {
                      while (dr.Read())
                      {
                          var objeto = new MaterialesxFichaMantenimiento()
                          {


                              CodigoMaterialxFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoMaterialxFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoMaterialxFichaMantenimiento")),
                              Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion")).Trim(),
                              CodigoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoFichaMantenimiento")),
                              Cantidad = dr.IsDBNull(dr.GetOrdinal("Cantidad")) ? 0 : dr.GetInt32(dr.GetOrdinal("Cantidad")),
                              CodigoMaterial = dr.IsDBNull(dr.GetOrdinal("CodigoMaterial")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoMaterial")),
                              DescripcionMaterial = dr.IsDBNull(dr.GetOrdinal("DescripcionMaterial")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionMaterial")).Trim()
                              //UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                              //FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                              //UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                              //FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion")),
                              //EstadoRegistro = !dr.IsDBNull(dr.GetOrdinal("EstadoRegistro")) && dr.GetBoolean(dr.GetOrdinal("EstadoRegistro")),

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
