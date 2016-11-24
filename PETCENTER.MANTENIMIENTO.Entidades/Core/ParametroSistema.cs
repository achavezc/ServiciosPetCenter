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

    //using System;
    //using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public class ParametroSistema : AuditoriaBase
    {
        /// <summary>
        /// <br/><b>Nombre:</b> 'IdParametroSistema'
        /// <br/><b>Tipo:</b> int
        ///</summary>
        public int IdParametroSistema
        {
            get;
            set;
        }

        ///// <summary>
        ///// Sociedad Propietaria
        ///// Tipo: string 
        ///// Longitud: 3
        ///// </summary>
        //public string SociedadPropietaria
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// <br/><b>Nombre:</b> 'Codigo'
        ///// <br/><b>Tipo:</b> string
        /////</summary>
        //public string Codigo
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// <br/><b>Nombre:</b> 'Valor'
        ///// <br/><b>Tipo:</b> string
        /////</summary>
        //public string Valor
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// <br/><b>Nombre:</b> 'ValorRelacionado'
        ///// <br/><b>Tipo:</b> string
        /////</summary>
        //public string ValorRelacionado
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// <br/><b>Nombre:</b> 'Descripcion'
        ///// <br/><b>Tipo:</b> string
        /////</summary>
        //public string Descripcion
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Sociedad Propietaria
        /// Tipo: string 
        /// Longitud: 3
        /// </summary>
        public string SociedadPropietaria { get; set; }
        /// <summary>
        /// Codigo
        /// Tipo: int 
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Valor
        /// Tipo: string 
        /// Longitud: 50
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Valor Relacionado
        /// Tipo: string 
        /// Longitud: 50
        /// </summary>
        public string ValorRelacionado { get; set; }
        /// <summary>
        /// Descripcion
        /// Tipo: string 
        /// Longitud: 250
        /// </summary>
        public string Descripcion { get; set; }
    }
}