using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> instructores;
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.instructores; }
            set { this.instructores = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornadas.Count)
                {
                    return this.jornadas[i];
                }
                return null;
            }
            set
            {
                if (i>=0 && i< this.jornadas.Count)
                {
                    this.jornadas[i] = value;
                }
            }
        }


        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }

        //Metodos

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Universidad.xml", out retorno);

            return retorno;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine("JORNADA:");
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("< ------------------------------------------------------------------- >");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.instructores.Contains(i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u != clase;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.instructores)
            {
                if (item==clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g.Alumnos) //Por cada alumno inscripto en la universidad...
            {
                if (alumno == clase) //Será igual si toma esa clase y no es deudor...
                {
                    jornada.Alumnos.Add(alumno); //Lo agrega a lista de alumnos de la clase...
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }


    }
}
