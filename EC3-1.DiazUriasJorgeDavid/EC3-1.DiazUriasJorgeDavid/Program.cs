using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EC3_1.DiazUriasJorgeDavid
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack Nombres = new Stack();
            Nombres.Push("David");
            Nombres.Push("Eddy");
            Nombres.Push("Chloe");
            Nombres.Push("Jin");
            Nombres.Push(2);
            foreach (var item in Nombres)
            {
                Console.WriteLine(item);
            }
            //Propiedad Contains: Busca si contiene el elemento solicitado
            if (Nombres.Contains("Jin"))
            {
                Console.WriteLine("\nSi lo contiene");
            }
            //Propiedad GetType: Obtiene el tipo de dato de la lista y imprime un True si la lista es de tipo Stack o False en caso contrario
            Console.WriteLine((Nombres.GetType() == typeof(Stack)));
            //Propiedad ToString: Se hace una condicion para mostrar si el elemento superior de la lista es igual al caracter '2'
            if (Nombres.Peek().ToString() == "2")
            {
                Console.WriteLine(Nombres.Peek());
            }
            Console.WriteLine("");
            //Propiedad ToArray: Se hace una copia de la primera lista haciendo que se almacene al reves (de arriba a abajo) a comparacion de la primera lista
            Stack Clon = new Stack(Nombres.ToArray());
            foreach (var item2 in Clon)
            {
                Console.WriteLine(item2);
            }
            Console.WriteLine("");
            //Propiedad GetEnumerator: Recorre la lista como iteracion haciendo que muestre en pantalla los elementos hasta que no quede ninguno por recorrer
            IEnumerator Recorrido = Nombres.GetEnumerator();
            while (Recorrido.MoveNext())
            {
                Console.WriteLine(Recorrido.Current);
            }
            Console.ReadKey();
        }
    }
}
