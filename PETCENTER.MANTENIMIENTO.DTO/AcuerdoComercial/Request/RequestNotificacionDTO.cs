using System.Collections.Generic;
using System.Net.Mail;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;

namespace PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Request
{
    /// <summary>
    /// Clase para Request Notificacion
    /// </summary>
    public class RequestNotificacionDTO
    {
        public RequestNotificacionDTO()
        {
            this.AsuntoValores = new Dictionary<string, string>();
            this.CuerpoValores = new Dictionary<string, string>();
            this.CorreosPara = new List<string>();
            this.CorreosCopia = new List<string>();
            this.Adjuntos = new List<Attachment>();
            this.Notificacion = new Entidades.Flujo.Notificacion();
            
        }
        public Entidades.Flujo.Notificacion Notificacion { get; set; }

        /// <summary>
        /// Código de Notificacion
        /// <br/><b>Tipo:</b> Notificaciones 
        /// </summary>
        public int CodigoNotificacion { get; set; }

        /// <summary>
        /// string>
        /// <br/><b>Tipo:</b> Dictionary<string, 
        /// </summary>
        public Dictionary<string, string> AsuntoValores { get; set; }

        /// <summary>
        /// string>
        /// <br/><b>Tipo:</b> Dictionary<string, 
        /// </summary>
        public Dictionary<string, string> CuerpoValores { get; set; }

        /// <summary>
        /// Lista de string
        /// <br/><b>Tipo:</b> List<string> 
        /// </summary>
        public List<string> CorreosPara { get; set; }

        /// <summary>
        /// Lista de string
        /// <br/><b>Tipo:</b> List<string> 
        /// </summary>
        public List<string> CorreosCopia { get; set; }

        /// <summary>
        /// Correo De
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 50
        /// </summary>
        public string CorreoDe { get; set; }

        public string Asunto { get; set; }

        public List<Attachment> Adjuntos { get; set; }

        public string CodigoLinea { get; set; }
    }
}