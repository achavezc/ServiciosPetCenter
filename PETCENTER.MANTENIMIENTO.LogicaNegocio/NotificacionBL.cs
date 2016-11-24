using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using PETCENTER.MANTENIMIENTO.Entidades.Core;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.AccesoDatos;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;
using System.Text.RegularExpressions;
//using PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.Notificacion.Request;

namespace PETCENTER.MANTENIMIENTO.LogicaNegocio
{
    public class NotificacionBL
    {
       /// public RequestNotificacionDTO requestNotificationDTO { get; set; }

        public void enviarEmail_Aux(List<string> correosPara, string correoDe, List<string> correosCopia, string asunto, string cuerpo, List<Attachment> adjuntoList)
        {

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(correoDe);
            mail.Body = cuerpo;
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            adjuntoList.ForEach(x => mail.Attachments.Add(x));

            correosPara.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x))
                    mail.To.Add(x);
            });
            correosCopia.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x))
                    mail.CC.Add(x);
            });

            SmtpClient Cliente = new SmtpClient();

            Cliente.Host = WebConfigReader.Mailer.Host;
            if (WebConfigReader.Mailer.Port > 0)
                Cliente.Port = Convert.ToInt32(WebConfigReader.Mailer.Port);

            Cliente.EnableSsl = WebConfigReader.Mailer.EnabledSSL;
            Cliente.UseDefaultCredentials = WebConfigReader.Mailer.UseDefaultCredentials;
            if (WebConfigReader.Mailer.UseDefaultCredentials == false)
                Cliente.Credentials = new NetworkCredential(WebConfigReader.Mailer.CredentialsUser, WebConfigReader.Mailer.CredentialsClave);

            Cliente.Send(mail);

            (new ManejadorLog()).GrabarLog(string.Format("Enviado... {0}: {1}", mail.To, mail.Subject));

        }

        //public void EnviarNotificacionAsync()
        //{
        //    string asunto = "";
        //    string cuerpo = "";
        //    try
        //    {

        //        using (var contexto = new ContextoParaBaseDatos(ConstantesDB.Reclamos))
        //        {
        //            RepositorioNotificacion repoNotificacion = new RepositorioNotificacion(contexto);
        //            //List<Notificacion> notificacionList = repoNotificacion.ObtenerPorCodigo(requestNotificationDTO.CodigoNotificacion, requestNotificationDTO.CodigoLinea);

        //            //if (!notificacionList.Any())
        //            //    return;

        //            var notificacion = requestNotificationDTO.Notificacion;

        //            asunto = notificacion.Asunto;
        //            cuerpo = notificacion.Cuerpo;

        //            foreach (var item in requestNotificationDTO.AsuntoValores)
        //                asunto = asunto.Replace(item.Key, item.Value);

        //            foreach (var item in requestNotificationDTO.CuerpoValores)
        //                cuerpo = cuerpo.Replace(item.Key, item.Value);

        //            List<string> conCopiaList = notificacion.ConCopia.Split(';').ToList();
        //            this.requestNotificationDTO.CorreosPara.AddRange(conCopiaList);
        //            this.requestNotificationDTO.CorreosPara.ForEach(x =>
        //            {
        //                enviarEmail_Aux(new List<string> { x }, this.requestNotificationDTO.CorreoDe, this.requestNotificationDTO.CorreosCopia, asunto, cuerpo, this.requestNotificationDTO.Adjuntos);
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);
        //    }
        //}

        //public List<NotificacionItem> Notificar(List<NotificacionItem> notificacionList)
        //{
        //    foreach (var x in notificacionList)
        //    {
        //        List<Notificacion> notificacionDBList = new List<Notificacion>();
        //        using (var contexto = new ContextoParaBaseDatos(ConstantesDB.AcuerdoComercialAGMADB))
        //        {
        //            notificacionDBList = (new RepositorioNotificacion(contexto)).ObtenerPorCodigo(requestNotificationDTO.CodigoNotificacion, requestNotificationDTO.CodigoLinea);
        //        }
        //        if (!notificacionDBList.Any())
        //            continue;

        //        Notificacion notificacion = notificacionDBList.FirstOrDefault();
        //        List<string> keyList = new List<string>();

        //        string pattern = "{(.+?)}";

        //        foreach (Match m in Regex.Matches(notificacion.Cuerpo, pattern))
        //            keyList.Add(m.Value);

        //        NotificacionBL notificacionBL = new NotificacionBL();
        //        notificacionBL.requestNotificationDTO = new RequestNotificacionDTO
        //        {
        //            //AsuntoValores = x.AsuntoValues.Select(m => new { m.Key, m.Value }).ToDictionary(m => m.Key, m => m.Value),

        //            CodigoNotificacion = x.Tipo,
        //            CorreoDe = x.De,
        //            CorreosCopia = x.ConCopia,
        //            //CuerpoValores = x.CuerpoValues.Select(m => new { m.Key, m.Value }).ToDictionary(m => m.Key, m => m.Value),
        //            CorreosPara = x.Para

        //        };
        //        //notificacionBL.EnviarNotificacion();
        //    };

        //    return notificacionList;
        //}
    }

}
