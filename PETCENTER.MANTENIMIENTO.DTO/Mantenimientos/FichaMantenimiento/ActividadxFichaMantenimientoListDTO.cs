using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento
{
    [DataContract]
    public class ActividadxFichaMantenimientoListDTO

    {
        [DataMember(Order = 1)]
           public int CodigoActividadxFichaMantenimiento {get;set;}
        [DataMember(Order = 2)]
       public string  Descripcion  {get;set;}
      //  [DataMember(Order = 3)]
     //  public int CodigoFichaMantenimiento {get;set;}
        [DataMember(Order = 4)]
       public int CodigoActividad {get;set;}
        //[DataMember(Order = 5)]
     //  public string  UsuarioCreacion {get;set;}
      //  [DataMember(Order = 6)]
	  // public DateTime  FechaHoraCreacion {get;set;}
        [DataMember(Order = 7)]
	   public string  Accion {get;set;}
  
        
        //public int CodigoFichaMantenimiento {get;set;}
        //[DataMember(Order = 2)]
        //public int CodigoMantenimiento {get;set;}
        //[DataMember(Order = 3)]
        //public int CodigoSolicitud {get;set;}
        //[DataMember(Order = 4)]
        //public int CodigoTipoMantenimiento {get;set;}
        //[DataMember(Order = 5)]
        ////public int CodigoEmpleado {get;set;}
        //[DataMember(Order = 6)]
        //public int CodigoSede {get;set;}
        //[DataMember(Order = 7)]
        //public int CodigoArea {get;set;}
        //[DataMember(Order = 1)]
        //public string  Descripcion {get;set;}
        //[DataMember(Order = 2)]
        //public DateTime  Fecha {get;set;}
        //[DataMember(Order = 3)]
        //public DateTime  FechaInicio {get;set;}
        //[DataMember(Order = 4)]
        //public DateTime  FechaFin {get;set;}
        //[DataMember(Order = 5)]
        //public int CantidadTecnicos {get;set;}
        //[DataMember(Order = 6)]
        //public int Estado {get;set;}
        //[DataMember(Order = 7)]
        //public string  UsuarioRegistro {get;set;}
        //[DataMember(Order = 8)]
        //public DateTime  FechaHoraRegistro {get;set;}
        //[DataMember(Order = 9)]
        //public string Accion { get; set; }
    }
}
