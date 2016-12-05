using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.FichaMantenimiento
{
    [DataContract]
    public class FichaMantenimientoDTO
    {
        [DataMember(Order = 0)]
        public int CodigoFichaMantenimiento{ get; set; } 
        [DataMember(Order = 1)]
        public int CodigoMantenimiento { get; set; }
        [DataMember(Order = 2)]
        public int CodigoSolicitud { get; set; }
        [DataMember(Order = 3)]
        public int CodigoTipoMantenimiento { get; set; }
        [DataMember(Order = 4)]
        public string  DescripcionTipoMantenimiento { get; set; }
        [DataMember(Order = 5)]
        public int CodigoEmpleadoAprueba { get; set; }
        [DataMember(Order = 6)]
        public string  NombreEmpleadoAprueba { get; set; }
        [DataMember(Order = 7)]
        public int CodigoArea { get; set; }
        [DataMember(Order = 8)]
        public string  DescripcionAreaMantenimiento { get; set; }
        [DataMember(Order = 9)]
        public string  DescripcionFichaMantenimiento { get; set; }
        [DataMember(Order = 10)]
        public DateTime  FechaFichaMantenimiento { get; set; }
        [DataMember(Order = 11)]
        public DateTime FechaInicioFichaMantenimiento { get; set; }
        [DataMember(Order = 12)]
        public DateTime FechaFinFichaMantenimiento { get; set; }
        [DataMember(Order = 13)]
        public int CantidadTecnicosFichaMantenimiento { get; set; }
        [DataMember(Order = 14)]
        public int CodigoEstadoFichaMantenimiento  { get; set; }
        [DataMember(Order = 14)]
        public string DescrpcionEstadoFichaMantenimiento   { get; set; }
        [DataMember(Order = 15)]
        public string UsuarioCreacion { get; set; }
        [DataMember(Order = 16)]
        public DateTime  FechaHoraCreacion { get; set; }
        [DataMember(Order = 17)]
        public string  UsuarioActualizacion { get; set; }
        [DataMember(Order = 18)]
        public DateTime  FechaHoraActualizacion { get; set; }
        [DataMember(Order = 18)]
        public Boolean  EstadoRegistro { get; set; }
        [DataMember(Order = 19)]
        public int CodigoSede { get; set; }
        [DataMember(Order = 20)]
        public String  DescripcionSedeMantenimiento  { get; set; }
    }
}
