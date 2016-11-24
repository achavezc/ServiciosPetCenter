using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.RolesCliente.Response
{
    public class ResponseConsultaRolesClientesSapDTO : BaseSapDTO
    {
        public ResponseConsultaRolesClientesSapDTO()
        {
            this.ListaRolesClientes = new List<ResponseRolesClientesSAP>();
        }
        /// <summary>
        /// Lista de ResponseRolesClientesSAP
        /// <br/><b>Tipo:</b> List<ResponseRolesClientesSAP> 
        /// </summary>
        public List<ResponseRolesClientesSAP> ListaRolesClientes { get; set; }
    }
}
