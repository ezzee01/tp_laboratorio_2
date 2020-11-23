using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Cliente : IMostrar<List<Producto>>
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int idCliente;
        private EMetodoPago metodoPago;
        private List<Producto> productos;

        public enum EMetodoPago
        {
            Efectivo, Tarjeta
        }

        public Cliente(string nombre, string apellido, int dni, EMetodoPago metodoPago1)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.IdCliente = 0;
            this.MetodoPago = metodoPago1;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public int IdCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = value; }
        }

        internal EMetodoPago MetodoPago
        {
            get { return this.metodoPago; }
            set { this.metodoPago = value; }
        }

        public List<Producto> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        public string MostrarDatos(List<Producto> productos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista de Productos");

            foreach (Producto item in productos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
