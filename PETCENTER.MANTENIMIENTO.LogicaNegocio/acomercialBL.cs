using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TRAMARSA.RECLAMOS.AccesoDatos;

using AutoMapper;
using TRAMARSA.RECLAMOS.Entidades.Core;
using TRAMARSA.RECLAMOS.Framework;
using TRAMARSA.RECLAMOS.Entidades.Constantes;

using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
using TRAMARSA.RECLAMOS.DTO;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.AcuerdoComercial;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial;

using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales;

using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion;
using TRAMARSA.RECLAMOS.DTO.UsuarioSeguridad.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.TipoContenedorExterno.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Tarifa.Response;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.DetalleCatalogo;
using TRAMARSA.RECLAMOS.DTO.UsuarioSeguridad.Response;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Sucursal;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.TerminalPortuario;
using TRAMARSA.RECLAMOS.DTO.RolesCliente.Response;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.GrupoPuertoExterno;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Puerto;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.Tarifa;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.DetalleGrupoPuertoExterno;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.TipoContenedorExterno;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.Notificacion;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Request;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Response;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Cliente;
//using TRAMARSA.RECLAMOS.LogicaNegocio.Tramarsa.Cliente;
using TRAMARSA.RECLAMOS.Reportes;
using System.Net.Mail;
using System.IO;
using System.Reflection;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Tarifa;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Sucursal;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Tarifa.Request;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Pais;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Tarifa;

namespace TRAMARSA.RECLAMOS.LogicaNegocio
{

    public partial class AComercialBL
    {
         
        public List<ContenedoresNoDevueltosBE> ConsultarContenedoresNoDevueltos(ConsultaContenedorNoDevueltoBE request)
        {
            var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Tramarsa);
            var repo = new RepositorioAcuerdoComercial(contextoParaBaseDatos);

            List<ContenedoresNoDevueltosBE> contenedoresNoDevueltosBEList = repo.ConsultarContenedoresNoDevueltos(request);
            //(new ConsultaContenedorNoDevueltoBE { CodigoLinea = request.CodigoLinea });

            List<ClienteBE> notificanteList = (new ClienteBL()).ConsultarCliente(contenedoresNoDevueltosBEList.Select(x => x.CodNotificante).Distinct().ToList());
            List<ClienteBE> consignatarioList = (new ClienteBL()).ConsultarCliente(contenedoresNoDevueltosBEList.Select(x => x.CodConsignatario).Distinct().ToList());

            //CAMBIAMOS EL CODIGO DE NOTIFICANTE POR EL NOMBRE
            notificanteList.ForEach(x =>
            {
                contenedoresNoDevueltosBEList.Where(xy => xy.CodNotificante == x.CodigoClienteSAP).ToList().ForEach(xy =>
                {
                    xy.Notificante = x.Nombre;
                });
            });
            //CAMBIAMOS EL CODIGO DE CONSIGNATARIO POR EL NOMBRE
            consignatarioList.ForEach(x =>
            {
                contenedoresNoDevueltosBEList.Where(xy => xy.CodConsignatario == x.CodigoClienteSAP).ToList().ForEach(xy =>
                {
                    xy.Consignatario = x.Nombre;
                });
            });

            contenedoresNoDevueltosBEList.ForEach(x => x.DiasSobrantes = Math.Abs(x.DiasSobrantes));

            return contenedoresNoDevueltosBEList;
        }

        public DetalleContenedorNoDevueltoBE ConsultarDetalleContenedoresNoDevueltos(ConsultaContenedorNoDevueltoBE request)
        {
            var contextoParaBaseDatos = new ContextoParaBaseDatos(ConstantesDB.Tramarsa);
            var repo = new RepositorioAcuerdoComercial(contextoParaBaseDatos);
            var lstContenedorNoDevueltoBE = new List<ContenedoresNoDevueltosBE>();
            //var lstDetalleContenedorNoDevueltoBE = new List<DetalleContenedorNoDevueltoBE>();
            var objDetalleContenedorNoDevueltoBE = new DetalleContenedorNoDevueltoBE();
            var lstCodigoCliente = new List<string>();

            lstContenedorNoDevueltoBE = repo.ConsultarContenedoresNoDevueltos(request);

            lstCodigoCliente.Add(request.CodigoCliente);


            var cliente = (new ClienteBL()).ConsultarCliente(lstCodigoCliente).FirstOrDefault();
            objDetalleContenedorNoDevueltoBE.NombreCliente = cliente == null ? string.Empty : cliente.Nombre;

            var linea = (new MaestrosBL()).ObtenerLineaPorCodigo(request.CodigoLinea);
            objDetalleContenedorNoDevueltoBE.DescripcionLinea = linea == null ? string.Empty : linea.Nombre;
            objDetalleContenedorNoDevueltoBE.NroBL = request.NroBL;

            var tContenedor = (new MaestrosBL()).ObtenerTipoContenedorPorCodigo(request.CodigoContenedor);
            objDetalleContenedorNoDevueltoBE.DescripcionContenedor = tContenedor == null ? string.Empty : tContenedor.Descripcion;

            objDetalleContenedorNoDevueltoBE.FechaDesde = request.Desde;
            objDetalleContenedorNoDevueltoBE.FechaHasta = request.Hasta;
            objDetalleContenedorNoDevueltoBE.LiquidacionesNoDevueltas = lstContenedorNoDevueltoBE;

            //lstDetalleContenedorNoDevueltoBE.Add(objDetalleContenedorNoDevueltoBE);

            return objDetalleContenedorNoDevueltoBE;

        }

        public bool NotificarContenedoresNoDevueltos(string codigoLinea)
        {
            //CONSULTAMOS LA LIQUIDACIONES NO DEVUELTAS
            List<ContenedoresNoDevueltosBE> contenedoresNoDevueltosBEList = this.ConsultarContenedoresNoDevueltos(new ConsultaContenedorNoDevueltoBE { CodigoLinea = codigoLinea });

            //OBTENEMOS LOS CORREOS DE LOS CLIENTES
            List<ConsultaClienteCorreoDTO> consultaClienteCorreoDTOList = contenedoresNoDevueltosBEList.Select(x => { return new ConsultaClienteCorreoDTO { CodigoCliente = x.CodigoAgente, CodigoTipoCorreo = (new CoreBL()).ObtenerParametroNegocio(Convert.ToInt32(ConstantesParametrosNegocio.ClienteTipoCorreo).ToString()).Valor }; }).ToList();
            consultaClienteCorreoDTOList = consultaClienteCorreoDTOList.GroupBy(x => new { x.CodigoCliente, x.CodigoTipoCorreo }).Select(x => new ConsultaClienteCorreoDTO { CodigoCliente = x.Key.CodigoCliente, CodigoTipoCorreo = x.Key.CodigoTipoCorreo }).ToList();

            //OBTENEMOS LOS CODIGOS SAP
            List<string> codigoSAPList = consultaClienteCorreoDTOList.Select(x => x.CodigoCliente).ToList();

            //CONSULTAMOS EL CLIENTE PARA OBTENER EL CAMPO "CODIGOCLIENTE"
            List<ClienteBE> clienteList = (new ClienteBL()).ConsultarCliente(codigoSAPList);
            clienteList.ForEach(x =>
            {
                var match = consultaClienteCorreoDTOList.Where(xy => xy.CodigoCliente == x.CodigoClienteSAP).ToList();
                if (match.Any())
                    match.ForEach(xy => xy.CodigoCliente = x.CodigoCliente);//REMPLAZAMOS EL CODIGO SAP POR EL CODIGO DE CLIENTE
            });

            List<ClienteCorreoBE> clienteCorreoBEList = (new ClienteBL()).ConsultarClienteCorreo(consultaClienteCorreoDTOList);

            clienteList.ForEach(x =>
            {
                var match = clienteCorreoBEList.Where(xy => xy.CodigoCliente == x.CodigoCliente).ToList();
                if (match.Any())
                    match.ForEach(xy => xy.CodigoCliente = x.CodigoClienteSAP);//DEVOLVEMOS EL "CODIGOCLIENTESAP"
            });

            //ASIGNAMOS LOS CORREOS CORRESPONDIENTES
            clienteCorreoBEList.ForEach(x =>
            {
                contenedoresNoDevueltosBEList.Where(xy => xy.CodigoAgente == x.CodigoCliente).ToList().ForEach(z =>
                {
                    z.CorreoElectronico = x.CorreoElectronico;
                });
            });

            List<string> notificante = contenedoresNoDevueltosBEList.Select(x => x.Notificante).Distinct().ToList();
            notificante = contenedoresNoDevueltosBEList.Select(x => x.Consignatario).Distinct().ToList();
            //OBTENEMOS LOS DATOS DEL CLIENTE, NOTIFICACION, CONSIGNATARIO
            List<ClienteBE> clienteAgenteList = (new ClienteBL()).ConsultarCliente(contenedoresNoDevueltosBEList.Select(x => x.CodigoAgente).Distinct().ToList());

            //CLASIFICAMOS EL CONTENEDOR POR CANTIDAD DE DIAS SOBRANTES
            contenedoresNoDevueltosBEList.ForEach(x =>
            {
                if (x.DiasSobrantes > 0)
                    x.CodigoNotificacion = (int)TipoNotificacion.ContenedeorNoDevueltoMayorACero;
                else if (x.DiasSobrantes > -30 && x.DiasSobrantes <= 0)
                    x.CodigoNotificacion = (int)TipoNotificacion.ContenedeorNoDevueltoCeroATreintaNegativo;
                else
                    x.CodigoNotificacion = (int)TipoNotificacion.ContenedeorNoDevueltoMayorATreintaNegativo;
            });

            //MOSTRAR TODOS LOS DIAS SOBRANTES EN POSITIVO
            contenedoresNoDevueltosBEList.ForEach(x => x.DiasSobrantes = Math.Abs(x.DiasSobrantes));

            //AGRUPAMOS POR QUIEBRES
            var contenedoresNoDevueltosBEGrouped = contenedoresNoDevueltosBEList.GroupBy(x =>
                                                                                        new
                                                                                        {
                                                                                            x.CodigoNave,
                                                                                            x.NumeroBL,
                                                                                            x.CodigoAgente,
                                                                                            x.CodigoNotificacion
                                                                                        })
                                                                                 .Select(x => x.First()).ToList();

            foreach (var contenedor in contenedoresNoDevueltosBEGrouped)
            {
                var contenedoresNoDevueltosAEnviar = contenedoresNoDevueltosBEList.Where(x => x.CodigoNave == contenedor.CodigoNave
                                                                                           && x.NumeroBL == contenedor.NumeroBL
                                                                                           && x.CodigoAgente == contenedor.CodigoAgente
                                                                                           && x.CodigoNotificacion == contenedor.CodigoNotificacion).ToList();

                #region VALIDAMOS EL CORREO DEL CLIENTE

                string correElectronico = contenedoresNoDevueltosAEnviar.First().CorreoElectronico;
                if (string.IsNullOrEmpty(correElectronico))
                    continue;

                #endregion

                #region OBTENEMOS LOS VALORES DE LA CABECERA

                string nombreCliente = "";
                var clienteListFound = clienteAgenteList.Where(xy => xy.CodigoClienteSAP == contenedoresNoDevueltosAEnviar.First().CodigoAgente).ToList();
                if (clienteListFound.Any())
                    nombreCliente = clienteListFound.First().Nombre;

                var tipoCliente = (new MaestrosBL()).ObtenerListaDetalleCatalogo().SingleOrDefault(xy => xy.IdCatalogo == (int)CatalogoTablas.TipoCliente && xy.Codigo == TipoCliente.CLiente1.GetDescription()).Codigo;
                var linea = codigoLinea;    //(new CoreBL()).ObtenerParametroNegocio(Convert.ToInt32(ConstantesParametrosNegocio.CodigoLinea).ToString()).ValorRelacionado;
                var numeroBL = contenedoresNoDevueltosAEnviar.Any() ? contenedoresNoDevueltosAEnviar.First().NumeroBL : "";
                var nave = contenedoresNoDevueltosAEnviar.Any() ? contenedoresNoDevueltosAEnviar.First().NombreNave : "";

                string titulo = "";
                List<Notificacion> notificacionList = (new RepositorioNotificacion(new ContextoParaBaseDatos(ConstantesDB.AcuerdoComercialAGMADB))).ObtenerPorCodigo(contenedor.CodigoNotificacion, codigoLinea);
                if (notificacionList.Any())
                    titulo = notificacionList.First().Asunto.Split(':').ToList().LastOrDefault();

                #endregion

                NotificacionBL notificacionBL = new NotificacionBL();
                RequestNotificacionDTO requestNotificacion = new RequestNotificacionDTO();
                requestNotificacion.CodigoLinea = codigoLinea;
                requestNotificacion.CorreosPara.Add(correElectronico);
                requestNotificacion.CorreoDe = WebConfigReader.Mailer.From;
                requestNotificacion.CodigoNotificacion = contenedor.CodigoNotificacion;
                requestNotificacion.AsuntoValores = new Dictionary<string, string>() {
                                                    { "{NAVE}", nave }
                                                   ,{ "{BL}",  numeroBL}
                                                   ,{ "{CLIENTE}", nombreCliente }};
                requestNotificacion.CuerpoValores = new Dictionary<string, string>() {
                                                    { "{NombreCliente}", nombreCliente }};

                requestNotificacion.Adjuntos.Add((new LiquidacionesReporte()).RenderizarPDF(contenedoresNoDevueltosAEnviar, nombreCliente, tipoCliente, linea, numeroBL, "", "", titulo, nave));

                Task task = new Task((Action<Object>)EnviarCorreo, requestNotificacion);
                task.Start();

            }
            return true;
        }


    }
}
