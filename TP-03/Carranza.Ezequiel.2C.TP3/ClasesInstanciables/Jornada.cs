using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /***PROPIEDADES***/

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        /***Constructores***/

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        /***Metodos***/

        /// <summary>
        /// Guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee el archivo donde se almacenan las jornadas y retorna la información obtenida.
        /// </summary>
        /// <returns>Devuelve los datos leídos del archivo en formato string.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string datos;

            texto.Leer("Jornada.txt", out datos);

            return datos;
        }

        /// <summary>
        /// Una jornada será diferente a un alumno si el mismo NO participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno NO participa de la jornada, sino false.</returns>
        public static bool operator !=(Jornada j , Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno participa de la jornada, sino false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }

        /// <summary>
        /// Agrega un nuevo alumno a la lista de alumnos. 
        /// </summary>
        /// <param name="j">Jornada a la que agregar alumno.</param>
        /// <param name="a">Nuevo alumno a agregar.</param>
        /// <returns>La jornada con el nuevo alumno incluído.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Informa todos los datos de una jornada.
        /// </summary>
        /// <returns>Devuelve una cadena con los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            datos.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                datos.AppendLine(alumno.ToString());
            }

            return datos.ToString();
        }

    }
}
