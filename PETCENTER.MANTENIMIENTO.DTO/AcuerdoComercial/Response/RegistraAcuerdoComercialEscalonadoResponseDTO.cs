using System.Runtime.Serialization;

namespace PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Response
{
    [DataContract]
    public class RegistraAcuerdoComercialEscalonadoResponseDTO : ResponseBaseDTO
    {
        public RegistraAcuerdoComercialEscalonadoResponseDTO()
        {
            this.Result = new Result();
        }

        public int CodigoAcuerdoComercialEscalonado { get; set; }
    }

}
