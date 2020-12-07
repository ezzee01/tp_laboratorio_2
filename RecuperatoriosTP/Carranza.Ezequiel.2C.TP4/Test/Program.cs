using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intancio una nueva empresa y dos nuevos clientes
            Empresa miEmpresa = new Empresa("Electronica de control");
            Cliente clienteUno = new Cliente("Juan", "Perez", Cliente.EMetodoDePago.Efectivo, 123);
            Cliente clienteDos = new Cliente("Jose", "Gomez", Cliente.EMetodoDePago.Tarjeta, 124);

            //Agrego los clientes a la lista de ventas
            miEmpresa.Ventas.Add(clienteUno);
            miEmpresa.Ventas.Add(clienteDos);


            try
            {
                Dimmer dimmer1 = new Dimmer("Dimmer", "Variador de luz", "DI 0501", Dimmer.ELampara.LED);
                miEmpresa += dimmer1;
                clienteUno += dimmer1;
            }
            catch (ProductoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Dimmer dimmer2 = new Dimmer("Dimmer", "", "DI 7901", Dimmer.ELampara.Incandescente);
                miEmpresa += dimmer2;
                clienteDos += dimmer2;
            }
            catch (ProductoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                DetectorMovimiento detector1 = new DetectorMovimiento("Detector de movimiento", null, "DE 2987", DetectorMovimiento.ETipoColocacion.Pared);
                miEmpresa += detector1;
                clienteUno += detector1;
            }
            catch (ProductoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                DetectorMovimiento detector2 = new DetectorMovimiento("Detector de movimiento", "Detector IR", "DE 2981", DetectorMovimiento.ETipoColocacion.Techo);
                miEmpresa += detector2;
                clienteDos += detector2;
            }
            catch (ProductoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
            Serializacion<Cliente> serializacion = new Serializacion<Cliente>();
            serializacion.Serializar(clienteUno, "ClienteUno.xml");
            serializacion.Serializar(clienteDos, "ClienteDos.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(clienteUno.Facturacion());
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(clienteDos.Facturacion());

            Console.ReadKey();
        }
    }
}
