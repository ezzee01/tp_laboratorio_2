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

        //Constructores

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }

        //Metodos

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto texto = new Texto();
            string datos;

            texto.Leer("Jornada.txt", out datos);

            return datos;
        }

        public static bool operator !=(Jornada j , Alumno a)
        {
            return !(j == a);
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

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
