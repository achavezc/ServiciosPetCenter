﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Configuration;
using System.Net;
using Newtonsoft.Json.Converters;

namespace PETCENTER.MANTENIMIENTO.Framework
{
    public enum ContentType
	{
        JSON,
        XML
	}
    public class UtilitarioRest
    {
        public Y DeserializarJSON<T, Y>(T request, string url, string soapAction = "", bool consultaSap = false,ContentType formatoRequest = ContentType.JSON )
        {
            //RequestBaseDTO requestBaseDTO = (RequestBaseDTO)request;
            //requestBaseDTO.UsuarioSeguridadDTO = new requestBaseDTO.UsuarioSeguridadDTO();

            object vnull = null;
            Y resultServicio = (Y)(vnull);

            ManejadorLogEventos manejadorLogEventosMAPA = new ManejadorLogEventos();
            ManejadorLogEventos manejadorLogEventosLOGERRORES = new ManejadorLogEventos();
            String Request = "";
            String Response = "";
            var flagTrazasServicioWCF = ConfigurationManager.AppSettings["FlagTrazasServicioWCF"];
            var flagTrazasServicioBrocker = ConfigurationManager.AppSettings["FlagTrazasServicioBrocker"];

            try
            {
                var RESTProxy = new MyWebClient();
                if (!string.IsNullOrEmpty(soapAction))
                {
                    RESTProxy.Headers["SOAPAction"] = soapAction;
                }
                if(formatoRequest==ContentType.JSON)
                    RESTProxy.Headers["Content-type"] = "application/json";
                else
                    RESTProxy.Headers["Content-type"] = "application/xml";

                MemoryStream ms = new MemoryStream();
                Stream stream = ms;
                bool SeEjecutadeWeb = true;
                bool conrequest = true;
                if (request.ToString() == string.Empty)
                {
                    try
                    {
                        stream = RESTProxy.OpenRead(url);
                        SeEjecutadeWeb = true;
                    }
                    catch
                    {
                        SeEjecutadeWeb = false;
                        ms = new MemoryStream(new UTF8Encoding().GetBytes(""));
                    }
                    conrequest = false;
                }
                else
                {

                    if (consultaSap)
                    {
                        Request = JsonConvert.SerializeObject(request, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });// HH:mm:ss

                        ms = new MemoryStream(new UTF8Encoding().GetBytes(Request));
                        ms.Position = 0;
                    }
                    else
                    {
                        if (formatoRequest == ContentType.JSON)
                        {
                            var serializerToUpload = new DataContractJsonSerializer(typeof(T));
                            serializerToUpload.WriteObject(ms, request);
                            ms.Position = 0;
                        }
                        else {
                            var serializerToUpload = new System.Xml.Serialization.XmlSerializer(typeof(T));
                            serializerToUpload.Serialize(ms, request);
                            ms.Position = 0;
                        }

                        Request = Encoding.UTF8.GetString(ms.ToArray());
                    }

                    if (consultaSap && flagTrazasServicioWCF == "S")
                    {
                        manejadorLogEventosLOGERRORES.GuardarTrama2(manejadorLogEventosLOGERRORES.inicio, "REQUEST", url, Helper.LocalIPAddress(), Environment.UserName, Request);
                    }
                }

                if (SeEjecutadeWeb == false || conrequest == true)
                {
                    var dc = System.Text.Encoding.UTF8.GetString(RESTProxy.UploadData(url, "POST", ms.ToArray())).ToCharArray();
                    var data = System.Text.Encoding.UTF8.GetBytes(dc);

                    Stream stream_response;
                    stream_response = new MemoryStream(data);
                    stream_response.Position = 0;
                    var sr_response = new StreamReader(stream_response);
                    sr_response.ReadToEnd();

                    Response = Encoding.UTF8.GetString(data.ToArray());
                    if (consultaSap && flagTrazasServicioBrocker == "S")
                    {
                        manejadorLogEventosLOGERRORES.Break();
                        manejadorLogEventosLOGERRORES.GuardarTrama2(manejadorLogEventosLOGERRORES.fin, "RESPONSE", url, Helper.LocalIPAddress(), Environment.UserName, Response);

                    }
                    stream = new MemoryStream(data);
                }


                if (consultaSap)
                {
                    StreamReader sReader = new StreamReader(stream);
                    Response = sReader.ReadToEnd();

                    resultServicio = (Y)JsonConvert.DeserializeObject(Response, typeof(Y), new JsonSerializerSettings() { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

                    manejadorLogEventosMAPA.Break();
                    if (flagTrazasServicioBrocker == "S")
                        manejadorLogEventosMAPA.GrabarLogMapaBD(manejadorLogEventosMAPA.inicio, manejadorLogEventosMAPA.fin, manejadorLogEventosMAPA.GetDuracion(), (manejadorLogEventosMAPA.GetDuracion() / 1000), Helper.LocalIPAddress(), "", "BROKER", url, Request, Response, "LOG_MAPA_BROKER");
                }
                else
                {
                    if (formatoRequest == ContentType.JSON)
                    {
                        var obj = new DataContractJsonSerializer(typeof(Y));
                        resultServicio = (Y)obj.ReadObject(stream);
                    }
                    else {
                        var obj = new System.Xml.Serialization.XmlSerializer(typeof(Y));

                        resultServicio = (Y)obj.Deserialize(stream);
                    }
                    manejadorLogEventosMAPA.Break();
                    if (flagTrazasServicioWCF == "S")
                        manejadorLogEventosMAPA.GrabarLogMapaBD(manejadorLogEventosMAPA.inicio, manejadorLogEventosMAPA.fin, manejadorLogEventosMAPA.GetDuracion(), (manejadorLogEventosMAPA.GetDuracion() / 1000), Helper.LocalIPAddress(), "", "PROXY", url, Request, Response, "LOG_MAPA_WCF");
                }

            }
            catch (Exception ex)
            {
                ManejadorExcepciones.PublicarExcepcion(ex, PoliticaExcepcion.Framework);

                if (flagTrazasServicioBrocker == "S")
                {
                    manejadorLogEventosMAPA.Break();
                    manejadorLogEventosMAPA.GrabarLogMapaBD(manejadorLogEventosMAPA.inicio, manejadorLogEventosMAPA.fin, manejadorLogEventosMAPA.GetDuracion(), (manejadorLogEventosMAPA.GetDuracion() / 1000), Helper.LocalIPAddress(), "", "PROXY", url, Request, ex.Message, "LOG_MAPA_WCF");
                }
            }
            return resultServicio;
        }
    }

    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            const int MinutoEnSegundo = 60;
            const int SegundoEnMilisegundos = 1000;
            string strmin = System.Configuration.ConfigurationManager.AppSettings["TimeOutWcfMinutos"];
            int Minutos = 4;//default
            if (Convert.ToString("" + strmin).Length > 0)
                Minutos = Convert.ToInt32(strmin);
            int timeOutMilisegundos = Minutos * MinutoEnSegundo * SegundoEnMilisegundos;

            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.KeepAlive = false;
            request.SendChunked = false;
            request.ReadWriteTimeout = timeOutMilisegundos;
            request.ContinueTimeout = timeOutMilisegundos;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = timeOutMilisegundos;
            return request;
        }
    }
}