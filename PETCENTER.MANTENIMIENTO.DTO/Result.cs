using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO
{
    /// <summary>
    /// Clase para Objeto que describe el resultado de una operacion 
    /// </summary>
    public class Result
    {
        /// <summary>
        /// <br/><b>Tipo:</b> Result()
        /// </summary>
        public Result()
        {
            this.Satisfactorio = true;
            this.CodigoError = "";
            this.Mensaje = "";
            this.Mensajes = new List<Result>();
            

        }

        /// <summary>
        /// Describe si el resultado fue satisfactorio [Verdarero | Falso] 
        /// </summary>
        public bool Satisfactorio { get; set; }

        /// <summary>
        /// Describe el código de error de negocio
        /// </summary>
        public string CodigoError { get; set; }

        /// <summary>
        /// Describe el mensaje de error 
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Describe el Identificador del error
        /// </summary>
        public Guid IdError { get; set; }

        /// <summary>
        /// Contiene una coleccion del tipo List<Result> que contiene descripcion de errores adicionales
        /// </summary>
        public List<Result> Mensajes { get; set; }
    }
}
