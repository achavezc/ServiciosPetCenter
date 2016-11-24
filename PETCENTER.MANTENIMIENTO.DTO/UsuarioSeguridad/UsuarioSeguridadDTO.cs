/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PETCENTER.MANTENIMIENTO.DTO
{
	public class UsuarioSeguridadDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoUsuario'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string codigoUsuario
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'aliasUsuario'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string aliasUsuario
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'cuentaUsuarioRed'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string CuentaUsuarioRed
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'nombreUsuario'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string nombreUsuario
		{
			get;
			set;
		}
	}
}