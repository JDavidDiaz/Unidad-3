using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacas
{
    class Puente
    {
        Stack<int> Inicio = new Stack<int>(); //Inicializamos 2 pilas
        Stack<int> Final = new Stack<int>();
        int Suma = 0; //Inicializamos la suma a 0 que determinara el tiempo transcurrido
        public void Acertijo()
        {
            Inicio.Push(20); //Agregamos las 4 vacas con los distintos tiempos
            Inicio.Push(10);
            Inicio.Push(4);
            Inicio.Push(2);
            Comienzo(); //Imprime la primera pila antes de cruzar el puente
            ImprimirTorre2(); //Imprime la segunda pila despues de cruzar el puente
            Final.Push(Inicio.Pop()); //Se añade la vaca de 4 de la pila 1 a la 2 
            Suma = Suma + Inicio.Peek(); //Muestra la vaca de 2 para sumarla a la variable suma antes de agregarla a la pila 2
            Final.Push(Inicio.Pop()); //añade la vaca de 2 a la pila 2
            Comienzo();
            ImprimirTorre2();
            Console.WriteLine("\n\nTiempo trascurrido: {0} min", Suma); //Se muestra el tiempo actual
            Stack<int> Final2 = new Stack<int>(Final); //Se crea una 3era pila con los mismos elementos que la pila 2 para poder invertir el orden de la pila 2
            Suma += Final2.Peek(); //Suma la vaca de 2        
            Final = Final2; //Se iguala la pila 2 a la pila 3
            Inicio.Push(Final.Pop()); //Añade a la pila 1 la vaca de 2 (la vaca 2 se regresa del puente)
            Comienzo();
            ImprimirTorre2();
            Console.WriteLine("\n\nTiempo trascurrido: {0} min", Suma); //Se muestra el tiempo actual
            Stack<int> Inicio2 = new Stack<int>(Inicio); //Se crea una 4ta pila con los mismo elementos que la pila 1 para poder invertir el orden de la pila 1
            Inicio = Inicio2; //Se iguala la pila 4 a la pila 1
            Suma += Inicio.Peek(); //Muestra el tiempo de la vaca de 20 y lo suma
            Final.Push(Inicio.Pop()); //Se añade la vaca de 10 y 20 a la pila 2 (cruzan el puente)
            Final.Push(Inicio.Pop());
            Comienzo();
            ImprimirTorre2();
            Console.WriteLine("\n\nTiempo trascurrido: {0} min", Suma);
            Stack<int> Final3 = new Stack<int>(Final); //Se crea una una 5ta pila con la misma funcionalidad de antes
            Final = Final3;
            Suma += Final.Peek(); //Muestra la vaca de tiempo de 4 y la suma
            Inicio.Push(Final.Pop()); //La vaca de 4 se añade a la pila 1 (regresa del puente)
            Comienzo();
            ImprimirTorre2();
            Console.WriteLine("\n\nTiempo trascurrido: {0} min", Suma);
            Final.Push(Inicio.Pop()); //Se añade la va 4 a la pila 2
            Suma += Final.Peek(); //Muestra el tiempo de la vaca 2 para sumarla antes de añadirla a la pila 2
            Final.Push(Inicio.Pop());
            Comienzo();
            ImprimirTorre2();
            Console.WriteLine("\n\nTiempo trascurrido Final: {0} min", Suma); //Suma del tiempo final
        }

        public void Comienzo() //Este metodo solo sirve para dar saltos de espacio
        {
            Console.ReadKey();
            Console.WriteLine();
            ImprimirTorre(); //Se ejecuta el metodo para imprimir la pila 1
        }

        public void ImprimirTorre() //Este metodo imrpime la pila 1 (antes de cruzar el puente)
        {
            Console.Write("[");
            foreach (var item in Inicio)
            {
                Console.Write(item + "-"); //Imprime los elementos de la pila 1
            }
            Console.Write("]");
            Console.Write(" ______________________________ ");
        }

        public void ImprimirTorre2()
        {
            Console.Write("[");
            foreach (var item in Final) //Imprime los elementos de la pila 2
            {
                Console.Write(item + "-");
            }
            Console.Write("]");
        }
    }
}
