using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ProductoInvalidoException))]
        public void CodigoProductoInvalido()
        {
            Dimmer dimmer = new Dimmer("Dimmer", "Variador de luz", "0501", Dimmer.ELampara.Incandescente);
        }
    }
}
