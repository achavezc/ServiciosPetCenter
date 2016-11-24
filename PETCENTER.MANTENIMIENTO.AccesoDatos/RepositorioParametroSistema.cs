using System;
using System.Collections.Generic;
using System.Linq;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.DTO;
using System.Data.Objects.SqlClient;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
using System.Data.SqlClient;
using System.Data;

namespace PETCENTER.MANTENIMIENTO.AccesoDatos
{
    public class RepositorioParametroSistema : RepositorioBase<ParametroSistema>
    {
        public RepositorioParametroSistema(ContextoParaBaseDatos contexto)
            : base(contexto)
        {
        }


        public ParametroSistema ObtenerParametroSistema(ConstantesParametrosSistema parametrosSistema, string sociedadPropietaria)
        {
            List<ParametroSistema> listParametroSistema = ListarParametroSistema(sociedadPropietaria);
            return listParametroSistema.Find(x => x.Codigo.ToString() == Convert.ToInt32(parametrosSistema).ToString());
        }


        public List<ParametroSistema> ListarParametroSistema(string sociedadPropietaria)
        {
            List<ParametroSistema> listaParametrosSistema = new List<ParametroSistema>();

            //try
            //{
            ManejadorCache manejadorCache = new ManejadorCache();
            string keyCache = Convert.ToString(KeyCache.ParametroSistema);

            listaParametrosSistema = manejadorCache.ObtenerValorCache<List<ParametroSistema>>(keyCache);

            if (listaParametrosSistema == null || listaParametrosSistema.Count == 0)
            {
                var ParametrosSistemaList = ConsultarParametrosSistema();
                listaParametrosSistema = ParametrosSistemaList.Where(p => p.SociedadPropietaria == sociedadPropietaria).ToList();

                manejadorCache.InsertarValorCache(keyCache, listaParametrosSistema);
            }
            //}
            //catch (Exception ex)
            //{
            //    ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            //     ex;
            //}

            return listaParametrosSistema;
        }




        public List<ParametroSistema> ConsultarParametrosSistema()
        {
            List<ParametroSistema> lista = new List<ParametroSistema>();

            using (SqlConnection conexion = new SqlConnection(ContextoParaBaseDatos.DecryptedConnectionString("Reclamos")))
            {
                using (SqlCommand cmd = SqlHelper.CreateCommand("USP_CONSULTAR_PARAMETROSISTEMA", conexion, true))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ParametroSistema puerto = new ParametroSistema()
                            {
                                IdParametroSistema = dr.IsDBNull(dr.GetOrdinal("IdParametroSistema")) ? 0 : dr.GetInt32(dr.GetOrdinal("IdParametroSistema")),
                                Codigo = dr.IsDBNull(dr.GetOrdinal("Codigo")) ? 0 : dr.GetInt32(dr.GetOrdinal("Codigo")),
                                Valor = dr.IsDBNull(dr.GetOrdinal("Valor")) ? "" : dr.GetString(dr.GetOrdinal("Valor")),
                                ValorRelacionado = dr.IsDBNull(dr.GetOrdinal("ValorRelacionado")) ? "" : dr.GetString(dr.GetOrdinal("ValorRelacionado")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? "" : dr.GetString(dr.GetOrdinal("Descripcion")),
                                SociedadPropietaria = dr.IsDBNull(dr.GetOrdinal("SociedadPropietaria")) ? "" : dr.GetString(dr.GetOrdinal("SociedadPropietaria")),
                                usuarioCreacion = dr.IsDBNull(dr.GetOrdinal("usuarioCreacion")) ? "" : dr.GetString(dr.GetOrdinal("usuarioCreacion")),
                            };

                            lista.Add(puerto);
                        }
                        SqlHelper.CloseConnection(conexion);
                    }
                }
            }

            return lista;
        }


    }
}
