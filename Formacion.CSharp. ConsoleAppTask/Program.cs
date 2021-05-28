using System;
using System.Threading.Tasks;

namespace Formacion.CSharp._ConsoleAppTask
{
    delegate void Demo1();
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO DE LA APP");
            CreacionTareas();
            Console.WriteLine("FIN DE LA APP");
        }

        static void Saludo()
        {
            Console.WriteLine("Hola mundo !!!");
        }

        static void Saludo2(string nombre)
        {
            Console.WriteLine($"Hola {nombre} !!!");
        }

        static void CreacionTareas()
        {
            Demo1 demo = Saludo;

            Task tarea1 = new Task(new Action(Saludo));

            Task tarea2 = new Task(delegate {
                Console.WriteLine("Tarea 2 ejecutandose");
            });

            Task tarea3 = new Task(() => {
                Console.WriteLine("Tarea 3 ejecutandose");
            });

            Task tarea4 = new Task(new Action(demo));

            Task tarea5 = Task.Run(() => {
                Console.WriteLine("Tarea 5 ejecutandose");
            });
        }
    }
}
