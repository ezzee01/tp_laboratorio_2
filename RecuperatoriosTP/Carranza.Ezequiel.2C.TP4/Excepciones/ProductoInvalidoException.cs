using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProductoInvalidoException : Exception
    {
        public ProductoInvalidoException(string msj) : base(msj)
        {

        }
    }
}
