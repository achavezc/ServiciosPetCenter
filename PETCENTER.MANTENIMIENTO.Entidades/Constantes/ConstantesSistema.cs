using System;
using System.Collections.Generic;
using System.Linq;

namespace PETCENTER.MANTENIMIENTO.Entidades.Constantes
{
    /// <summary>
    /// clase para Constantes Sistema
    /// </summary>
    public class ConstantesSistema
    {

        public const string EstadoOperacionServicioCorrecto = "Correcto";

        public const string EstadoOperacionServicioError = "Incorrecto";




    }
    public class ConstantesEstadoTarea
    {

        public const string Asignado = "001";

        public const string Ejecutado = "002";

        public const string Finalizado = "003";

    }
    public class ConstantesEstadoReclamo
    {

        public const string Registrado = "001";

        public const string Pendiente = "002";

        public const string Rechazado = "003";

        public const string Finalizado = "004";

    }


    public class ConstantesRespuestaSAP
    {

        public const int EXITO = 108;

        public const int ERROR = 109;

        public const int ERROR_ANULARCOBRANZA = 99;

        public const int ERROR_TRANSACCIONNOREGISTRADA = 100;

        public const string TypeError = "E";

        public const string TypeOK = "S";

        public const string TypeReproceso = "R";

        public const string TypeBloqueado = "W";

        public const int ErrorComex = 999999;
    }


    public class ConstantesDB
    {
        public const string Tramarsa = "TRAMARSA";
        public const string AcuerdoComercialAGMADB = "AcuerdoComercialAGMADB";
        public const string Reclamos = "Reclamos";
        public const  string Petcenterdb= "PETCENTERDB";


    }



    

}
