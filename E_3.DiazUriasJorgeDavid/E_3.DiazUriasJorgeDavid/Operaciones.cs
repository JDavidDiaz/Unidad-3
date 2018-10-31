using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace E_3.DiazUriasJorgeDavid
{
    class Operaciones
    {
        public void Principal()
        {
            Stack Lista = new Stack();
            Queue Cola = new Queue();

        }

        public void Ejercicio1()
        {
            //¿Qué valores se devuelven durante la siguiente serie de operaciones de pila,
            //si se ejecutan en una pila inicialmente vacía ?
            //push(5), push(3), pop(), push(2), push(8),
            //pop(), pop(), push(9), push(1), pop(), push(7), push(6), pop(), pop(), push(4),
            //pop(), pop()
            Console.WriteLine("Ejercicio 1");
            Stack Lista = new Stack();
            Lista.Push(5);
            Lista.Push(3);
            Lista.Pop();
            Lista.Push(2);
            Lista.Push(8);
            Lista.Pop();
            Lista.Pop();
            Lista.Push(9);
            Lista.Push(1);
            Lista.Pop();
            Lista.Push(7);
            Lista.Push(6);
            Lista.Pop();
            Lista.Pop();
            Lista.Push(4);
            Lista.Pop();
            Lista.Pop();
            foreach (var item in Lista)
            {
                Console.WriteLine(item);
            }
        }

        public void Ejercicio2()
        {
            Console.WriteLine("Ejercicio 2");
            //Escriba en este metodo un modulo que pueda leer  y almacenar palabras reservadas en una lista enlazada 
            //e identificadores y literales en Otra lista enlazada.
            //Cuando el programa haya terminado de leer la entrada, mostrar
            //Los contenidos de cada lista enlazada.
            //Revise que es un Identificador y que es un literal

            List<string> ValPalabra = new List<string>();
            LinkedList<string> Reservada = new LinkedList<string>();
            LinkedList<string> IdentificadorLiteral = new LinkedList<string>();

            for (int contador = 0; contador < 10; contador++)
            {
                Console.WriteLine("Ingrese una palabra: ");
                ValPalabra.Add(Console.ReadLine());
            }
            string[] ValorClave = new string[107] {"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked","class", "const", "continue",  "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit",
            "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null",
            "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "using", "static", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "async",
            "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "groupo", "into", "join", "let", "nameof", "on", "orderby", "partial", "remove", "select", "set", "value", "var", "when", "where", "yield"};
            List<string> Palabras = new List<string>();
            foreach (var item in ValorClave)
            {
                Palabras.Add(item);
            }

            Console.WriteLine("\nEstas palabras son clave: ");
            foreach (var item in ValPalabra)
            {
                IdentificadorLiteral.AddLast(item);
                foreach (var item2 in ValorClave)
                {
                    if (item == item2)
                    {
                        Console.WriteLine(item2);
                        IdentificadorLiteral.Remove(item);
                        Reservada.AddLast(item2);
                    }
                }
            }

            Console.WriteLine("\nIdentificadores y literales: ");
            foreach (var item in IdentificadorLiteral)
            {
                Console.WriteLine(item);
            }
        }

        public void Ejercicio3()
        {
            Console.WriteLine("Ejercicio 3");
            //mida el tiempo entre Un lista ligada y una lista normal en el tiempo de ejecucion de 9876 elementos agregados.
            List<int> ListaNormal = new List<int>();
            LinkedList<int> ListaLigada = new LinkedList<int>();
            Stopwatch Crono = Stopwatch.StartNew();
            for (int i = 0; i < 9876; i++)
            {
                ListaNormal.Add(i);
            }
            Crono.Stop();
            Console.WriteLine("Tiempo de ejecucion de lista normal " + ((double)(Crono.Elapsed.TotalMilliseconds * 1000000) / 9876).ToString("0.00 ns"));
            Crono.Start();
            for (int i = 0; i < 9876; i++)
            {
                ListaLigada.AddLast(i);
            }
            Crono.Stop();
            Console.WriteLine("Tiempo de ejecucion de lista ligada " + ((double)(Crono.Elapsed.TotalMilliseconds * 1000000) / 9876).ToString("0.00 ns"));
        }

        public void Ejercicio4()
        {
            Console.WriteLine("Ejercicio 4");
            // Diseñar e implementar una clase que le permita a un maestro hacer un seguimiento de las calificaciones
            // en un solo curso.Incluir métodos que calculen la nota media, la
            //calificacion más alto, y el calificacion más bajo. Escribe un programa para poner a prueba tu clase.
            //implementación. Minimo 30 Calificaciones, de 30 alumnos.
            Clase Class;
            List<Clase> Alumnos = new List<Clase>();
            double Suma = 0;
            for (int i = 0; i < 30; i++)
            {
                Class = new Clase();
                Class.Maestro = "Alexanderson";
                Class.NombreClase = "Ingles";
                Class.Alumno = i + 1;
                Console.Write("Ingrese la calificacion del alumno {0}: ", i + 1);
                Class.Calificacion = int.Parse(Console.ReadLine());
                Suma = Suma + Class.Calificacion;
                Alumnos.Add(Class);              
            }
            int Max = Alumnos.Max(x => x.Calificacion);
            Console.WriteLine("La calificacion mayor es:" + Max);
            int Min = Alumnos.Min(x => x.Calificacion);
            Console.WriteLine("La calificacion menor es:" + Min);
            var Prom = Alumnos.Average(b => b.Calificacion);
            Console.WriteLine("Promedio es: " + Prom);
            Console.WriteLine("Promedio {0}", (Suma / 30));
        }

    }
}
