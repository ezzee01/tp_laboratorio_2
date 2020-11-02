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

        //Constructores

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

        //Metodos

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

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0}", this.claseQueToma);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
