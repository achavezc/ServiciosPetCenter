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
   public class RepositorioEstadoFichaMantenimiento: RepositorioBase<RepositorioEstadoFichaMantenimiento>
    {
        public RepositorioEstadoFichaMantenimiento(ContextoParaBaseDatos contexto) : base(contexto) { }

       public List<EstadoFichaMantenimiento> ConsultarEstadoFichaMantenimiento()
       {
           List<EstadoFichaMantenimiento> lista = new List<EstadoFichaMantenimiento>();

           using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
           {
               using (SqlCommand cmd = SqlHelper.CreateCommand("[dbo].[USP_CONSULTAR_ESTADO_FICHA_MANTENIMIENTO]", conexion, true))
               {
                   using (IDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           EstadoFichaMantenimiento EstadoFichaMantenimiento = new EstadoFichaMantenimiento()
                           {
                               CodigoEstadoFichaMantenimiento = dr.IsDBNull(dr.GetOrdinal("CodigoEstadoFichaMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoEstadoFichaMantenimiento")),
                               Nombre =dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                               //Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? "" : dr.GetString(dr.GetOrdinal("Descripcion")).Trim(),
                               //CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                               //CodigoNegocio = dr.IsDBNull(dr.GetOrdinal("CodigoNegocio")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoNegocio")),
                               //Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                               //CodigoSedeSAP = dr.IsDBNull(dr.GetOrdinal("CodigoSedeSAP")) ? "" : dr.GetString(dr.GetOrdinal("CodigoSedeSAP"))

                           };

                           lista.Add(EstadoFichaMantenimiento);
                       }
                       SqlHelper.CloseConnection(conexion);
                   }
               }
           }

           return lista;
       }

    }
}
