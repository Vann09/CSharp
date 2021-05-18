using System;

namespace Formacion.CSharp.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable de tipo referencia. Objeto definido con Class
            var alumno = new Alumno() {Nombre = "Ana", Apellidos = "Diaz" };
            int a = 10;

            Console.WriteLine($"{alumno.Nombre} {alumno.Apellidos} - {a}");
            Transformar(alumno,ref a);
            Console.WriteLine($"{alumno.Nombre} {alumno.Apellidos} - {a}" + Environment.NewLine);

            //Variable de tipo valor. Objeto definido con Struct
            var alumno2 = new Alumno2() { nombre = "Ana", apellidos = "Diaz" };

            Console.WriteLine($"{alumno2.nombre} {alumno2.apellidos}");
            Transformar(ref alumno2);
            Console.WriteLine($"{alumno2.nombre} {alumno2.apellidos}" + Environment.NewLine);
       
        
        }
        static void Transformar(Alumno a,ref int numero )
        {
            a.Nombre = "Jose";
            a.Apellidos = "Izquierdo";
            numero = 1200;
        }

        static void Transformar (ref Alumno2 a)
        {
            a.nombre = "Jose";
            a.apellidos = "Izquierdo";
        }

    }



    public class Alumno
    {
        //Miembros: Variables
        private string nombre;
        private int edad;

        //Miembros: Propiedad asociada a una variable
        public string Nombre
        {
            //Retornamos la información despues de transformarla.
            get 
            {
                return nombre;
            }

            //Tratamos la información antes de almacenarla en la variable
            set 
            {
                if (value.Length < 2) nombre = "";

                else nombre = value;
            }
        }

        //Miembros: Propiedad sin variable
        public string Apellidos { get; set; }

        //Miembros: Propiedad asociada a una variable
        public int Edad
        { 
            get { return edad; }
            set 
            {
                if (value < 1 || value > 130) edad = 0;
                else edad = value;
            }
        }

        //Miembros: Propiedad de solo lectura con Get
        public string NombreCompleto
        {
            get
            {
                return $"{this.Nombre}{this.Apellidos}";
            }
        }

        //Miembros: Propiedad de solo escritura con Set
        public int CambiaEdad
        {
            set
            {
                edad = value;
            }
        }

        //Miembros: Métodos con tipo VOID, no retorna información
        public void MetodoUno()
        { }

        //Miembros: Métodos con tipo que retorna información
        public bool Metodo2()
        {
            return true;       
        }

        //Miembros: Constructor, es público, no tiene tipo y se llama igual que la clase
        public Alumno() 
        {
        
        }

        //Sobrecarga del método constructor
        public Alumno(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.Apellidos = apellidos;
        }

        //Miembros: Destructores, no tiene tipo, comienza por ~ (Altgrap+4 o Alt+0126) más el nombre de la clase
        //No se le puede llamar, se ejecuta automáticamente
        //No tiene parámetros
        ~Alumno() 
        { }
    }

    public struct Alumno2
    {
        public string nombre;
        public string apellidos;
    }
}
