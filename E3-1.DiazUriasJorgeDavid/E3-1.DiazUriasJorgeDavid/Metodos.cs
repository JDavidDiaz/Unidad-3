using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace E3_1.DiazUriasJorgeDavid
{
    class Metodos
    {
        public void Captura(int Cantidad)
        {
            //se crean 2 array list, nombre de la materia y califiacion de alumno
            ArrayList Materia = new ArrayList();
            ArrayList Calificacion = new ArrayList();
            //ciclos for anidados para captura de datos de materia y calificacion
            for (int i = 0; i < Cantidad; i++)
            {
                Console.WriteLine("Ingrese el nombre de la materia {0}", i + 1);
                Materia.Add(Console.ReadLine()); //se añade el nombre de la materia
                for (int j = 0; j < Cantidad; j++)
                {
                    Console.WriteLine("ingrese la calificacion del alumno {0}", j + 1);
                    Calificacion.Add(Console.ReadLine()); //se añade la califiacion del alumno
                }
            }
            //impresion del arraylist 
            foreach (var item in Materia)
            {
                Console.WriteLine(item);
                foreach (var item2 in Calificacion)
                {
                      Console.WriteLine(item2);        
                }
            }
        }
    }
}
