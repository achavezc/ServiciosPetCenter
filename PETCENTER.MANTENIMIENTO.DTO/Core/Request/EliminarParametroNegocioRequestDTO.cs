using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Core.Request
{

    [DataContract]
    public class EliminarParametroNegocioRequestDTO
	{
        /// <summary>
        /// <br/><b>Nombre:</b> 'IdParametroNegocio'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        [DataMember]
        public int IdParametroNegocio
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'UsuarioActualizacion'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        [DataMember]
        public string UsuarioActualizacion
        {
            get;
            set;
        }
	}
}