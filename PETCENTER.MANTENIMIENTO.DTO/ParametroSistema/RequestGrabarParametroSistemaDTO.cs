using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAMARSA.RECLAMOS.DTO
{
    /// <summary>
    /// Clase para Request Grabar Parametro Sistema
    /// </summary>
    public class RequestGrabarParametroSistemaDTO : RequestBaseDTO
    {
        /// <summary>
        /// Parametro Sistema
        /// <br/><b>Tipo:</b> ParametroSistemaDTO 
        /// </summary>
        public ParametroSistemaDTO ParametroSistemaDTO { get; set; }

        /// <summary>
        /// Usuario
        /// <br/><b>Tipo:</b> UsuarioSimplificadoDTO 
        /// </summary>
        public UsuarioSimplificadoDTO Usuario { get; set; }
    }
}
