using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos
{
  public   class MaterialesxFichaMantenimiento
    {
      public int CodigoMaterialxFichaMantenimiento{get;set;}
     public string  Descripcion{get;set;}
      public int  Cantidad{get;set;}
      public int CodigoFichaMantenimiento{get;set;}
      public int CodigoMaterial{get;set;}
      public string DescripcionMaterial { get; set; }
    }
}
