using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Solicitud
{   [DataContract]
   public class MantenimientoListDTO
    {
        [DataMember (Order=1)]
     public int   CodigoMantenimiento {get; set;}
    [DataMember(Order = 2)]
     public string Nombre {get; set;}
    [DataMember(Order = 3)]
     public DateTime  Fecha {get; set;}
    [DataMember(Order = 4)]
     public string Descripcion {get; set;}
    //[DataMember(Order = 5)]
    // public int CodigoSolicitud {get; set;}
    //[DataMember(Order = 6)]
    // public int CodigoTipoMantenimiento {get; set;}
    //[DataMember(Order = 7)]
    // public int CodigoArea {get; set;}
    [DataMember(Order = 6)]
     public string  UsuarioCreacion {get; set;}
    [DataMember(Order = 7)]
     public DateTime  FechaHoraCreacion {get; set;}
    [DataMember(Order = 8)]
     public string Accion { get; set; }
    }
}
