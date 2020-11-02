using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;
using EntidadesAbstractas;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class TestUno
    {
        [TestMethod]
        public void DniInvalidoExceptionTest()
        {
            //DNI con letra
            try
            {
                Alumno a = new Alumno(01, "ezequiel", "carranza", "37.o18.214", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //DNI con coma
            try
            {
                Alumno a = new Alumno(01, "ezequiel", "carranza", "37,18214", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //DNI vacio
            try
            {
                Alumno a = new Alumno(01, "ezequiel", "carranza", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //DNI fuera de los rangos
            try
            {
                Alumno a = new Alumno(01, "ezequiel", "carranza", "100000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                Alumno a = new Alumno(01, "ezequiel", "carranza", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void SinProfesorExceptionTest()
        {
            Universidad uni = new Universidad();
            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        [TestMethod]
        public void DniInvalido()
        {
            Alumno a = new Alumno(0001, "Ezequiel", "Carranza", "37.018.214", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsTrue(37018214 == a.DNI);

            Profesor p = new Profesor(0002, "Federico", "Davila", "37014025", Persona.ENacionalidad.Argentino);
            Assert.IsTrue(37014025 == p.DNI);
        }

        [TestMethod]
        public void InstructorNoNulo()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Instructores);
        }
    }
}
