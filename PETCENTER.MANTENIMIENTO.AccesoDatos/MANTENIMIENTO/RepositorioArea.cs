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
    public class RepositorioArea: RepositorioBase<RepositorioArea >
    {
        public RepositorioArea(ContextoParaBaseDatos contexto) : base(contexto) { }

        public List<Area> ConsultarArea()
        {
            List<Area > lista = new List<Area >();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {
                using (SqlCommand cmd = SqlHelper.CreateCommand("dbo.USP_CONSULTAR_AREA", conexion, true))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Area  area = new Area ()
                            {
                                CodigoArea = dr.IsDBNull(dr.GetOrdinal("CodigoArea")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoArea")),
                                CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                                Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? "" : dr.GetString(dr.GetOrdinal("Descripcion")).Trim(),

                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))

                            };

                            lista.Add(area);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return lista;
        }
    }
}
