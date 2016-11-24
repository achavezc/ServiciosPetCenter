using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.DTO;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.CatalogoTablas;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.CatalogoTablas.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.CatalogoTablas.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.ClaseContenedor;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.ClaseContenedor.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleCatalogo;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleCatalogo.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleCatalogo.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleGrupoPuertoExterno;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleGrupoPuertoExterno.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.DetalleGrupoPuertoExterno.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.GrupoPuertoExterno;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.GrupoPuertoExterno.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.GrupoPuertoExterno.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.PesoVariable;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.PesoVariable.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.PesoVariable.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.Puerto;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.Puerto.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.Puerto.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedor;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedor.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedor.Response;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedorExterno;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedorExterno.Request;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.TipoContenedorExterno.Response;
using PETCENTER.MANTENIMIENTO.DTO.Core;
using PETCENTER.MANTENIMIENTO.DTO.Core.Request;
using PETCENTER.MANTENIMIENTO.DTO.Core.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Maestro.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Maestro.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Negocio.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Sede.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.SubTipoReclamo.Response;
using PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.BL;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.BL.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Linea;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Linea.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Moneda;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Moneda.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Nave;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Nave.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Nave.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Puerto;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Puerto.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Puerto.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Servicio;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Servicio.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Servicio.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Sucursal;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Sucursal.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Tarifa;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Tarifa.Request;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Tarifa.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.TerminalPortuario;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.AcuerdoComercial;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.CatalogoTablas;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.ClaseContenedor;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.DetalleCatalogo;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.DetalleGrupoPuertoExterno;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.GrupoPuertoExterno;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.PesoVariable;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.Puerto;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.TerminalPortuario;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.TipoContenedor;
//using PETCENTER.MANTENIMIENTO.Entidades.AcuerdosComerciales.TipoContenedorExterno;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.BL;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Cliente;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Linea;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Moneda;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Nave;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Pais;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Puerto;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Servicio;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Sucursal;
//using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Tarifa;
using PETCENTER.MANTENIMIENTO.Framework;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.SubTipoReclamo;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.TipoReclamo.Response;
//using PETCENTER.MANTENIMIENTO.Entidades.Reclamos;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Sede;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.Negocio;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.TipoDevolucion;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.TipoDevolucion.Response;
//using PETCENTER.MANTENIMIENTO.DTO.Reclamos.TipoReclamo;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento.Response;
using PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos;
using PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.TipoMantenimiento;

namespace PETCENTER.MANTENIMIENTO.LogicaNegocio
{

    public class MaestrosBL
    {
     


        

        //mantenimineto
        public ConsultarTipoMantenimientoResponseDTO ConsultarTipoMantenimiento()
        {

            ConsultarTipoMantenimientoResponseDTO result = new ConsultarTipoMantenimientoResponseDTO();
            List<TipoMantenimiento> lstDatos = new List<TipoMantenimiento>();

            try
            {
                string keyCache = Convert.ToString(KeyCache.Sede);

                ManejadorCache manejadorCache = new ManejadorCache();

                lstDatos = manejadorCache.ObtenerValorCache<List<TipoMantenimiento>>(keyCache);

                if (lstDatos == null || lstDatos.Count == 0)
                {
                    var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Petcenterdb);
                    var repo = new RepositorioTipoMantenimiento(contextoParaBaseDatos);
                    lstDatos = repo.ConsultarTipoMantenimiento();
                }

                result.TipoMantenimientoList = (from Origen in lstDatos
                                                select Helper.MiMapper<TipoMantenimiento, TipoMantenimientoDTO>(Origen)).ToList();

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
            }

            return result;

        }
    }
}

