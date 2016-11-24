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
using PETCENTER.MANTENIMIENTO.DTO;
using System.Reflection;
using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request;


namespace PETCENTER.MANTENIMIENTO.LogicaNegocio
{

    public class SeguridadBL
    {
        public List<ResponseListaUsuarios> GetInfoUsuario(RequestInfoBasicaUsuarioDTO request)
        {
            ResponseInfoBasicaUsuarioDTO listaUsuarios = (new SeguridadProxy()).ListarUsuarios(request);

            return listaUsuarios.ListaInfoBasicaUsuarios;

        }

        public string getNombreUsuario(RequestInfoBasicaUsuarioDTO request)
        {
            List<ResponseListaUsuarios> usuariosList = this.GetInfoUsuario(request);

            if (usuariosList.Any())
                return usuariosList.FirstOrDefault().NombresCompletos;

            return "";

        }

        //public GenerarClaveUsuarioResponseDTO ResetearContrasenia(GenerarClaveUsuarioRequestDTO request)
        //{
        //    GenerarClaveUsuarioResponseDTO response = new GenerarClaveUsuarioResponseDTO();
        //    ResponseCambioClaveDTO responseProxy = new ResponseCambioClaveDTO();

        //    SimpleInteroperableEncryption crypter = new SimpleInteroperableEncryption(WebConfigReader.Encriptacion.SemillaEncriptacionPublica);
        //    RequestCambioClaveDTO requestDTO = new RequestCambioClaveDTO();

        //    string contraseniaGenerada = HelperSeguridad.GenerarContrasenia();
        //    requestDTO.ClaveAntigua = requestDTO.ClaveNuevaConfirmada = requestDTO.ClaveNueva = crypter.Encrypt(contraseniaGenerada);

        //    requestDTO.Dominio = request.DominioAplicacion;
        //    requestDTO.Acronimo = request.AcronimoAplicacion;
        //    requestDTO.TipoCambioClave = TipoCambioClave.Sys;
        //    requestDTO.CodigoUsuario = request.Usuario.Trim();

        //    responseProxy = (new SeguridadProxy()).CambiarClaveWeb(requestDTO);

        //    int codigoError = 0;

        //    if (responseProxy.Result.Satisfactorio == false)
        //        if (int.TryParse(responseProxy.Result.CodigoError, out codigoError) && codigoError < 0)
        //        {
        //            throw new ResultException { Result = responseProxy.Result };
        //        }
        //        else if (!int.TryParse(responseProxy.Result.CodigoError, out codigoError) && codigoError == 0)
        //        {
        //            throw new ResultException { Result = responseProxy.Result };
        //        } 
        //        else
        //        {
        //            throw new Exception(responseProxy.Result.Mensaje);
        //        }

        //    this.NotificarCambioConstraseniaMSC(responseProxy.CodigoUsuario, responseProxy.Correo, responseProxy.Nombres, contraseniaGenerada);

        //    return response;
        //}


        //public void NotificarCambioConstraseniaMSC(string CodigoUsuario, string Correo, string Nombres, string contraseniaGenerada)
        //{
        //    RequestNotificacionDTO requestNotificacion = new RequestNotificacionDTO();

        //    #region VALIDAMOS EL CORREO DEL CLIENTE

        //    if (string.IsNullOrEmpty(Correo))
        //        return;

        //    #endregion


        //    requestNotificacion.CodigoLinea = "HLL";
        //    requestNotificacion.CorreosPara.Add(Correo);
        //    requestNotificacion.CorreoDe = WebConfigReader.Mailer.From;
        //    requestNotificacion.CodigoNotificacion = (int)TipoNotificacion.NotificacionRecordarClave;

            

        //    requestNotificacion.CuerpoValores = new Dictionary<string, string>() {
        //                                               { "{Cliente}", Nombres },
        //                                               { "{Usuario}", CodigoUsuario },
        //                                               { "{Clave}", contraseniaGenerada },
        //                                               { "{urlpagina}", WebConfigReader.Aplicacion.UrlAplicacion.Trim() }
        //                                            };

        //    Task task = new Task((Action<Object>)EnviarCorreo, requestNotificacion);
        //    task.Start();
        //}

        //public void EnviarCorreo(Object requestNotificacion)
        //{
        //    NotificacionBL notificacionBL = new NotificacionBL();
        //    notificacionBL.requestNotificationDTO = requestNotificacion as RequestNotificacionDTO;
        //    notificacionBL.EnviarNotificacionAsync();
        //}


        public CambiarClaveUsuarioResponseDTO CambiarClaveUsuario(CambiarClaveUsuarioRequestDTO request)
        {

            CambiarClaveUsuarioResponseDTO response = new CambiarClaveUsuarioResponseDTO();
            ResponseCambioClaveDTO responseProxy = new ResponseCambioClaveDTO();

            RequestCambioClaveDTO requestDTO = new RequestCambioClaveDTO();
            SimpleInteroperableEncryption crypter = new SimpleInteroperableEncryption(WebConfigReader.Encriptacion.SemillaEncriptacionPublica);

            //string contraseniaGenerada = HelperSeguridad.GenerarContrasenia();

            //ENCRIPTAMOS LAS CONTRASEÑAS
            requestDTO.Dominio = request.DominioAplicacion;
            requestDTO.Acronimo = request.AcronimoAplicacion;
            requestDTO.TipoCambioClave = TipoCambioClave.Ui;
            requestDTO.ClaveAntigua = request.ClaveAnterior;                                //crypter.Encrypt(request.ClaveAnterior);
            requestDTO.ClaveNueva = requestDTO.ClaveNuevaConfirmada = request.ClaveNueva;   //crypter.Encrypt(request.ClaveNueva);
            requestDTO.CodigoUsuario = request.Usuario.Trim();

            responseProxy = (new SeguridadProxy()).CambiarClaveWeb(requestDTO);

            int codigoError = 0;
            if (responseProxy.Result.Satisfactorio == false)
                if (int.TryParse(responseProxy.Result.CodigoError, out codigoError) && codigoError < 0)
                {
                    throw new ResultException { Result = responseProxy.Result };
                }
                else if (!int.TryParse(responseProxy.Result.CodigoError, out codigoError) && codigoError == 0)
                {
                    throw new ResultException { Result = responseProxy.Result };
                } 
                else
                {
                    throw new Exception(responseProxy.Result.Mensaje);
                }

            return response;
        }

    }
}
