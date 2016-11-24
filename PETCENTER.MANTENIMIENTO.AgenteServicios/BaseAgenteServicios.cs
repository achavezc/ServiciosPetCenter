/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:29 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PETCENTER.MANTENIMIENTO.Framework;

namespace PETCENTER.MANTENIMIENTO.AgenteServicios
{
    public class BaseAgenteServicios
    {
        protected Y DeserializarJSON<T, Y>(T request, string url, string soapAction = "", bool consultaSap = false)
        {
            var utilitarioRest = new UtilitarioRest();
            return utilitarioRest.DeserializarJSON<T, Y>(request, url, soapAction, consultaSap);
        }

        protected Y DeserializarXML<T, Y>(T request, string url, string soapAction = "", bool consultaSap = false)
        {
            var utilitarioRest = new UtilitarioRest();
            return utilitarioRest.DeserializarJSON<T, Y>(request, url, soapAction, consultaSap,ContentType.XML);
        }

        //protected string ObtenerUrlServicio(ConstantesParametrosSistema parametrosSistema, string sociedadPropietaria)
        //{

        //    var contexto = new ContextoParaBaseDatos();

        //    var repositorioParametroSistema = new RepositorioParametroSistema(contexto);

        //    ParametroSistema parametroSistema = repositorioParametroSistema.ObtenerParametroSistema(parametrosSistema, sociedadPropietaria);

        //    string url = parametroSistema.Valor;

        //    return url;

        //}
    }
}