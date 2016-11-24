using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Request;
using PETCENTER.MANTENIMIENTO.LogicaNegocio;
using PETCENTER.MANTENIMIENTO.DTO.UsuarioSeguridad.Response;
using PETCENTER.MANTENIMIENTO.Framework;
using PETCENTER.MANTENIMIENTO.DTO;
using System.Reflection;

namespace PETCENTER.MANTENIMIENTO.ServicioWCF.SEGURIDAD
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SeguridadServicio : ISeguridadServicio
    {
        //[Log]
        //public GenerarClaveUsuarioResponseDTO GenerarClaveUsuario(GenerarClaveUsuarioRequestDTO request)
        //{
        //    GenerarClaveUsuarioResponseDTO response = new GenerarClaveUsuarioResponseDTO();

        //    try
        //    {
        //        SeguridadBL seguridadBL = new SeguridadBL();
        //        response = seguridadBL.ResetearContrasenia(request);

        //        return response;
        //    }
        //    catch (ResultException ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, ex.Result.Mensaje));
        //        ex.Result.Satisfactorio = false;
        //        response.Result = ex.Result;

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result { IdError = Guid.NewGuid(), Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio" };
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);

        //        return response;
        //    }
        //}

        ////[Log]
        //public CambiarClaveUsuarioResponseDTO CambiarClaveUsuario(CambiarClaveUsuarioRequestDTO request)
        //{
        //    CambiarClaveUsuarioResponseDTO response = new CambiarClaveUsuarioResponseDTO();

        //    try
        //    {
        //        SeguridadBL seguridadBL = new SeguridadBL();
        //        response = seguridadBL.CambiarClaveUsuario(request);

        //        return response;
        //    }
        //    catch (ResultException ex)
        //    {
        //        ManejadorExcepciones.PublicarExcepcion(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, ex.Result.Mensaje));
        //        ex.Result.Satisfactorio = false;
        //        response.Result = ex.Result;

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Result = new Result { IdError = Guid.NewGuid(), Satisfactorio = false, Mensaje = "Ocurrio un problema interno en el servicio" };
        //        ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.LogicaNegocio);

        //        return response;
        //    }
        //}


        public GenerarClaveUsuarioResponseDTO GenerarClaveUsuario(GenerarClaveUsuarioRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public CambiarClaveUsuarioResponseDTO CambiarClaveUsuario(CambiarClaveUsuarioRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
