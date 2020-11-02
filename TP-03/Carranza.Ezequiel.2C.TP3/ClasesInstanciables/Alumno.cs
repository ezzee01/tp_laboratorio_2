using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        /***Constructores***/

        public Alumno()
        {
        }

        public Alumno(int id, string nombre,string apellido, string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /***Metodos***/

        /// <summary>
        /// Muestra todos los datos del alumno. 
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno no toma la clase, sino false.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno toma la clase y su estado de cuenta es distinto de Deudor, sino false.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Muestra la clase que toma el alumno.
        /// </summary>
        /// <returns>Devuelve una cadena "TOMA CLASE DE" junto al nombre de la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Hace públicos los datos del alumno.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
