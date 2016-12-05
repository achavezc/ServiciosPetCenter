using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Mantenimiento
{
   public class MantenimientoDTO
    {
     public int CodigoSolicitud{get;set;}
public string   DescripcionSolicitud {get;set;}
public int  CodigoMantenimiento  {get;set;}
public string   NombreMantenimiento  {get;set;}
public DateTime    FechaMantenimiento {get;set;}
public string  DescripcionMantenimiento   {get;set;}
public int   CodigoTipoMantenimiento {get;set;}
public string   DescripcionTipoMantenimiento {get;set;}
public int CodigoArea {get;set;}
public string   DescripcionAreaMantenimiento {get;set;}
public int CodigoSede {get;set;}
public string   DescripcionSedeMantenimiento {get;set;}
public string   UsuarioCreacion {get;set;}
public DateTime FechaHoraCreacion {get;set;}
public string  UsuarioActualizacion {get;set;}
public DateTime FechaHoraActualizacion {get;set;}
public Boolean  EstadoRegistro {get;set;}
public int CodigoEmpleadoRegistra  {get;set;}
public string   NombreEmpleadoRegistra {get;set;}
    }
}
