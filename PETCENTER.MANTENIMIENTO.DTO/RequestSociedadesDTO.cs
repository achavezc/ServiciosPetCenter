using GR.COMEX.Comun.Entidades.SAP;

namespace TRAMARSA.WA.CM.DTO
{
    /// <summary>
    /// Clase para Request Sociedades
    /// </summary>
    public class RequestSociedadesDTO : RequestBaseDTO
    {
        /// <summary>
        /// Request Sociedades SAP

        /// <br/><b>Tipo:</b> RequestSociedadSAP 
        /// </summary>
        public RequestSociedadSAP RequestSociedadesSAP
        {
            get;
            set;
        }
    }
}