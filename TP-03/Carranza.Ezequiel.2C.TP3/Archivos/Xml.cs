using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> :IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = true;

            try
            {
                writer = new XmlTextWriter(archivo, null);
                serializer.Serialize(writer, datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool retorno = true;

            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(reader);
            }
            catch (Exception)
            {
                datos = default(T);
                retorno = false;
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
