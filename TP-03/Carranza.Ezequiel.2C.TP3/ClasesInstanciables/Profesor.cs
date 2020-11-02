using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /***Constructores***/

        /// <summary>
        /// Constructor de clase, inicializa el atributo Random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        private Profesor()
        {
        }

        public Profesor(int id, string nombre,string apellido, string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }

        /***Metodos***/

        /// <summary>
        /// Hace públicos los datos del profesor.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Muestra todos los datos del profesor. 
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Asigna dos clases al azar a la cola de clases del día del profesor. 
        /// </summary>
        private void RandomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        /// <summary>
        /// Muestra las clases que da el profesor.
        /// </summary>
        /// <returns>Devuelve una cadena "TOMA CLASE DE" junto al nombre de las clases que da el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases c in this.clasesDelDia)
                {
                    sb.AppendLine($"{c}\n");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Será distinto si el profesor no da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor NO da la clase, sino false.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Será igual si el profesor da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor da la clase, sino false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases clas in i.clasesDelDia)
            {
                if (clas == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

    }
}
