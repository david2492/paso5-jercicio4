using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


/*Para una tienda de ropa femenina se requiere un programa que:
• Mediante ciclos permita ingresar por consola n número de
productos y sus valores.
• Debe calcular y mostrar en pantalla el subtotal, IVA y valor total
a pagar.
• Con condicionales debe hallar si la compra es mayor a $50.000
hacer un descuento del 5%
• Nota: el descuento se evalúa y se hace sobre el subtotal o valor
neto.*/
namespace tiendafemenina
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*************************************");
            Console.WriteLine("TIENDA FEMENINA");
            Console.WriteLine("*************************************");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Datos datos = new Datos();
            datos.Cantidad();
            datos.Valor();
            int suma = datos.Suma();
            
            Console.WriteLine();
            Factura factura = new Factura();
            factura.Cobro(suma);
            Console.WriteLine();
            Console.WriteLine("precione una tecla para salir....");
            Console.ReadKey();
        }
            
           

    }

    class Factura
    {
        private int descuento, iva, total, subTotal;

        public void Cobro(int aSuma)
        {
            subTotal = aSuma;

            if (subTotal > 50000)
            {
                descuento = (subTotal * 5) / 100;
            }
            else
            {
                descuento = 0;
            }
            iva = (subTotal * 19) / 100;
            total = subTotal + iva - descuento;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FACTURA DE VENTA");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("SUBTOTAL: ${0} " , subTotal);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("IVA: ${0} ", iva);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("DESCUENTO: ${0}", descuento);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("TOTAL FACTURA: ${0}", total);
            Console.WriteLine("----------------------------------------");
        }
    }

    class Datos
    {
        private int cantidad, valor, suma = 0;

        public void Cantidad()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("DIGITE LA CANTIDAD DE PRODUCTOS A COMPRAR");
            Console.WriteLine("----------------------------------------");
            cantidad = int.Parse(Console.ReadLine());


        }


        public void Valor()
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*************************************");
                Console.WriteLine("DIGITE EL VALOR DEL PRODUCTO No: " + (i + 1));
                Console.WriteLine("*************************************");
                valor = int.Parse(Console.ReadLine());
                suma = suma + valor;
            }
        }

        public int Suma()
        {
            return suma;
        }
    }
}

