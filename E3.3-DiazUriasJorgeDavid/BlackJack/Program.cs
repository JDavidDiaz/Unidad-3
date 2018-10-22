using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.Unicode; //Permite visualizar caracteres especiales (unicode)
            Console.WriteLine("Bienvenido al Juego '♥♦♣♠ BlackJack ♥♦♣♠'");
            Console.WriteLine("Nota: En Caso de que salga un 'As' la suma se tomara en cuenta hasta el\nfinal para tomar su valor segun la situacion que convenga");
            Console.ReadLine();
            Metodos Baraja = new Metodos(); //Creacion del objeto
            Baraja.Juego(); //Se llama al metodo que ejecutara el juego
            Console.ReadKey();
        }
    }
}
