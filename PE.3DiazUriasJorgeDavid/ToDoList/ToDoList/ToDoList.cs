using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class ToDoList
    {
        List<Propiedad> ListaGlobal = new List<Propiedad>();    //Se inicializan las 3 listas 1 por cada estado de la tarea y 1 lista global
        List<Propiedad> ListaPendiente = new List<Propiedad>();
        List<Propiedad> ListaEnProceso = new List<Propiedad>();
        List<Propiedad> ListaTerminada = new List<Propiedad>();
        int ID = 0;
        public void Menu() //En este metodo se le mostrara al usuario que accion desea ejecutar del menu
        {
            Console.Clear();
            Console.WriteLine("Ingrese 1 opcion:\n1.Nueva Tarea.\n2.Comenzar Tarea.\n3.Borrar Tarea.\n4.Terminar Tarea.\n5.Ver Listas.\n6.Salir");
            int Opcion = int.Parse(Console.ReadLine()); //Se guarda la opcion que ingresa el usuario
            if (Opcion == 1) //Si es 1 se ejecuta el metodo para agregar 1 tarea
            {
                Nuevo();
            }
            else if (Opcion == 2 && ListaPendiente.Count == 0) //Si la opcion es 2 pero no se a agregado ninguna tarea se regresa al menu
            {
                Console.WriteLine("No tiene ninguna tarea pendiente");
                Console.ReadKey();
                Menu();
            }
            else if (Opcion == 2) //Si la opcion es 2 se ejecuta el metodo para cambiar el estado a proceso de 1 tarea en estado pendiente
            {
                Proceso();
            }
            else if (Opcion == 3 && (ListaPendiente.Count == 0 && ListaEnProceso.Count == 0)) // Si la opcion es 3 pero la lista pendiente y la lista
            { //En proceso estan vacias entonces se devuelve al menu
                Console.WriteLine("No tiene ninguna tarea para poder eliminar");
                Console.ReadKey();
                Menu();
            }
            else if (Opcion == 3) //Si la opcion es 3 se procede a ejecutar el metodo para borrar una materia
            {
                Borrar();
            }
            else if (Opcion == 4 && ListaEnProceso.Count == 0) //Si es 4 y la lista de procesos esta vacia entonces se devuelve al menu
            {
                Console.WriteLine("No tienes ninguna tarea para poder terminar");
                Console.ReadKey();
                Menu();
            }
            else if (Opcion == 4) //Si la opcion es 4 se ejecuta el metodo para cambiar el estado de 1 tarea en proceso a terminada
            {
                Terminar();
            }
            else if (Opcion == 5) //Si es 5 se deplegara un 2do menu con todas las listas
            {
                VerListas();
            }
            else if (Opcion == 6) //Si la opcion es 6 el programa finaliza
            {
                Console.WriteLine("BYE");
            }
            else if (Opcion < 1 || Opcion > 6) //Si la opcion no es ninguna de las anteriores entonces vuelve a preguntar
            {
                Console.WriteLine("Opcion Invalida");
                Console.ReadKey();
                Menu();
            }
        }

        public void Nuevo()
        {
            Propiedad New = new Propiedad();
            ID++; //Se incrementa en 1 el contador del ID para no tener ningun ID igual
            New.ID = ID; //Se le pregunta al usuario el nombre, descripcion y fecha de la tarea que ingresara
            Console.WriteLine("Ingrese el nombre de la tarea");
            New.Tarea = Console.ReadLine();
            Console.WriteLine("Ingrese Descripcion de la tarea");
            New.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese la Fecha de inicio");
            New.FechaInicio = Console.ReadLine();
            New.Status = "Pendiente";
            ListaPendiente.Add(New); //Se añaden los datos a las lista pendiente y global
            ListaGlobal.Add(New);
            Console.WriteLine("*Tarea agregada");
            Console.ReadKey();
            Menu(); //Regresa al menu
        }

        public void Proceso()
        {
            Console.WriteLine("Elija el ID de la tarea que desea comenzar a realizar");
            foreach (Propiedad item in ListaPendiente) //Despliega las listas que estan pendientes la cual el usuario eligira cual desea comenzar
            {
                Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
            }
            int Opcion2 = int.Parse(Console.ReadLine());
            var EnProceso = (from SameID in ListaPendiente where Opcion2 == SameID.ID select SameID).ToList(); //Busca la lista con el mismo ID que el usuario eligio
            Console.WriteLine("*Tarea Iniciada");
            foreach (var item in EnProceso)
            {
                ListaGlobal.Remove(item); //Se remueve la lista en la lista global
                item.Status = "En proceso"; //Se le da un nuevo valor al status
                ListaEnProceso.Add(item); //Se agrega a la lista procesos y global con el nuevo status
                ListaGlobal.Add(item);
                ListaPendiente.Remove(item); //Se elimina de la lista pendiente
            }
            Console.ReadKey();
            Menu();
        }

        public void Borrar()
        {
            Console.WriteLine("Elija el ID de la tarea que desea borrar");
            foreach (Propiedad item in ListaGlobal) //Despliega las listas para que el usuario elija cual desea borrar
            {
                Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
            }
            int Opcion2 = int.Parse(Console.ReadLine());
            var Eliminar = (from SameID in ListaGlobal where Opcion2 == SameID.ID select SameID).ToList(); //Busca la lista con el ID del numero ingresado por el usuario
            Console.WriteLine("*Tarea Borrada");
            foreach (var item in Eliminar)
            {   //Elimina la lista en la listaglobal, lista pendiente y en la listaenprocesos
                ListaGlobal.Remove(item);
                ListaPendiente.Remove(item);
                ListaEnProceso.Remove(item);
            }
            Console.ReadKey();
            Menu(); //Se regresa al menu
        }

        public void Terminar()
        {
            Console.WriteLine("Elija el ID de la tarea finalizar");
            foreach (Propiedad item in ListaEnProceso) //Despliega las listas en proceso para que el usuario pueda terminar 1
            {
                Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
            }
            int Opcion2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de finalizacion");
            string FechaFin = Console.ReadLine(); //Se le pregunta al usuario la fecha de finalizacion y la guarda en la variable
            var Terminando = (from SameID in ListaEnProceso where Opcion2 == SameID.ID select SameID).ToList(); //Busca la lista con el mismo ID del ingresado por el usuario
            Console.WriteLine("*Tarea Finalizada");
            foreach (var item in Terminando)
            {
                item.FechaFinal = FechaFin;
                ListaGlobal.Remove(item); //Se borra de la lista global
                item.Status = "Finalizada"; //Se le da el nuevo status de finalizado 
                ListaTerminada.Add(item); //Lo Añade a la lista de Terminadas
                ListaGlobal.Add(item); //Lo añade a la lista globales con el nuevo status
                ListaEnProceso.Remove(item); //Se remueve la lista en la lista de procesos
            }
            Console.ReadKey();
            Menu(); //Vuelve al menu
        }
        public void VerListas() //En este metodo se mostrara un 2do menu con las distintas listas existentes
        {
            Console.Clear();
            Console.WriteLine("Elija la lista que desee ver:\n1.-Lista de Pendientes \n2.-Lista de tareas en Procesos\n3.-Lista de Tareas Terminadas\n4.-ListaGlobal\n5.-Volver Al Menu"); //Menú de opciones
            int OpcionVer = int.Parse(Console.ReadLine());
            if (OpcionVer == 1 && ListaPendiente.Count != 0) //Si la opcion es 1 y la lista pendiente no esta vacia, entonces despliega todas las listas pendientes
            {
                foreach (var item in ListaPendiente)
                {
                    Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
                }
                Console.ReadKey();
                VerListas(); //Vuelve al 2do menu
            }
            else if (OpcionVer == 2 && ListaEnProceso.Count != 0) //Si la opcion es 2 y la lista de procesos no esta vacia entonces las despliega
            {
                foreach (var item in ListaEnProceso)
                {
                    Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
                }
                Console.ReadKey();
                VerListas(); //Vuelve al 2do menu
            }
            else if (OpcionVer == 3 && ListaTerminada.Count != 0) //Si la opcion es 3 y la lista de terminada no esta vacia entonces las despliega
            {
                foreach (var item in ListaTerminada)
                {
                    Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}\nFecha de Finalizacion: {5}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status, item.FechaFinal);
                }
                Console.ReadKey();
                VerListas(); //Vuelve al 2do menu
            }
            else if (OpcionVer == 4 && (ListaPendiente.Count != 0 || ListaEnProceso.Count != 0 || ListaTerminada.Count != 0)) //Si la opcion es 4 y alguna de las 3 listas no esta vacia entonces despliega la lista global
            {
                foreach (var item in ListaGlobal)
                {
                    Console.WriteLine("ID: {3}\nNombre de la tarea: {0}\nDescripcion de la tarea: {1}\nFecha de inicio: {2}\nStatus: {4}", item.Tarea, item.Descripcion, item.FechaInicio, item.ID, item.Status);
                }
                Console.ReadKey();
                VerListas(); //Vuelve al 2do menu
            }
            else if (OpcionVer < 1 || OpcionVer > 5) //si la opcion no es ninguna de las anteriores entonces se vuelve a preguntar
            {
                Console.WriteLine("Opción Invalida");
                Console.ReadKey();
                VerListas();
            }
            else if (OpcionVer == 1 && ListaPendiente.Count == 0) //Si la opcion es 1 y la lista de pendientes esta vacia entonces no hay por mostrar nada
            {
                Console.WriteLine("No se encuentra ninguna tarea pendiente");
                Console.ReadKey();
                VerListas();
            }
            else if (OpcionVer == 2 && ListaEnProceso.Count == 0) //Si la opcion es 2 y la lista de procesos esta vacia entonces no hay por mostrar nada
            {
                Console.WriteLine("No se encuentra ninguna tarea en Proceso");
                Console.ReadKey();
                VerListas();
            }
            else if (OpcionVer == 3 && ListaTerminada.Count == 0) //Si la opcion es 3 y la lista de terminadas esta vacia entonces no hay por mostrar nada
            {
                Console.WriteLine("No se encuentra ninguna tarea terminada");
                Console.ReadKey();
                VerListas();
            }
            else if ((OpcionVer == 4 && ListaPendiente.Count == 0) && (OpcionVer == 4 && ListaEnProceso.Count == 0) && (OpcionVer == 4 && ListaTerminada.Count == 0)) //Si la opcion es 4 y todas las listas estan vacias entonces no hay por mostrar nada
            {
                Console.WriteLine("No se encuentra ninguna Tarea en ninguna lista");
                Console.ReadKey();
                VerListas();
            }
            else if (OpcionVer == 5) //Si la opcion es 5 entonces volvemos al 1er menu 
            {
                Menu();
            }
        }
    }
}
