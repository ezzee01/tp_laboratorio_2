using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        //propiedades

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        //Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nacionalidad = nacionalidad;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        //Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            sb.AppendLine($"DNI: {this.DNI}");
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI en rango invalido");
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato <= 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    }
                    break;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniEntero;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$"))
            {
                dato = dato.Replace(".", "");
                //dniEntero = Int32.Parse(dato);
                Int32.TryParse(dato, out dniEntero);
            }
            else throw new DniInvalidoException("DNI ingresado tiene un formato inválido.");

            return ValidarDni(nacionalidad, dniEntero);
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";

            if (Regex.IsMatch(dato, @"^([a-zA-Záéíóú]+)(\s[a-zA-Záéíóú]+)*$"))
            {
                retorno = dato;
            }

            return retorno;
        }



    }
}
