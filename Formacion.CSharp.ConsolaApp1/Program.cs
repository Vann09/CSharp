using System;
using Formacion.CSharp.Objects;

namespace Formacion.CSharp.ConsolaApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno1 = new Alumno();
            var alumno2 = new Alumno();
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();

            Console.WriteLine("Tipo Variable: " + alumno1.GetType());
            Console.WriteLine("Nombre: {0}", alumno1.Nombre);
            
            Console.WriteLine("Tipo Variable: " + alumno2.GetType());
            Console.WriteLine("Nombre: {0}", alumno2.Nombre);

            Console.WriteLine("Tipo Variable: " + alumno3.GetType());
           // Console.WriteLine("Nombre: {0}", alumno3.Nombre);
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno3).Nombre);

            Console.WriteLine("Tipo Variable: " + alumno4.GetType());
            Console.WriteLine("Nombre: {0}", alumno4.Nombre);
        }
    }
}

namespace Formacion.CSharp.Objects
{
     public class Alumno
     {
        public string Nombre = "Jose";
        public string Apellidos = "Izquierdo";
        public int Edad = 27;
     }
}