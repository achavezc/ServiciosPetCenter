using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.AccesoDatos
{
   public  class RepositorioTipoMantenimiento : RepositorioBase<RepositorioTipoMantenimiento>
    {
       public RepositorioTipoMantenimiento(ContextoParaBaseDatos contexto) : base(contexto) { }

       public List<TipoMantenimiento > ConsultarTipoMantenimiento()
       {
           List<TipoMantenimiento> lista = new List<TipoMantenimiento>();

           using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("PETCENTERDB")))
           {
               using (SqlCommand cmd = SqlHelper.CreateCommand("USP_CONSULTAR_TIPO_MANTENIMINETO", conexion, true))
               {
                   using (IDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           TipoMantenimiento tipomantenimiento = new TipoMantenimiento()
                           {
                               CodigoTipoMantenimiento =dr.IsDBNull(dr.GetOrdinal("CodigoTipoMantenimiento")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoTipoMantenimiento")),
                               Nombre =dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                               Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? "" : dr.GetString(dr.GetOrdinal("Descripcion")).Trim(),
                               //CodigoSede = dr.IsDBNull(dr.GetOrdinal("CodigoSede")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoSede")),
                               //CodigoNegocio = dr.IsDBNull(dr.GetOrdinal("CodigoNegocio")) ? 0 : dr.GetInt32(dr.GetOrdinal("CodigoNegocio")),
                               //Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? "" : dr.GetString(dr.GetOrdinal("Nombre")).Trim(),
                               //CodigoSedeSAP = dr.IsDBNull(dr.GetOrdinal("CodigoSedeSAP")) ? "" : dr.GetString(dr.GetOrdinal("CodigoSedeSAP"))

                           };

                           lista.Add(tipomantenimiento);
                       }
                       SqlHelper.CloseConnection(conexion);
                   }
               }
           }

           return lista;
       }
    }
}
