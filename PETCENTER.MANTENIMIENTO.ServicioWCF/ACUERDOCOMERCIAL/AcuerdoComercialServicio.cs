using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TRAMARSA.RECLAMOS.DTO;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.AcuerdoComercial.Response;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion.Request;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Notificacion.Response;
using TRAMARSA.RECLAMOS.DTO.AcuerdosComerciales.Tarifa.Response;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Request;
using TRAMARSA.RECLAMOS.DTO.Tramarsa.Cliente.Response;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.AcuerdoComercial;
using TRAMARSA.RECLAMOS.Entidades.AcuerdosComerciales.Notificacion;
using TRAMARSA.RECLAMOS.Entidades.Tramarsa.Cliente;
using TRAMARSA.RECLAMOS.Framework;
using TRAMARSA.RECLAMOS.LogicaNegocio;

namespace TRAMARSA.RECLAMOS.ServicioWCF.ACUERDOCOMERCIAL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LiberacionBLServicio" en el código y en el archivo de configuración a la vez.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AcuerdoComercialServicio : IAcuerdoComercialServicio
    {
        
        private Result NotificarValidacion(NotificacionRequest request)
        {
            try
            {
                //TODOS LOS GUID DEBE DE ESTAR LLENOS PARA IDENTIFICAR LA NOTIFICACION
                request.NotificacionList.ForEach(x =>
                {
                    Guid guidConverted;
                    if (!Guid.TryParse(x.Guid.ToString(), out guidConverted))
                        throw new Exception("El campo Guid debe de contener datos");
                });

                //NINGUN GUID DEBE ESTAR REPETIDA
                var result = request.NotificacionList.GroupBy(x => x.Guid)
                               .Select(y => new { y.Key, Count = y.Count() })
                               .Where(z => z.Count > 1).ToList();

                if (result.Any())
                    throw new Exception("El campo Guid no puede estar repetido");

                request.NotificacionList.ForEach(x =>
                {
                    if (string.IsNullOrEmpty(x.De))
                        throw new Exception("El campo DE debe de contener datos");

                    if (!x.CuerpoValues.Any())
                        throw new Exception("El campo CuerpoKeyvalue debe de contener datos");

                    if (!x.CuerpoValues.Any())
                        throw new Exception("El campo CuerpoKeyvalue debe de contener datos");

                    if (!x.Para.Any())
                        throw new Exception("El campo Para debe de contener datos");
                    else
                        x.Para.ForEach(xy =>
                        {
                            if (string.IsNullOrEmpty(xy))
                                throw new Exception("El campo Para debe de contener datos");
                        });
                });

                return new Result { Satisfactorio = true };

            }
            catch (Exception ex)
            {
                return new Result { Satisfactorio = false, Mensaje = ex.Message };
            }
        }

        [Log]
        public NotificacionResponse Notificar(NotificacionRequest request)
        {
            Result result = new Result();
            NotificacionResponse response = new NotificacionResponse();
            try
            {
                result = this.NotificarValidacion(request);
                if (result.Satisfactorio == false)
                    throw new Exception(result.Mensaje);

                //(new NotificacionBL()).Notificar(request.NotificacionList);

                response.Result = new Result { Satisfactorio = true };
                return response;
            }
            catch (Exception ex)
            {
                response.Result = new Result { Satisfactorio = false, Mensaje = ex.Message };
                return response;
            }
        }
 
        //[Log]
        //public ConsultaClienteCorreoResponseDTO ConsultarClienteCorreo(List<ConsultaClienteCorreoDTO> request)
        //{
        //    ConsultaClienteCorreoResponseDTO response = new ConsultaClienteCorreoResponseDTO();
        //    try
        //    {
        //        //var consultaClienteCorreoBEList = request.ClienteCorreoList.Select(x => { return Helper.MiMapper<ConsultaClienteCorreoDTO, ConsultaClienteCorreoBE>(x); }).ToList();

        //        var consultaClienteCorreoDTOList = (new ClienteBL()).ConsultarClienteCorreo(request);

        //        response.ClienteCorreoDTOList = consultaClienteCorreoDTOList.Select(x => { return Helper.MiMapper<ClienteCorreoBE, ClienteCorreoDTO>(x); }).ToList();

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
        //        response.Result = new Result { Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio", IdError = Guid.NewGuid() };
        //        return response;
        //    }

        //}

        //[Log]
        //public ConsultaContenedoresNoDevueltosResponseDTO ConsultarContenedoresNoDevueltos(ConsultaContenedoresNoDevueltosRequestDTO request)
        //{
        //    ConsultaContenedoresNoDevueltosResponseDTO response = new ConsultaContenedoresNoDevueltosResponseDTO();
        //    try
        //    {
        //        var requestBE = Helper.MiMapper<ConsultaContenedoresNoDevueltosRequestDTO, ConsultaContenedorNoDevueltoBE>(request);

        //        List<ContenedoresNoDevueltosBE> contenedoresNoDevueltasDTO = (new AComercialBL()).ConsultarContenedoresNoDevueltos(requestBE);

        //        response.LiquidacionesNoDevueltas = contenedoresNoDevueltasDTO.Select(x => { return Helper.MiMapper<ContenedoresNoDevueltosBE, LiquidacionesNoDevueltasDTO>(x); }).ToList();

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
        //        response.Result = new Result { Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio", IdError = Guid.NewGuid() };
        //        return response;
        //    }
        //}

        //[Log]
        //public ConsultaDetalleContenedorNoDevueltoDTO ConsultarDetalleContenedoresNoDevueltos(ConsultaContenedoresNoDevueltosRequestDTO request)
        //{
        //    ConsultaDetalleContenedorNoDevueltoDTO response = new ConsultaDetalleContenedorNoDevueltoDTO();
        //    try
        //    {
        //        var requestBE = Helper.MiMapper<ConsultaContenedoresNoDevueltosRequestDTO, ConsultaContenedorNoDevueltoBE>(request);

        //        DetalleContenedorNoDevueltoBE detalleContenedoresNoDevueltasDTO = (new AComercialBL()).ConsultarDetalleContenedoresNoDevueltos(requestBE);

        //        //Mapper.CreateMap<LiquidacionesNoDevueltoBE, LiquidacionesNoDevueltasDTO>();
        //        //
        //        //response.LiquidacionesNoDevueltas = DetalleContenedoresNoDevueltasDTO.Select(x => { return Helper.MiMapper<DetalleContenedorNoDevueltoBE, ConsultaDetalleContenedorNoDevueltoDTO>(x); }).ToList();

        //        Mapper.CreateMap<ContenedoresNoDevueltosBE, LiquidacionesNoDevueltasDTO>();
        //        response = Helper.MiMapper<DetalleContenedorNoDevueltoBE, ConsultaDetalleContenedorNoDevueltoDTO>(detalleContenedoresNoDevueltasDTO);
        //            //lstDetalleContenedoresNoDevueltasDTO.Select(x => { return Helper.MiMapper<DetalleContenedorNoDevueltoBE, ConsultaDetalleContenedorNoDevueltoDTO>(x); }).FirstOrDefault();
        //            //Helper.MiMapper<DetalleContenedorNoDevueltoBE, ConsultaDetalleContenedorNoDevueltoDTO>(lstDetalleContenedoresNoDevueltasDTO);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
        //        response.Result = new Result { Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio", IdError = Guid.NewGuid() };
        //        return response;
        //    }
        //}

        //[Log]
        //public NotificarContenedoresNoDevueltosResponseDTO NotificarContenedoresNoDevueltos(string codigoLinea)
        //{
        //    NotificarContenedoresNoDevueltosResponseDTO response = new NotificarContenedoresNoDevueltosResponseDTO();
        //    try
        //    {
        //        var result = (new AComercialBL()).NotificarContenedoresNoDevueltos(codigoLinea);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.ServicioWCF);
        //        response.Result = new Result { Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio", IdError = Guid.NewGuid() };

        //        return response;
        //    }
        //}

         
    }
}