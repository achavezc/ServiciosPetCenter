using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PETCENTER.MANTENIMIENTO.DTO;
using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente;
using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente.Request;
using PETCENTER.MANTENIMIENTO.DTO.Tramarsa.Cliente.Response;
using PETCENTER.MANTENIMIENTO.Entidades.Tramarsa.Cliente;
using PETCENTER.MANTENIMIENTO.Framework;

namespace PETCENTER.MANTENIMIENTO.AgenteServicios.Clientes
{
    public class ClientesProxy : ProxyBaseRest
    {
        public List<ClienteBE> ConsultarCliente(List<string> codigoClienteSAPList)
        {
            var response = DeserializarJSON<List<string>, ConsultaClienteResponseDTO>(codigoClienteSAPList, WebConfigReader.ServicesHost.TramarsaConsultarCliente);
            if (response == null || response.Result.Satisfactorio == false)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("El servicio: {0} no esta disponible o tiene un formato no válido", WebConfigReader.ServicesHost.TramarsaConsultarCliente));
                return new List<ClienteBE>();
            }

            return response.ClienteList.Select(x => { return Helper.MiMapper<ClienteDTO, ClienteBE>(x); }).ToList();
        }

        public List<ClienteCorreoBE> ConsultarClienteCorreo(List<ConsultaClienteCorreoDTO> codigoClienteSAPList)
        {
            var response = DeserializarJSON<List<ConsultaClienteCorreoDTO>, ConsultaClienteCorreoResponseDTO>(codigoClienteSAPList, WebConfigReader.ServicesHost.TramarsaConsultarClienteCorreo);
            if (response == null || response.Result.Satisfactorio == false)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("El servicio: {0} no esta disponible o tiene un formato no válido", WebConfigReader.ServicesHost.TramarsaConsultarClienteCorreo));
                return new List<ClienteCorreoBE>();
            }

            return response.ClienteCorreoDTOList.Select(x => { return Helper.MiMapper<ClienteCorreoDTO, ClienteCorreoBE>(x); }).ToList();
        }

        public List<ClientePorMatchCodeBE> ConsultarClientePorMatchCodes(ConsultaClienteMatchCodeBE codigoClienteMatchCode)
        {
            Mapper.CreateMap<CodigoClienteMatchCodeBE, CodigoClienteMatchCodeDTO>();
            var codigoClienteMatchCodeDTO = Helper.MiMapper<ConsultaClienteMatchCodeBE, ConsultaClienteMatchCodeRequestDTO>(codigoClienteMatchCode);

            var response = DeserializarJSON<ConsultaClienteMatchCodeRequestDTO, ConsultaClienteMatchCodeResponseDTO>(codigoClienteMatchCodeDTO, "http://10.72.20.26:3000/ClienteServicio.svc/ConsultarClientePorMatchCode");//WebConfigReader.ServicesHost.TramarsaConsultarClientePorMatchCodes);
            if (response == null || response.Result.Satisfactorio == false)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("El servicio: {0} no esta disponible o tiene un formato no válido", WebConfigReader.ServicesHost.TramarsaConsultarClientePorMatchCodes));
                return new List<ClientePorMatchCodeBE>();
            }

            return response.ListaClienteMatchCodeDTO.Select(x => { return Helper.MiMapper<ClientePorMatchCodeDTO, ClientePorMatchCodeBE>(x); }).ToList();
        }

        public List<ClienteCodigoClienteBE> ConsultarClienteXCodigoCliente(List<string> codigoClienteList)
        {
            var response = DeserializarJSON<List<string>, ConsultaClienteCodigoResponseDTO>(codigoClienteList, WebConfigReader.ServicesHost.TramarsaConsultarClienteXCodigoCliente);
            if (response == null || response.Result.Satisfactorio == false)
            {
                ManejadorExcepciones.PublicarExcepcion(string.Format("El servicio: {0} no esta disponible o tiene un formato no válido", WebConfigReader.ServicesHost.TramarsaConsultarClienteXCodigoCliente));
                return new List<ClienteCodigoClienteBE>();
            }

            return response.ClienteCodigoList.Select(x => { return Helper.MiMapper<ClienteCodigoClienteDTO, ClienteCodigoClienteBE>(x); }).ToList();
        }
    }
}
