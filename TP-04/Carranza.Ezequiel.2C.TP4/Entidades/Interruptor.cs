using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Interruptor : Producto
    {
        private EModelo modelo;

        public EModelo Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public enum EModelo
        {
            Mecanico, Electronico
        }

        public Interruptor(string nombreProducto, string descripcion, int codigo, int precio, EModelo modelo) : base(nombreProducto, descripcion, codigo, precio)
        {
            this.Modelo = modelo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Modo de funcionamiento: {this.Modelo}");

            return sb.ToString();
        }
    }
}
