using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento
{
[DataContract]
    public class MaterialesxFichaMantenimientoListDTO
    {
    [DataMember(Order = 1)]
    public int CodigoMaterialxFichaMantenimiento {get;set;}
    [DataMember(Order = 2)]
 public string Descripcion {get;set;}
    [DataMember(Order = 3)]
 public int  Cantidad {get;set;}
 //   [DataMember(Order = 4)]
 //public int CodigoFichaMantenimiento {get;set;}
    [DataMember(Order = 5)]
 public int CodigoMaterial {get;set;}
    [DataMember(Order = 6)]
 public string Accion { get; set; }
    }
}
