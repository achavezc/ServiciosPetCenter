using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Entidades.Mantenimientos
{
    public class Mantenimiento
    {
	public int CodigoMantenimiento{get;set;} 
	public string  Nombre{get;set;}
	public DateTime Fecha{get;set;}
	public string Descripcion{get;set;}
	public int CodigoSolicitud{get;set;}
	public int CodigoTipoMantenimiento{get;set;} 
	public int CodigoArea{get;set;}
	public string UsuarioCreacion{get;set;} 
	public DateTime FechaHoraCreacion{get;set;} 
	public string UsuarioActualizacion{get;set;}
	public DateTime  FechaHoraActualizacion{get;set;} 
	public Boolean  EstadoRegistro{get;set;} 
 
    }
}
