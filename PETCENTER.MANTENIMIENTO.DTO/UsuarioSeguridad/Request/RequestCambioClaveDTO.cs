using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request
{
    public class RequestCambioClaveDTO
    {
        public TipoCambioClave TipoCambioClave { get; set; }
        public string CodigoUsuario { get; set; }
        public string ClaveAntigua { get; set; }
        public string ClaveNueva { get; set; }
        public string ClaveNuevaConfirmada { get; set; }
        public string Dominio { get; set; }
        public string Acronimo { get; set; }
    }

    public enum TipoCambioClave
    {
        Sys = 0,
        Ui = 1
    }
}
