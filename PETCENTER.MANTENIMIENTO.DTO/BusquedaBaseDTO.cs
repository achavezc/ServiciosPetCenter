namespace PETCENTER.MANTENIMIENTO.DTO
{
    using System.Collections.Generic;

    /// <summary>
    /// Clase para Resultado Busqueda Base DTO
    /// </summary>
    public abstract class ResultadoBusquedaBaseDTO<T> : BaseDTO
          //where T : class
    {
        /// <summary>
        /// Lista que contiene los resultados de la búsqueda
        /// </summary>
        public virtual List<T> ResultadoBusqueda
        {
            get;
            set;
        }

        /// <summary>
        /// número de registros devueltos
        /// </summary>
        public int NroRegistros { get; set; }
    }
}