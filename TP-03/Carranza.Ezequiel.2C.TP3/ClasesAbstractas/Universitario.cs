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

        //Constructores

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        //Metodos

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

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        protected abstract string ParticiparEnClase();


    }
}
