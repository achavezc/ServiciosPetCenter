﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO
{
    /// <summary>
    /// Clase para Objeto que describe el resultado de una operacion 
    /// </summary>
    public class Resultado
    {
        /// <summary>
        /// <br/><b>Tipo:</b> Result()
        /// </summary>
        public Resultado()
        {
            this.Estado = false;
            this.CodigoError = "";
            this.Mensaje = "";
            this.Mensajes = new List<Result>();
            this.IdError = new Guid();
        }

        public Object Data { get; set; }

        /// <summary>
        /// Describe si el resultado fue satisfactorio [Verdarero | Falso] 
        /// </summary>
        public bool Estado { get; set; }

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
        /// Contiene una coleccion del tipo List que contiene descripcion de errores adicionales
        /// </summary>
        public List<Result> Mensajes { get; set; }
    }
}
