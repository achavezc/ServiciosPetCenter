using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento.Request
{
    
    public class RegistrarFichaMantenimientoRequestDTO
    {
        public RegistrarFichaMantenimientoRequestDTO()
        {
            this.ActividadxFichaMantenimientoList = new List<ActividadxFichaMantenimientoListDTO> ();
            this.MaterialesxFichaMantenimientoList = new List<MaterialesxFichaMantenimientoListDTO>();
        }
    public int CodigoFichaMantenimiento {get;set;}
    public int CodigoMantenimiento {get;set;}
    //public int CodigoSolicitud {get;set;}
    //public int CodigoTipoMantenimiento {get;set;}
    public int CodigoEmpleado {get;set;}
    //public int CodigoSede {get;set;}
    //public int CodigoArea {get;set;}
    public string  Descripcion {get;set;}
    public DateTime  Fecha {get;set;}
    public DateTime FechaInicio {get;set;}
    public DateTime FechaFin {get;set;}
    public int CantidadTecnicos {get;set;}
    public int Estado {get;set;}
    public string UsuarioRegistro {get;set;}
    public DateTime FechaHoraRegistro {get;set;}
    public string Accion { get; set; }

    public List<ActividadxFichaMantenimientoListDTO> ActividadxFichaMantenimientoList { get; set; }

    public List<MaterialesxFichaMantenimientoListDTO> MaterialesxFichaMantenimientoList { get; set; }



    }
}
