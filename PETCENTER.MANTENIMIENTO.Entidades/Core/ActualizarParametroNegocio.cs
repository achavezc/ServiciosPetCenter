/*
PROYECTO: 
AUTOR: 
FECHA: 06/05/2014 12:58:57 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PETCENTER.MANTENIMIENTO.Entidades.Core
{
    public class ActualizarParametroNegocio
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'IdParametroNegocio'
		/// <br/><b>Tipo:</b> int
		///</summary>
		public int IdParametroNegocio
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'Codigo'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string Codigo
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'Valor'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string Valor
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'ValorRelacionado'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string ValorRelacionado
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'Descripcion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string Descripcion
		{
			get;
			set;
		}

        /// <summary>
        /// <br/><b>Nombre:</b> 'UsuarioActualizacion'
        /// <br/><b>Tipo:</b> string
        ///</summary>
        public string UsuarioActualizacion
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'FechaHoraActualizacion'
        /// <br/><b>Tipo:</b> DateTime
        ///</summary>
        public DateTime FechaHoraActualizacion
        {
            get;
            set;
        }

        /// <summary>
        /// <br/><b>Nombre:</b> 'EstadoRegistro'
        /// <br/><b>Tipo:</b> bool
        ///</summary>
        public bool EstadoRegistro
        {
            get;
            set;
        }
	}
}