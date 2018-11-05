using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Propiedad
    {
        public int ID { get; set; }
        public string Tarea { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string Status { get; set; }
    }
}
