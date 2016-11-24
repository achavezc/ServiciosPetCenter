using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PETCENTER.MANTENIMIENTO.AccesoDatos;

using AutoMapper;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.Entidades.UsuarioSeguridad;
using PETCENTER.MANTENIMIENTO.AgenteServicios.Seguridad;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Request;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Response;
using PETCENTER.MANTENIMIENTO.AgenteServicios.Comex;


namespace PETCENTER.MANTENIMIENTO.LogicaNegocio
{

    public class RolBL
    {
        public List<ResponseRolesClientesSAP> ObtenerListaRolesCliente()
        {
            ResponseConsultaRolesClientesSapDTO rolesCliente = new ResponseConsultaRolesClientesSapDTO();
            string keyCache = Convert.ToString(KeyCache.RolesClienteSAP);

            var lstRolesClientesSAP = new List<ResponseRolesClientesSAP>();

            ManejadorCache manejadorCache = new ManejadorCache();

            lstRolesClientesSAP = manejadorCache.ObtenerValorCache<List<ResponseRolesClientesSAP>>(keyCache);

            if (lstRolesClientesSAP == null || lstRolesClientesSAP.Count == 0)
            {
                ComexProxy proxyComex = new ComexProxy();

                rolesCliente = proxyComex.ObtenerRolCliente();
                lstRolesClientesSAP = rolesCliente.ListaRolesClientes;

                manejadorCache.InsertarValorCache(keyCache, lstRolesClientesSAP);
            }

            return lstRolesClientesSAP;

        }

                
    }
}
