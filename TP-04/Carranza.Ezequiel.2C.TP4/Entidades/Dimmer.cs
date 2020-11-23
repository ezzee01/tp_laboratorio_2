using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dimmer : Producto
    {
        private ETipo tipo;

        public ETipo Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public enum ETipo
        {
            Comun, LED
        }

        public Dimmer(string nombreProducto, string descripcion, int codigo, int precio, ETipo tipo) : base(nombreProducto, descripcion, codigo, precio)
        {
            this.Tipo = tipo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo de Lampara: {this.Tipo}");

            return sb.ToString();
        }
    }
}
