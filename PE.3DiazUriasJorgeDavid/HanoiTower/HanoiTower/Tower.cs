using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower
{
    class Tower
    {
        Stack<int> Torre1 = new Stack<int>(); //Se inicializa una pila por cada torre (3 torres)
        Stack<int> Torre2 = new Stack<int>();
        Stack<int> Torre3 = new Stack<int>();
        int Movimientos = 0; //Inicializamos el numero de movimientos a 0
        public void Game()
        {
            int Cantidad = 0;
            while (true) //El ciclo se ejecuta como verdadero
            {
                Console.Write("\nIngrese la cantidad de aros entre 2 y 9: ");
                Cantidad = int.Parse(Console.ReadLine()); //Ingresa la cantidad de aros que desea el usuario
                Movimientos = 0;
                if (Cantidad < 2 || Cantidad > 9) //Si la cantidad ingresada es menor que 2 o mayor a 9, vuelve a preguntar al usuario
                {
                    Console.WriteLine("Numero invalido");
                    continue; //Si la cantidad es invalida el ciclo vuelve a iniciar
                }
                for (int i = Cantidad; i >= 1; i--) //Se agregan los elementos dependiendo cuantos aros quiera el usuario a la 1era torre
                {
                    Torre1.Push(i);
                }
                Torres(); //Ejecutamos el metodo torres
                Agregar(Cantidad, Torre1, Torre2, Torre3); //se ejecuta el metodo con los parametros de cantidad y elementos de las torres
                Console.WriteLine(" Total de movimientos: {0} ", Movimientos); //Muestra el total de movimientos
                break; //Rompe el ciclo y finaliza el programa
            }
        }

        public void Torres()
        {
            if (0 != Torre1.Count || 0 != Torre2.Count || 0 != Torre3.Count) //Solo sirve para saltos de linea
            {
                Console.ReadKey();
                Console.WriteLine();
            }
            ImprimirTorre(Torre1); //Ejecutamos el metodo imprimirtorre y mandamos como parametro los elementos de la torre1, 2 y 3
            Console.Write(" , ");
            ImprimirTorre(Torre2);
            Console.Write(" , ");
            ImprimirTorre(Torre3);
        }

        public bool Agregar(int Cantidad, Stack<int> T1, Stack<int> T2, Stack<int> T3) //Recibe los parametros de los elementos de las pilas
        {
            if (Cantidad <= 4)
            {
                if ((Cantidad % 2) == 0)
                {
                    Agregar(T1, T2, T3);
                    Cantidad = Cantidad - 1; //resta 1 a la cantidad de aros
                    if (Cantidad == 1)
                    {
                        return true;
                    }
                    T2.Push(T1.Pop()); //Añade el aro de la torre 1 a la torre 2
                    Movimientos++; //Suma 1 al contador de movimientos
                    Torres(); //Regresa al metodo de torres
                    //la torre 1 ahora es la torre 3, la torre 2 ahora es la torre 1 y la torre 3 ahora es la torre 2
                    Agregar(T3, T1, T2); //Se ejecuta el metodo con los nuevos valores de las torres
                    T3.Push(T1.Pop()); //Se añade el aro de la torre 1 a la torre 2
                    Movimientos++; //Incrementa los movimientos
                    Torres(); //Vuelve a ejecuar el metodo torres
                    //La torre 1 es ahora la torre 2, la torre 2 ahora es la torre 1 y la torre 3 queda igual
                    Agregar(Cantidad, T2, T1, T3);
                }
                else
                {
                    if (Cantidad == 1)
                    {
                        return false;
                    }
                    Agregar(T1, T3, T2);
                    Cantidad = Cantidad - 1;
                    T3.Push(T1.Pop());
                    Movimientos++;
                    Torres();
                    Agregar(T2, T1, T3);
                }
                return true;
            }
            else if (Cantidad >= 5)
            {
                Agregar(Cantidad - 2, T1, T2, T3);
                T2.Push(T1.Pop());
                Movimientos++;
                Torres();
                Agregar(Cantidad - 2, T3, T1, T2);
                T3.Push(T1.Pop());
                Movimientos++;
                Torres();
                Agregar(Cantidad - 1, T2, T1, T3);
            }
            return true;
        }

        public void Agregar(Stack<int> T1, Stack<int> T2, Stack<int> T3)
        {
            T2.Push(T1.Pop());
            Movimientos++;
            Torres();
            T3.Push(T1.Pop());
            Movimientos++;
            Torres();
            T3.Push(T2.Pop());
            Movimientos++;
            Torres();
        }

        public void ImprimirTorre(Stack<int> Num) //recibe los parametros y los almacena en una pila
        {
            Stack<int>.Enumerator Aros = Num.GetEnumerator(); //se inicializa una pila enumerando la cantidad de elementos
            Console.Write("[");
            string Hanoi = ""; //En esta variable se imprimiran los numeros
            while (true) //El ciclo inicia como verdadero
            {
                if (Aros.MoveNext() == false) //Recorre todos los elementos de la pila, si no queda ninguno rompe el ciclo
                {
                    break;
                }
                Hanoi += Aros.Current.ToString(); //Se guarda el numero actual recorrido y lo almacena en la variable en formato de cadena
            }
            for (int i = Hanoi.Length - 1; i >= 0; i--) //Se realiza un ciclo for para imprimir la pila en formato string de los elementos
            {
                Console.Write(Hanoi[i]);
            }
            Console.Write("]");
        }
    }
}
