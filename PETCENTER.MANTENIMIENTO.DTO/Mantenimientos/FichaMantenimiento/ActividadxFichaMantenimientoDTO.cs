using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento
{
    [DataContract]
   public  class ActividadxFichaMantenimientoDTO
    {
        [DataMember(Order = 1)]
       public int CodigoActividadxFichaMantenimiento{get;set;}
        [DataMember(Order = 2)]
      public string Descripcion{get;set;}
        [DataMember(Order = 3)]
      public int CodigoFichaMantenimiento{get;set;}
        [DataMember(Order = 4)]
      public int CodigoActividad{get;set;}
        [DataMember(Order = 5)]
      public string UsuarioCreacion{get;set;}
        [DataMember(Order = 6)]
      public DateTime  FechaHoraCreacion {get;set;}
        [DataMember(Order = 7)]
      public string   UsuarioActualizacion{get;set;}
        [DataMember(Order = 8)]
      public DateTime  FechaHoraActualizacion{get;set;}
        [DataMember(Order = 9)]
      public Boolean  EstadoRegistro{get;set;}
        [DataMember(Order = 10)]
      public string DescripcionActividad { get; set; }
    }
}
