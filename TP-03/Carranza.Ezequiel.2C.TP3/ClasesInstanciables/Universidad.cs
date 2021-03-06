﻿using System;
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

        /***PROPIEDADES***/

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
                if (i >= 0 && i < this.jornadas.Count)
                {
                    this.jornadas[i] = value;
                }
            }
        }

        /***contructores***/

        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }

        /***Metodos***/

        /// <summary>
        /// Serializa una universidad en formato XML.
        /// </summary>
        /// <param name="gim">Universidad a serializar.</param>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Deserializa una universidad guardada en formato XML.
        /// </summary>
        /// <returns>Objeto tipo Universidad con todos los datos guardados en el XML.</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Universidad.xml", out retorno);

            return retorno;
        }

        /// <summary>
        /// Genera una cadena con los datos de la universidad.
        /// </summary>
        /// <param name="uni">Universidad de la que se quiere mostrar los datos.</param>
        /// <returns>Cadena con los datos de la universidad.</returns>
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

        /// <summary>
        /// Sobrescritura del metodo ToString(); Retorna datos de la universidad.
        /// </summary>
        /// <returns>Cadena con los datos de la universidad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            return u.alumnos.Contains(a);
        }

        public static bool operator ==(Universidad u, Profesor i)
        {
            return u.instructores.Contains(i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u != clase;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.instructores)
            {
                if (item == clase)
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
            throw new AlumnoRepetidoException();

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
