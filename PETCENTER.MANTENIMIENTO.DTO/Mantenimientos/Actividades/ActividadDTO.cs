﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.DTO.Mantenimientos.Actividades
{

    public class ActividadDTO
    {

      public int CodigoActividad{get;set;}

       public string Nombre{get;set;}

      public string UsuarioCreacion{get;set;}
        
      public DateTime FechaHoraCreacion{get;set;}
        
      public string UsuarioActualizacion{get;set;}
        
      public DateTime FechaHoraActualizacion{get;set;}
        
      public Boolean  EstadoRegistro{get;set;}

    }
}