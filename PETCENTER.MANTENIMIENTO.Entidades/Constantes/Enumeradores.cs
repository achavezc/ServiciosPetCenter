using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PETCENTER.MANTENIMIENTO.Entidades.Constantes
{
    /// <summary>
    /// Tabla Tablas
    /// Tipo: enum 
    /// </summary>
    public enum TablaTablas
    {
        EstadoRegistro = 1,
        Aduanas = 96,
        TiposManifiesto = 97,
        ViasTransporte = 98,
        TiposDocumento = 101
    }

    /// <summary>
    /// Constantes Parametros Negocio
    /// Tipo: enum 
    /// </summary>
    public enum ConstantesParametrosNegocio
    {
        AmbienteDB = 1,
        AmbienteScriptor = 2,
        DenominacionGerarquiProducto = 3,
        GrupoArticuloExternoTarifa = 4,
        CodigoSector = 5,
        CodigoCanal = 6,
        CodigoCategoria = 7,
        CodigoMarca = 8,
        CodigoFamilia = 9,
        CodigoVariedad = 10,

        AccionNuevo = 12,
        AccionModificar = 13,
        CorreoNotificaciones = 14,
        Cotizaciones = 15,
        AcuerdoComercial = 16,
        CodigoTarifaEscalonado = 47,
        CodigoLinea = 48,
        MonedaAcuerdo = 49,
        ClienteTipoCorreo = 50,
        CodigoTarifaMaestraDefault = 54,
        CodigoConceptoMaestroDefault = 55,

        MensajeIngresarTarifaLocal,
        MensajeIngresarTarifaEscalonada,
        MensajeInhabilitarTarifaLocal,
        MensajeInhabilitarTarifaEscalonada,
        MensajeModificarSeccionGeneral,
        MensajeModificarSeccionVigencia,
        MensajeModificarSeccionSucursal,
        MensajeModificarSeccionTerminalPortuario,
        MensajeModificarSeccionTarifaLigada,
        MensajeValidacionIngresoTarifaLocal,
        MensajeValidacionEdicionTarifaLocal,
        MensajeValidacionEdicionTarifaLocalLigada,
        MensajeValidacionIngresoTarifaEscalonada,
        MensajeValidacionEdicionTarifaEscalonada,
        MensajeValidacionEdicionTarifaEscalonadaLigada,
        MensajeIngresarACLocal,
        MensajeIngresarACEscalonado,
        MensajeInhabilitarACLocal,
        MensajeInhabilitarACEscalonado,
        MensajeModificarSeccionRA,
        MensajeModificarSeccionPuerto,
        MensajeModificarSeccionClienteBLMaster,
        MensajeModificarSeccionAgenteBLMaster,
        MensajeModificarSeccionClienteBLHouse,
        MensajeModificarSeccionAgenteBLHouse,
        MensajeModificarSeccionServicioNave,
        MensajeModificarSeccionServicioBL,
        MensajeModificarSeccionTipoContenedor,
        MensajeModificarSeccionCarga,
        MensajeModificarSeccionTipoCarga,
        MensajeModificarSeccionTarifa,
        MensajeValidacionModificarRAACLocal,
        MensajeValidacionEdicionACLocalLigada,
        MensajeValidacionModificarACRAEscalonada,
        MensajeValidacionEdicionACEscalonadaLigada,
        MensajeModificarSeccionTarifaPeriodo,
        CodigoAutorizadorRAPT,
        CodigoRolClienteDefault,
        MensajeValidacionTarifaEnAcuerdoComercialLocal,
        MensajeValidacionTarifaEnAcuerdoComercialEscalonado
        //</>
    }

    /// <summary>
    /// Constantes Parametros Sistema
    /// Tipo: enum 
    /// </summary>
    public enum ConstantesParametrosSistema
    {
        //NumeroFilasGrid = 1,
        //ExpiracionCacheHoras = 2,
        //UrlServicioConsultaSedes = 3,
        //UrlServicioBusquedaClientes = 4,
        //UrlServicioBusquedaClientesDetallada = 5,
        //UrlServicioConsultaRoles = 6,
        //UrlServicioMaestroClientes = 7,
        //UrlServicioConsultaSociedades = 8,
        RutaFisicaArchivos = 1,
        AmbienteScriptor = 2
        //MaxFiles = 10,
        //MaxSize = 11,
        //RutaLogicaArchivos = 10,
        //ExtensionesPermitidas = 13,
        //EntornoEjecucion = 16
    }
    /// <summary>
    /// Modo Acceso Pagina
    /// Tipo: enum 
    /// </summary>
    public enum ModoAccesoPagina
    {
        Visualizar,
        Modificar,
        Nuevo
    }
    /// <summary>
    /// Tipos Documentos Comercial
    /// Tipo: enum 
    /// </summary>
    public enum TiposDocumentosComercial
    {
        Cotizacion = 1,
        AcuerdoComercial = 2,
        Adendas = 3
    }
    /// <summary>
    /// Estado Registro
    /// Tipo: enum 
    /// </summary>
    public enum EstadoRegistro
    {
        [Description("Activo")]
        Activo = 1,

        [Description("Inactivo")]
        Inactivo = 0
    }

    /// <summary>
    /// Estado
    /// Tipo: enum 
    /// </summary>
    public enum Estado
    {
        Activo = 1,
        Inactivo = 0
    }

    /// <summary>
    /// clase para Estado Bloqueo Clientes
    /// </summary>
    public class EstadoBloqueoClientes
    {
        /// <summary>
        /// bool
        /// Tipo: const 
        /// </summary>
        public const bool Activo = true;
        /// <summary>
        /// bool
        /// Tipo: const 
        /// </summary>
        public const bool Inactivo = false;
    }

    /// <summary>
    /// Errores Cliente SAP
    /// Tipo: enum 
    /// </summary>
    public enum ErroresClienteSAP
    {
        RegistroExitoso = 171,
        ExtensionExitosa = 172,
        ClienteExistente = 117

    }

    /// <summary>
    /// Errores Servicio
    /// Tipo: enum 
    /// </summary>
    public enum ErroresServicio
    {
        ServicioExistente = 1,
    }

    /// <summary>
    /// Errores Documento Asociado Tipo
    /// Tipo: enum 
    /// </summary>
    public enum ErroresDocumentoAsociadoTipo
    {
        DocumentoAsociadoTipoExistente = 1,
    }

    /// <summary>
    /// Constantes SAP
    /// Tipo: enum 
    /// </summary>
    public enum ConstantesSAP
    {
        ExtenderCNP = 1,
        ExtenderTramarsa = 2,
        ExtenerOrgVentasTramarsa = 3
    }

    /// <summary>
    /// clase para Tipos Documento
    /// </summary>
    public class TiposDocumento
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string PeriodoTiempo = "01", DocOrigen = "02", Recalada = "03";
    }

    /// <summary>
    /// Tipo Accion Registro
    /// Tipo: enum 
    /// </summary>
    public enum TipoAccionRegistro
    {
        Nuevo = 1,
        Actualizar = 2,
        Ninguno = 0
    }

    /// <summary>
    /// clase para Estado Cotizacion
    /// </summary>
    public class EstadoCotizacion
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Aprobado = "06", Anulado = "04", Rechazado = "03";
    }

    /// <summary>
    /// Tipo Documento Correlativo Comercial
    /// Tipo: enum 
    /// </summary>
    public enum TipoDocumentoCorrelativoComercial
    {
        Plantilla = 1,
        Cotizacion = 2,
        AcuerdoComercial = 3,
        Adenda = 4,
        ReciboGarantia = 5,
        ReciboTHC = 6,
        FacturacionPorOperacion = 7,
        PreDocumentos = 8
    }

    /// <summary>
    /// clase para Estado Evento
    /// </summary>
    public class EstadoEvento
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Programado = "1";
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Realizado = "2";
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Cancelado = "3";
    }

    /// <summary>
    /// clase para Asuntos Correos
    /// </summary>
    public class AsuntosCorreos
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string AsuntoCorreoBloqueo = "Asunto de correo de bloqueo";
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string AsuntoCorreoEvento = "Asunto de correo de Evento";
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string AsuntoCorreoEventoCancelado = "Asunto de correo de Evento Cancelado";
    }

    /// <summary>
    /// Tipo Porcentaje
    /// Tipo: enum 
    /// </summary>
    public enum TipoPorcentaje
    {
        Fijo = 1,
        Porcentual = 2
    }

    /// <summary>
    /// clase para Estado Tarifa
    /// </summary>
    public class EstadoTarifa
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Activo = "00", Inactivo = "01";
    }

    /// <summary>
    /// clase para Tipo Calculo
    /// </summary>
    public class TipoCalculo
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Directo = "01", Rangos = "02";
    }

    /// <summary>
    /// clase para Tipo Tarifa
    /// </summary>
    public class TipoTarifa
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Estandar = "01";
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Integral = "02";
    }

    /// <summary>
    /// clase para Tipo Recargo Descuento
    /// </summary>
    public class TipoRecargoDescuento
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Recargo = "01", Descuento = "02";
    }

    /// <summary>
    /// clase para Tipo Calculo Comision
    /// </summary>
    public class TipoCalculoComision
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Porcentual = "001", Fijo = "002";
    }

    /// <summary>
    /// clase para Tipo Calculo Descuento
    /// </summary>
    public class TipoCalculoDescuento
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Fijo = "1", Porcentual = "2";
    }

    /// <summary>
    /// clase para Tipo Calculo Recargo
    /// </summary>
    public class TipoCalculoRecargo
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Fijo = "01", Porcentual = "02";
    }

    /// <summary>
    /// clase para Tipo Operacion
    /// </summary>
    public class TipoOperacion
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Facturacion = "001", Cobranza = "002";
    }

    /// <summary>
    /// clase para Tipo Origen Operacion
    /// </summary>
    public class TipoOrigenOperacion
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string FacturacionVentanilla = "FV", FacturacionLibre = "FL", PreDocumento = "PD", OtrosSistemas = "OT", Ninguno = "";
    }

    /// <summary>
    /// clase para Cod Estado Operacion
    /// </summary>
    public class CodEstadoOperacion
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string EnElaboracion = "000", Pendiente = "001", Error = "002", Procesado = "003", Anulado = "004";
    }

    /// <summary>
    /// clase para Tipo Impresion
    /// </summary>
    public class TipoImpresion
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Resumida = "001", Detallada = "002";
    }

    /// <summary>
    /// Tipo Nivel
    /// Tipo: enum 
    /// </summary>
    public enum TipoNivel
    {
        Escalonado = 1,
        Directo = 2
    }

    /// <summary>
    /// clase para Flag Estado
    /// </summary>
    public class FlagEstado
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Verdadero = "1", Falso = "0";
    }

    /// <summary>
    /// clase para Tipo Comision
    /// </summary>
    public class TipoComision
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string ComisionCNP = "1", ComisionCSAV = "2", NoAplica = "3";
    }

    /// <summary>
    /// clase para Tipo Usuario Seguridad
    /// </summary>
    public class TipoUsuarioSeguridad
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Interno = "I", Externo = "E", Todos = null;
    }

    /// <summary>
    /// clase para Idioma Busqueda Unidad Cobro
    /// </summary>
    public class IdiomaBusquedaUnidadCobro
    {
        /// <summary>
        /// string
        /// Tipo: const 
        /// </summary>
        public const string Espanol = "S";
    }

    public enum CatalogoTablas
    {
        [Description("EstadosTarea")]
        EstadosTarea = 6

       
    }

    public enum TipoNotificacion
    {
        TarifaLocal = 1,
        TarifaEscalonada = 2,
        AcuerdoComercialLocal = 3,
        AcuerdoComercialEscalonado = 4,
        ContenedeorNoDevueltoMayorACero = 5,
        ContenedeorNoDevueltoCeroATreintaNegativo = 6,
        ContenedeorNoDevueltoMayorATreintaNegativo = 7,
        NotificacionRecordarClave = 8
    }

    public enum EstadoAcuerdoComercial
    {
        [Description("E")]
        Elaboracion = 1,

        [Description("C")]
        Creacion = 2
    }
    public enum EstadoTarea
    {
        [Description("Asignado")]
        Asignado = 001,

        [Description("Ejecutado")]
        Ejecutado = 002,

        [Description("Finalizado")]
        Finalizado = 003
    }

    public enum TipoFechaCalculo
    {
        [Description("FEM")]
        Embarque = 1,

        [Description("FAT")]
        Atraque = 2,

        [Description("FTD")]
        TerminoDescarga = 3,

        [Description("FAR")]
        Arribo = 4
    }

    public enum TipoCriterio
    {
        [Description("001")]
        RA = 1,

        [Description("002")]
        Variables = 2
    }

    public enum TipoDias
    {
        [Description("C")]
        Calendario = 1,
    }

    public enum TipoDescuento
    {
        [Description("P")]
        Fijo = 1,

        [Description("D")]
        Porcentual = 2,

        [Description("E")]
        Exonerado = 3

    }
    public enum TipoCliente
    {
        [Description("C1")]
        CLiente1 = 1
    }

    public enum TipoCobro
    {
        [Description("000")]
        CobroPorTarifa = 0,

        [Description("001")]
        CobroRegular = 1,

        [Description("002")]
        CobroAlternativo = 2,
    }
}
