using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades.Request;
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
   public  class RepositorioActividad : RepositorioBase<RepositorioActividad >
    {
       public RepositorioActividad(ContextoParaBaseDatos contexto) : base(contexto) { }

       public List<Actividad> ConsultarActividad(ConsultarActividadesRequestDTO request)
        {
            List<Actividad> lista = new List<Actividad>();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
            {

                Dictionary<string, object> parametrosIn = new Dictionary<string, object>();
                Dictionary<string, object> parametrosOut = new Dictionary<string, object>();
                int totRegs = 0;
                int cantRegs = 0;
                parametrosIn.Add("@DescripcionActividad", request.DescripcionActividad);

                using (SqlCommand cmd = SqlHelper.CreateCommandWithParameters("dbo.USP_CONSULTA_ACTIVIDAD", conexion, parametrosIn, true, parametrosOut))
               // using (SqlCommand cmd = SqlHelper.CreateCommand("dbo.USP_CONSULTA_ACTIVIDAD", conexion, true))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Actividad actividad = new Actividad()
                            {
                                CodigoActividad = dr.IsDBNull(dr.GetOrdinal("CodigoActividad")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoActividad")),
                                Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),

                                UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                                FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                                UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                                FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))

                            };

                            lista.Add(actividad);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return lista;
        }
    }
}
