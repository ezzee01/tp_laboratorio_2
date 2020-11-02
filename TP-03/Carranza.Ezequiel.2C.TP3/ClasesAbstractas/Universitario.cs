using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /***CONSTRUCTORES***/

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /***METODOS***/

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="obj">Objeto tipo Universitario a comparar. </param>
        /// <returns>Si su DNI y Legajo son iguales devuelve true, sino false.</returns>
        public override bool Equals(object obj)
        {
            if (!(ReferenceEquals(obj, null)) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if (objeto.DNI == this.DNI && objeto.legajo == this.legajo)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Retorna datos del universitario.
        /// </summary>
        /// <returns>Legajo y datos del universitario(STRING).</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son iguales devuelve false, sino true.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son iguales devuelve true, sino false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Metodo abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


    }
}
