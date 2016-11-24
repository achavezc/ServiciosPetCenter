using System.Runtime.Serialization;

namespace PETCENTER.MANTENIMIENTO.DTO.AcuerdosComerciales.AcuerdoComercial.Response
{
    [DataContract]
    public class RegistraAcuerdoComercialLocalResponseDTO : ResponseBaseDTO
    {
        public RegistraAcuerdoComercialLocalResponseDTO()
        {
            this.Result = new Result();
        }
        [DataMember(Order = 0)]
        public int CodigoAcuerdoComercialLocal { get; set; }
    }

}
