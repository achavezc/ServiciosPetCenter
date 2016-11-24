using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PETCENTER.MANTENIMIENTO.Entidades
{
    /// <summary>
    /// clase para Maestro Base
    /// </summary>
    //[Serializable]
    //[DataContract]
    public class PaginacionBase
    {
        public string OrdenCampo { get; set; }
        public string OrdenOrientacion { get; set; }
        public int? PaginaActual { get; set; }
        public int? NroRegistrosPorPagina { get; set; }



    }
}

