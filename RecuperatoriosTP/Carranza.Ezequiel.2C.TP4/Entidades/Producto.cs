using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace Entidades
{
    public abstract class Producto
    {
        /// <summary>
        /// Descripcion de no estar sera el nombre del producto
        /// Atributo codigo sera DI (dimmer) o DE (detector) + numero
        /// </summary>
        private string nombreProducto;
        private string descripcion;
        private string codigo;

        /*CONSTRUCTORES*/
        public Producto(string nombreProducto, string descripcion, string codigo)
        {
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
            Codigo = codigo;
        }

        public Producto()
        {

        }

        /*PROPIEDADES*/
        /// <summary>
        /// Las propiedades asignan valores validados a los atributos
        /// </summary>
        public string NombreProducto
        {
            get { return this.nombreProducto; }
            set { this.nombreProducto = ValidarNombreDescripcion(value); }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = ValidarNombreDescripcion(value); }
        }

        public abstract int Precio { get; }

        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = ValidarCodigo(value); }
        }

        /*METODOS*/
        /// <summary>
        /// Sobrecarga de ToString
        /// </summary>
        /// <returns>Retorna los datos del producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Producto: {this.NombreProducto}");
            sb.AppendLine($"Descripcion: {this.Descripcion}");
            sb.AppendLine($"Codigo: {this.Codigo}");
            sb.AppendLine($"Precio: {this.Precio}");

            return sb.ToString();
        }

        /// <summary>
        /// Valida que una cadena no sea null o vacia
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <returns>True si la cadena es valida o false si no lo es</returns>
        private bool ValidarString(string cadena)
        {
            if (cadena == null || cadena == "" || cadena == " ")
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Retorna string valido, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="stringAValidar"></param>
        /// <returns>String valido</returns>
        private string ValidarNombreDescripcion(string stringAValidar)
        {
            if (!ValidarString(stringAValidar))
            {
                throw new ProductoInvalidoException("Alguno de los valores ha sido null o vacio.");                
            }
            else return stringAValidar;
        }

        /// <summary>
        /// Retorna codigo valido, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="cod">Codigo a validar</param>
        /// <returns>Codigo valido</returns>
        private string ValidarCodigo(string cod)
        {
            if (!ValidarString(cod) && !cod.Contains("DE") || !cod.Contains("DI"))
            {
                throw new ProductoInvalidoException("Codigo de producto invalido.");
            }
            else return cod;
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.codigo == p2.codigo;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
    }
}
