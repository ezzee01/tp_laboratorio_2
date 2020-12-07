using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetectorMovimiento : Producto
    {
        public enum ETipoColocacion { Pared, Techo }
        private ETipoColocacion tipoColocacion;

        /*PROPIEDADES*/
        public ETipoColocacion TipoColocacion
        {
            get { return this.tipoColocacion; }
            set { this.tipoColocacion = value; }
        }

        /// <summary>
        /// Ambas versiones de detectores tendran el mismo precio
        /// </summary>
        public override int Precio
        {
            get
            {
                return 599;
            }
        }

        /*METODOS Y CONSTRUCTORES*/
        public DetectorMovimiento(string nombreProducto, string descripcion, string codigo, ETipoColocacion tipo) : base(nombreProducto, descripcion, codigo)
        {
            this.TipoColocacion = tipo;
        }

        public DetectorMovimiento()
        {

        }

        /// <summary>
        /// Sobrecarga de ToString
        /// </summary>
        /// <returns>Retorna info del producto y el tipo de instalacion</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo de colocacion: {this.TipoColocacion}");

            return sb.ToString();
        }
    }
}
