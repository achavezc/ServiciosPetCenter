using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Request
{
    public class RequestRolesClientesSAPDTO
    {
        public Codigo codigo { get; set; }


    }
    public class Codigo
    {
        public string SociedadPropietaria
        {
            get;
            set;
        }
    }
}
