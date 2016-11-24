using GR.COMEX.Comercial.DTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.COMEX.Comun.DTO
{
    /// <summary>
    /// Clase para Response Grabar Parametro Sistema
    /// </summary>
    public class ResponseGrabarParametroSistemaDTO : ResponseOperacionesComexDTO
    {
        /// <summary>
        /// Id Parametro Sistema
        /// <br/><b>Tipo:</b> int? 
        /// </summary>
        public int? IdParametroSistema { get; set; }
    }
}
