using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.DTO;

namespace GR.COMEX.Comun.DTO
{
    /// <summary>
    /// Clase para Resultado Fila Parametro Sistema
    /// </summary>
    public class ResultadoFilaParametroSistemaDTO : ParametroSistemaDTO
    {
        /// <summary>
        /// Estado
        /// <br/><b>Tipo:</b> string 
        /// <br/><b>Longitud:</b> 10
        /// </summary>
        public string Estado { get; set; }
    }
}
