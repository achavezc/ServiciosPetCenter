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
      
    public class RepositorioSede : RepositorioBase<RepositorioSede>

    {
        public RepositorioSede(ContextoParaBaseDatos contexto) : base(contexto) { }
       public List<Sede> ConsultarSede()
       {
           List<Sede> lista = new List<Sede>();

           using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
           {
               using (SqlCommand cmd = SqlHelper.CreateCommand("[dbo].[USP_CONSULTAR_SEDE]", conexion, true))
               {
                   using (IDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           Sede sede = new Sede()
                           {
                               CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                               Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                               Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? "" : dr.GetString(dr.GetOrdinal("Direccion")).Trim(),
                               Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? "" : dr.GetString(dr.GetOrdinal("Telefono")),
                               UsuarioCreacion = dr.IsDBNull(dr.GetOrdinal("UsuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioCreacion")),
                               FechaHoraCreacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraCreacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraCreacion")),
                               UsuarioActualizacion = dr.IsDBNull(dr.GetOrdinal("UsuarioActualizacion")) ? "" : dr.GetString(dr.GetOrdinal("UsuarioActualizacion")),
                               FechaHoraActualizacion = dr.IsDBNull(dr.GetOrdinal("FechaHoraActualizacion")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("FechaHoraActualizacion"))

                           };

                           lista.Add(sede);
                       }
                       SqlHelper.CloseConnection(conexion);
                   }
               }
           }

           return lista;
       }
    }
}
