using PETCENTER.MANTENIMIENTO.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.DTO.Core;

namespace PETCENTER.MANTENIMIENTO.DTO
{
    /// <summary>
    /// Clase para Request Busqueda Parametro Sistema
    /// </summary>
    public class RequestBusquedaParametroSistemaDTO : RequestOperacionBusquedaDTO
    {
        /// <summary>
        /// Código de Sociedad Propietaria
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 18
        /// </summary>
        public string CodigoSociedadPropietaria { get; set; }

        /// <summary>
        /// Codigo
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 3
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descripcion
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 255
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado Registro
        /// <br/><b>Tipo:</b> int? 
        /// </summary>
        public int? EstadoRegistro { get; set; }
    }
}
