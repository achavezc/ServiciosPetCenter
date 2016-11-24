using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request
{
    public class RequestUsuarioDTO
    {
        public string Usuario { get; set; }
        public string Dominio { get; set; }
    }
}
