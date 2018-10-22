using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Metodos
    {
        public void Juego()
        {
            ValorCarta Mazo; //Se crea variable de tipo Clase 
            List<ValorCarta> Valor = new List<ValorCarta>(); //Crea una lista de tipo Clase
            ValorCarta Deck;
            List<ValorCarta> Simbolo = new List<ValorCarta>();
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 13; j++)
                {
                    Mazo = new ValorCarta(); //Crea un objeto que Añade la cantidad de cartas a la lista
                    if (j < 1)
                    {
                        Mazo.Numero = "A";
                        Valor.Add(Mazo);
                    }
                    else if (j < 10)
                    {
                        Mazo.Numero = j + 1;
                        Valor.Add(Mazo);
                    }
                    else if (j < 11)
                    {
                        Mazo.Numero = "J";
                        Valor.Add(Mazo);
                    }
                    else if (j < 12)
                    {
                        Mazo.Numero = "Q";
                        Valor.Add(Mazo);
                    }
                    else if (j < 13)
                    {
                        Mazo.Numero = "K";
                        Valor.Add(Mazo);
                    }
                }
            }
            for (int k = 0; k < 13; k++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Deck = new ValorCarta(); //Crea un objeto que añade la cantidad de simbolos para las cartas
                    if (z < 1)
                    {
                        Deck.Simbolo = "♥";
                        Simbolo.Add(Deck);
                    }
                    else if (z < 2)
                    {
                        Deck.Simbolo = "♦";
                        Simbolo.Add(Deck);
                    }
                    else if (z < 3)
                    {
                        Deck.Simbolo = "♣";
                        Simbolo.Add(Deck);
                    }
                    else if (z < 4)
                    {
                        Deck.Simbolo = "♠";
                        Simbolo.Add(Deck);
                    }
                }
            }
            Random Rand = new Random(); //Se inicializa una variable Random
            var RandomList = Valor.OrderBy(x => Rand.Next()).ToList(); //Se crea una lista con los elementos ordenados aleatoriamente de la lista de cartas
            var RandomList2 = Simbolo.OrderBy(x => Rand.Next()).ToList(); //Mismo caso pero para los simbolos
            Stack<ValorCarta> Value = new Stack<ValorCarta>(RandomList); //Se crea una pila y se le añaden los elementos previamente de la lista Random
            Stack<ValorCarta> Simbol = new Stack<ValorCarta>(RandomList2);
            //Se inicializan las variables para las cartas y los simbolos sacandolos de la pila para que no se repitan
            object Carta1 = Value.Pop().Numero;
            string Simbolo1 = Simbol.Pop().Simbolo;
            object Carta2 = Value.Pop().Numero;
            string Simbolo2 = Simbol.Pop().Simbolo;
            object Carta3 = Value.Pop().Numero;
            string Simbolo3 = Simbol.Pop().Simbolo;
            object Carta4 = Value.Pop().Numero;
            string Simbolo4 = Simbol.Pop().Simbolo;
            object Carta5 = Value.Pop().Numero;
            string Simbolo5 = Simbol.Pop().Simbolo;
            int Suma = 0;
            int As = 0; //Se inicializa la variable que servira como contador para la cantidad de As's del juego
            Console.Write("Carta No.1: ");
            if (Carta1 == "A") //Si la carta es un As sumara 1 para contar el numero de As's y poder sumarlos al final segun sea el caso
            {
                As = As + 1;
                Console.Write("{0}A", Simbolo1);
            }
            //Si la carta es J, Q o K Respectivamente se inicializara una variable que tendra un valor de 10
            else if (Carta1 == "J") 
            {
                int CartaUno = 10;
                Console.Write("{0}J", Simbolo1);
                Suma = CartaUno;
            }
            else if (Carta1 == "Q")
            {
                int CartaUno = 10;
                Console.Write("{0}Q", Simbolo1);
                Suma = CartaUno;
            }
            else if (Carta1 == "K")
            {
                int CartaUno = 10;
                Console.Write("{0}K", Simbolo1);
                Suma = CartaUno;
            }
            else
            {               
                //Si la carta es un numero se inicializara una variable que guardara el valor del objeto convertido a entero
                int CartaUno = Convert.ToInt32(Carta1);
                Console.Write("{0}{1}", Simbolo1, CartaUno);
                Suma = CartaUno; //Guarda el valor de el numero para poder sumarlo mas adelante
            }
            //Mismo procedimiento para la 2da Carta
            Console.Write("\nCarta No.2: ");            
            if (Carta2 == "A")
            {
                As = As + 1; //Se suma uno al contador de As
                Console.Write("{0}A", Simbolo2);
            }
            else if (Carta2 == "J")
            {
                int CartaDos = 10;
                Console.Write("{0}J", Simbolo2);
                Suma = Suma + CartaDos; //Se almacenara la Suma actual entre la carta 1 y la carta 2
            }
            else if (Carta2 == "Q")
            {
                int CartaDos = 10;
                Console.Write("{0}Q", Simbolo2);
                Suma = Suma + CartaDos;
            }
            else if (Carta2 == "K")
            {
                int CartaDos = 10;
                Console.Write("{0}K", Simbolo2);
                Suma = Suma + CartaDos;
            }
            else
            {
                int CartaDos = Convert.ToInt32(Carta2);
                Console.Write("{0}{1}", Simbolo2, CartaDos);
                Suma = Suma + CartaDos;
            }
            Console.WriteLine("\n\nSuma Actual: {0}" , Suma);
            if (Suma == 21) 
            {
                Console.WriteLine("Felicidades, has ganado");               
            }
            else //Si la suma entre la Carta 1 y la Carta 2 no es igual ni mayor a 21, se procedera a tomar la 3era Carta
            {
                Console.ReadKey();
                Console.Write("\nCarta No.3: ");          
                if (Carta3 == "A")
                {
                    As = As + 1;
                    Console.Write("{0}A", Simbolo3);
                }
                else if (Carta3 == "J")
                {
                    int CartaTres = 10;              
                    Suma = Suma + CartaTres;
                    Console.Write("{0}J", Simbolo3);
                }
                else if (Carta3 == "Q")
                {
                    int CartaTres = 10;
                    Suma = Suma + CartaTres;
                    Console.Write("{0}J", Simbolo3);
                }
                else if (Carta3 == "K")
                {
                    int CartaTres = 10;
                    Suma = Suma + CartaTres;
                    Console.Write("{0}J", Simbolo3);
                }
                else
                {
                    int CartaTres = Convert.ToInt32(Carta3);                   
                    Suma = Suma + CartaTres;
                    Console.Write("{0}{1}", Simbolo3, CartaTres);
                }
                Console.WriteLine("\n\nSuma Actual: {0}", Suma);
                if (Suma > 21) 
                {
                    Console.WriteLine("\nLastima, Has perdido");
                }
                else if (Suma == 21)
                {
                    Console.WriteLine("Felicidades, Has ganado");
                }
                else
                {
                    //De la misma manera, si las 3 cartas anteriores no llegan a sumar 21 o mas, se tomara otra carta
                    Console.ReadKey();
                    Console.Write("\nCarta No.4: ");             
                    if (Carta4 == "A")
                    {
                        As = As + 1;
                        Console.Write("{0}A", Simbolo4);
                    }
                    else if (Carta4 == "J")
                    {
                        int CartaCuatro = 10;
                        Console.Write("{0}J", Simbolo4);
                        Suma = Suma + CartaCuatro;
                    }
                    else if (Carta4 == "Q")
                    {
                        int CartaCuatro = 10;
                        Console.Write("{0}Q", Simbolo4);
                        Suma = Suma + CartaCuatro;
                    }
                    else if (Carta4 == "K")
                    {
                        int CartaCuatro = 10;
                        Console.Write("{0}K", Simbolo4);
                        Suma = Suma + CartaCuatro;
                    }
                    else
                    {
                        int CartaCuatro = Convert.ToInt32(Carta4);
                        Console.Write("{0}{1}", Simbolo4, CartaCuatro);
                        Suma = Suma + CartaCuatro;
                    }
                    Console.WriteLine("\n\nSuma Actual: {0}", Suma);
                    if (Suma > 21)
                    {
                        Console.WriteLine("\nLastima, Has perdido");
                    }
                    else if (Suma == 21)
                    {
                        Console.WriteLine("Felicidades, Has ganado");
                    }
                    else
                    {
                        //Si la suma de las 4 cartas anteriores no suma 21 o mas, se tomara la 5ta y ultima Carta
                        Console.ReadKey();
                        Console.Write("\nCarta No.5: ");                       
                        if (Carta5 == "A")
                        {
                            As = As + 1;
                            Console.Write("{0}A", Simbolo5);
                        }
                        if (Carta5 == "J")
                        {
                            int CartaCinco = 10;
                            Console.Write("{0}J", Simbolo5);
                            Suma = Suma + CartaCinco;
                        }
                        else if (Carta5 == "Q")
                        {
                            int CartaCinco = 10;
                            Console.Write("{0}Q", Simbolo5);
                            Suma = Suma + CartaCinco;
                        }
                        else if (Carta5 == "K")
                        {
                            int CartaCinco = 10;
                            Console.Write("{0}K", Simbolo5);
                            Suma = Suma + CartaCinco;
                        }
                        else
                        {
                            int CartaCinco = Convert.ToInt32(Carta5);
                            Console.Write("{0}{1}", Simbolo5, CartaCinco);
                            Suma = Suma + CartaCinco;
                        }
                        Console.WriteLine("\n\nSuma Actual: {0}", Suma);
                        if (Suma > 21)
                        {
                            Console.WriteLine("\nLastima, Has perdido");
                        }
                        else if (Suma == 21)
                        {
                            Console.WriteLine("Felicidades, Has ganado");
                        }
                    }
                }
            }
            //Si por lo menos 1 carta de las 5 es un 'As' se tomara su valor ya sea 1 o 11 segun la situacion sea mas conveniente
            if (Carta1 == "A" || Carta2 == "A" || Carta3 == "A" || Carta4 == "A" || Carta5 == "A")
            {
                for (int i = As; i > 0; i--) //Se repetira las veces igual a la cantidad de As's obtenidos
                {
                    if ((Suma + 11) > 21) //Si la suma actual + el valor del As tomandolo como 11 pasa de 21 entonces se tomara como 1
                    {
                        Suma = Suma + 1;
                    }
                    else
                    {
                        Suma = Suma + 11; //Si la suma no pasa de 21 entonces el As tomara un valor de 11
                    }
                }
                if ((Carta1 == "A" || Carta2 == "A" || Carta3 == "A" || Carta4 == "A" || Carta5 == "A"))
                {
                    if (Suma == 22)
                    Console.WriteLine("\nTe la creiste, has perdido :)");
                }
                Console.WriteLine("\nSuma definitiva contando los As: {0}", Suma); //Se imprimira la suma Real contando los valores de los As
            }
            else if (Suma < 21) //Si se obtienen 5 cartas y entre ellas la suma no pasa de 21 entonces se gana el juego
            {
                Console.WriteLine("Felicidades, Has Ganado por tener 5 cartas y no pasar de 21");
            }          
        }
    }
}
