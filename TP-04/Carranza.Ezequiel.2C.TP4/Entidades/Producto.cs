using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Producto : IMostrar<Producto>
    {
        private string nombreProducto;
        private string descripcion;
        private int codigo;
        private int precio;

        protected Producto(string nombreProducto, string descripcion, int codigo, int precio)
        {
            this.NombreProducto = nombreProducto;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.Precio = precio;
        }

        public string NombreProducto
        {
            get { return this.nombreProducto; }
            set { this.nombreProducto = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public int Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public string MostrarDatos(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.NombreProducto}");
            sb.AppendLine($"Descripcion: {this.Descripcion}");
            sb.AppendLine($"Codigo: {this.Codigo}");
            sb.AppendLine($"Precio: {this.Precio}");

            return sb.ToString();
            
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
