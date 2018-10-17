using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace E3_2.DiazUriasJorgeDavid
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue Cola = new Queue();
            //Enqueue: Agrega un elemento al final de la cola, este elemento puede ser de cualquier tipo
            Cola.Enqueue("Hi");
            Cola.Enqueue(4);
            Cola.Enqueue(true);
            foreach (var item in Cola)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();    
            //Dequeue: Elimina el primer elemento de la cola
            Cola.Dequeue();
            foreach (var item in Cola)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //TrimToSize: Restringe la capacidad de la cola con el numero de elementos actuales de la cola 
            //En el caso de las colas no es posible visualizar la utilizacion de TrimToSize debido a que las colas no cuentan con una propiedad Capacity
            Cola.TrimToSize();
            Console.ReadKey();
        }
    }
}
