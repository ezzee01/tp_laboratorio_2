using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : ISerializable
    {
        public enum EMetodoDePago { Efectivo, Tarjeta }
        private string nombre;
        private string apellido;
        private int precioAPagar;
        private List<Producto> productosAVender;
        private EMetodoDePago metodoDePago;
        private int dni;

        /*CONSTRUCTORES*/
        public Cliente(string nombre, string apellido, EMetodoDePago metodoDePago, int dni) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.MetodoDePago = metodoDePago;
            this.Dni = dni;
        }

        private Cliente()
        {
            this.productosAVender = new List<Producto>();
        }

        /*PROPIEDADES*/
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

        public int PrecioAPagar
        {
            get { return this.precioAPagar; }
            set { this.precioAPagar = value; }
        }

        public List<Producto> ProductosAVender
        {
            get { return this.productosAVender; }
        }

        public EMetodoDePago MetodoDePago
        {
            get { return this.metodoDePago; }
            set { this.metodoDePago = value; }
        }

        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        /*METODOS*/
        public string Facturacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" Nombre: {this.Nombre}");
            sb.AppendLine($" Apellido: {this.Apellido}");
            sb.AppendLine($" Dni: {this.Dni}");
            sb.AppendLine($" Forma de Pago: {this.MetodoDePago}");
            sb.AppendLine($" Total a Pagar: {this.PrecioAPagar}");
            sb.AppendLine($" Productos:");

            foreach (Producto producto in productosAVender)
            {
                sb.Append($"--{producto.ToString()}--");
            }

            return sb.ToString();
        }

        //public override string ToString()
        //{
        //    return this.Facturacion();
        //}

        public static Cliente operator +(Cliente c, Dimmer dim)
        {
            c.productosAVender.Add(dim);
            c.PrecioAPagar += dim.Precio;
            return c;
        }

        public static Cliente operator +(Cliente c, DetectorMovimiento det)
        {
            c.productosAVender.Add(det);
            c.PrecioAPagar += det.Precio;
            return c;
        }

        public static Cliente operator -(Cliente c, DetectorMovimiento det)
        {
            foreach (Producto prod in c.productosAVender)
            {
                if (prod == det)
                {
                    c.productosAVender.Remove(prod);
                    c.PrecioAPagar -= prod.Precio;
                    break;
                }
            }
            return c;
        }
    }
}
