using System;
using Entidades.Excepciones;
using System.Text.Json;
using System.IO;
using Entidades.Interfaces;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace Entidades.Gestor_de_Archivos
{
    public class Serializador<T> : GestorDeArchivo, IArchivos<T> where T : class, new()
    {
        public Serializador(ETipoArchivo tipoArchivo) : base(tipoArchivo)
        {
        }

        public string Escribir(string nombreArchivo, T elemento)
        {
            try
            {
                if(this.tipoArchivo == ETipoArchivo.XML)
                {
                    if (Path.GetExtension(nombreArchivo) == ".xml")
                    {

                        string rutaFinal = $"{rutaBase}\\{nombreArchivo}";

                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(rutaFinal,Encoding.UTF8))
                        {
                            xmlTextWriter.Formatting = Formatting.Indented;
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            serializer.Serialize(xmlTextWriter, elemento);
                        }
                        return "Archivo guardado con exito";
                    }
                    else
                        throw new ArchivoSerializacionException("Extension invalida se esperaba XML.");
                }
                return "Formato invalido";
            }
            catch (Exception)
            {

                throw new ArchivoSerializacionException("Error al serializar.");
            }
        }

        public T Leer(string nombreArchivo)
        {
            try
            {
                if(Path.GetExtension(nombreArchivo) == ".xml")
                {
                    string rutaFinal = $"{rutaBase}\\{nombreArchivo}";
                    using (XmlTextReader xmlTextReader = new XmlTextReader(rutaFinal))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(xmlTextReader) as T;
                    }
                }
                else
                    throw new ArchivoSerializacionException("Extension invalida se esperaba XML.");
            }
            catch (Exception)
            {
                throw new ArchivoSerializacionException("Error al serializar.");
            }
        }
    }
}
