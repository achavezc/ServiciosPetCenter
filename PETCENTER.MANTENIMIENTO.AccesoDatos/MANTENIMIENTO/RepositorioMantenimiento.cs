using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.AccesoDatos.MANTENIMIENTO
{
    public class RepositorioMantenimiento : RepositorioBase<RepositorioMantenimiento>
    {

        public RepositorioMantenimiento(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<MantenimientoDTO> ConsultarMantenimiento(ConsultarMantenimientoRequestDTO request, out int totalRegistros, out int cantidadPaginas)
        {
            List<MantenimientoDTO> Lista = new List<MantenimientoDTO>();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                Dictionary<string, object> parametrosOut = new Dictionary<string, object>();
                int totRegs = 0;
                int cantRegs = 0;


                parametrosIn.Add("@CodigoSolicitud", request.CodigoSolicitud);
                parametrosIn.Add("@DescripcionSolicitud", request.DescripcionSolicitud);
                parametrosIn.Add("@DescripcionMantenimiento", request.DescripcionMantenimiento);
                parametrosIn.Add("@CodigoTipoMantenimiento", request.CodigoTipoMantenimiento);
                parametrosIn.Add("@FechaInicio", request.FechaInicio);
                parametrosIn.Add("@FechaFin", request.FechaFin);
                parametrosIn.Add("@CodigoSede", request.CodigoSede);
                parametrosIn.Add("@CodigoArea", request.CodigoArea);

                parametrosIn.Add("@OrdenCampo", request.OrdenCampo);
                parametrosIn.Add("@OrdenOrientacion", request.OrdenOrientacion);
                parametrosIn.Add("@PaginaActual", request.PaginaActual);
                parametrosIn.Add("@NroRegistrosPorPagina", request.NroRegistrosPorPagina);

                parametrosOut.Add("@TotalRegistros", totRegs);
                parametrosOut.Add("@CantidadPaginas", cantRegs);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("dbo.USP_CONSULTA_MANTENIMIENTO", conexion, parametrosIn, true, parametrosOut))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MantenimientoDTO mantenimiento = new MantenimientoDTO()
                            {
                                CodigoSolicitud = dr.IsDBNull(dr.GetOrdinal("CodigoSolicitud")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSolicitud")),
                                DescripcionSolicitud = dr.IsDBNull(dr.GetOrdinal("DescripcionSolicitud")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionSolicitud")).Trim(),
                                CodigoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoMantenimiento")),
                                NombreMantenimiento = dr.IsDBNull(dr.GetOrdinal("NombreMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("NombreMantenimiento")).Trim(),
                                FechaMantenimiento = dr.IsDBNull(dr.GetOrdinal("FechaMantenimiento")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaMantenimiento")),

                                DescripcionMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionMantenimiento")).Trim(),
                                CodigoTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),

                                DescripcionTipoMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionTipoMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionTipoMantenimiento")).Trim(),
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                DescripcionAreaMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionAreaMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionAreaMantenimiento")).Trim(),
                                CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                                DescripcionSedeMantenimiento = dr.IsDBNull(dr.GetOrdinal("DescripcionSedeMantenimiento")) ? "" : dr.GetString(dr.GetOrdinal("DescripcionSedeMantenimiento")).Trim(),
                                
                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")).Trim(),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")).Trim(),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))                                
                            };

                            Lista.Add(mantenimiento);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }

                    totalRegistros = Int32.Parse(cmd.Parameters["@TotalRegistros"].Value.ToString());
                    cantidadPaginas = Int32.Parse(cmd.Parameters["@CantidadPaginas"].Value.ToString());
                }
            }

            return Lista;

        }

    }
}
