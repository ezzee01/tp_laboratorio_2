using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dimmer : Producto
    {
        public enum ELampara { LED, Incandescente }
        private ELampara lampara;

        /*PROPIEDADES*/
        public ELampara Lampara
        {
            get { return this.lampara; }
            set { this.lampara = value; }
        }

        /// <summary>
        /// Cada tecnologia de lampara soportada tiene un precio distinto
        /// </summary>
        public override int Precio
        {
            get
            {
                if (this.Lampara == ELampara.LED)
                {
                    return 400;
                }
                else return 300;
            }
        }

        /*METODOS Y CONSTRUCTORES*/
        public Dimmer(string nombreProducto, string descripcion, string codigo, ELampara tipo) : base(nombreProducto, descripcion, codigo)
        {
            this.Lampara = tipo;
        }

        public Dimmer()
        {

        }

        /// <summary>
        /// Sobrecarga de ToString
        /// </summary>
        /// <returns>Retorna info del producto y el tipo de lampara</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo de lampara soportada: {this.Lampara}");

            return sb.ToString();
        }
    }
}
