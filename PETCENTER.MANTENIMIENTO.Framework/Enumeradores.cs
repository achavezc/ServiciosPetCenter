using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PETCENTER.MANTENIMIENTO.Framework
{
    //Los que son valores de Catalogo de Tablas, deben coincidir con la columna CodigoTabla de la tabla CatalogoTablas
    public enum KeyCache
    {
        Sucursal,
        TerminalPortuario,
        ConsultaLineas,
        ConsultaMonedas,
        ConsultaNaves,
        ConsultaTarifas,
        ConsultaDistribucionTarifa,
        ConsultaPuertos,
        ConsultasBLS,
        ConsultaClientes,
        ConsultaDetalleCatalogo,
        ConsultaGrupoPuertoExterno,
        ParametrosNegocio,
        ParametroSistema,
        RolesClienteSAP,
        TipoContenedor,
        ClaseContenedor,
        ConsultaCatalogoTablas,
        Pais,

        //Agregando los keys del Cache | 
        Sede,
        Negocio,
        TipoReclamo,
        SubTipoReclamo,
        TipoDevolucion,
        Flujo,
        //mantenimiento local
        TipoMantenimiento,
        EstadoSolicitud,
        Area
    }

    public enum Accion {
      
        [Description("I")]
        Insertar = 1,

        [Description("U")]
        Actualizar = 2,

        [Description("D")]
        Eliminar = 3,

        [Description("N")]
        Ninguno = 4
    }

    public enum CodigoTipoPuerto
    {
        [Description("001")]
        Origen = 1,

        [Description("002")]
        Embarque = 2,

        [Description("003")]
        Descarga = 3,

        [Description("004")]
        Final = 4
    }

    public enum TipoAcuerdoComercial
    {
        [Description("L")]
        Local = 1,

        [Description("E")]
        Escalonado = 2
    }
 
}