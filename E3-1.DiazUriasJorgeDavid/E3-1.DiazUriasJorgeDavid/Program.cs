using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace E3_1.DiazUriasJorgeDavid
{
    class Program
    {
        static void Main(string[] args)
        {
            int Cantidad;//declaracion de variable
            Console.WriteLine("Ingrese el numero de clases y alumnos");
            Cantidad = int.Parse(Console.ReadLine());
            Metodos Clase = new Metodos();
            //se llama al metodo captura y se envia como parametro la cantidad
            Clase.Captura(Cantidad);
            Console.ReadKey();
        }
    }
}
