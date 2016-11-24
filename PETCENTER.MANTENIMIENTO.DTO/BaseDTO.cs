/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PETCENTER.MANTENIMIENTO.Entidades.Constantes;

namespace PETCENTER.MANTENIMIENTO.DTO
{
	public class BaseDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'errores'
		/// <br/><b>Tipo:</b> Dictionary<string, string>
		///</summary>
		public Dictionary<string, string> errores
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'estadoOperacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string estadoOperacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoEstadoOperacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string codigoEstadoOperacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'mensajes'
		/// <br/><b>Tipo:</b> Dictionary<string, string>
		///</summary>
		public Dictionary<string, string> mensajes
		{
			get;
			set;
		}

		public void GrabarRespuestas(string mensaje, string estadoOperacion, Exception ex)
		{
            this.estadoOperacion = estadoOperacion;
            if (estadoOperacion == ConstantesSistema.EstadoOperacionServicioCorrecto)
                codigoEstadoOperacion = ConstantesRespuestaSAP.TypeOK;
            else
                if (estadoOperacion == ConstantesSistema.EstadoOperacionServicioError)
                    codigoEstadoOperacion = ConstantesRespuestaSAP.TypeError;

            switch (this.estadoOperacion)
            {
                case ConstantesSistema.EstadoOperacionServicioError:
                    if (this.errores == null)
                    {
                        this.errores = new Dictionary<string, string>();
                    }
                    this.errores.Add("0", mensaje);
                    break;
                case ConstantesSistema.EstadoOperacionServicioCorrecto:
                    if (this.mensajes == null)
                    {
                        this.mensajes = new Dictionary<string, string>();
                    }
                    this.mensajes.Add("0", mensaje);
                    break;
            }
		}
	}
}