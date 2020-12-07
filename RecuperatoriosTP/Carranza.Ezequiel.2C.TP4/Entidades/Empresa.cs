using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        private string nombreEmpresa;
        private List<Producto> productos;
        private List<Cliente> clientes;

        /*PROPIEDADES*/
        public string NombreEmpresa
        {
            get { return this.nombreEmpresa; }
            set { this.nombreEmpresa = value; }
        }

        public List<Producto> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        public List<Cliente> Ventas
        {
            get { return this.clientes; }
            set { this.clientes = value; }
        }

        /*CONSTRUCTORES*/
        private Empresa()
        {
            this.Productos = new List<Producto>();
            this.Ventas = new List<Cliente>();
        }

        public Empresa(string nombreEmpresa):this()
        {
            this.NombreEmpresa = nombreEmpresa;
        }

        /*METODOS*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Empresa operator +(Empresa e, Producto p)
        {
            foreach (Producto producto in e.productos)
            {
                if (producto != p)
                {
                    e.productos.Add(p);
                    break;
                }
            }
            return e;
        }
    }
}
