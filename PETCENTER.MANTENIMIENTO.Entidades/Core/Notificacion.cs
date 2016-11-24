using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace PETCENTER.MANTENIMIENTO.Entidades.Core
{
    public class Notificacion : AuditoriaBase
    {
        public Notificacion()
        {
            this.ConCopia = "";
        }
        public int CodigoNotificacion { get; set; }
        public string CodigoLinea { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string ConCopia { get; set; }
        public List<Attachment> Adjuntos { get; set; }
    }

}

