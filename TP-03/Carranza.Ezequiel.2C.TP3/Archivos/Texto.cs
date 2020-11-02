using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            bool retorno = true;

            try
            {
                streamWriter = new StreamWriter(archivo, false);

                streamWriter.WriteLine(datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                streamWriter.Close();
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            bool retorno = true;

            try
            {
                streamReader = new StreamReader(archivo);

                datos = streamReader.ReadToEnd();

            }
            catch (Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                streamReader.Close();
            }
            return retorno;
        }

    }
}
