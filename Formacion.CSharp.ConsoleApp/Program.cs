using System;
using Formacion.CSharp.Objects;
using System.Linq;

namespace Formacion.CSharp.ConsolaApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] frutas2 = { "naranja", "limón", "pomelo", "líma", "fresa", "sandía", "melón" };

            int contador = 0;
            while (contador < frutas2.Length)
            {
                Console.WriteLine($"{frutas2[contador]}");
                contador++;
            }
            Console.WriteLine("");

            contador = 0;
            do
            {
                Console.WriteLine($"{frutas2[contador]}");
                contador++;
            } while (contador < frutas2.Length);
            Console.WriteLine("");

            contador = 0;
            while (true)
            {
                Console.WriteLine($"{frutas2[contador]}");
                contador++;
                if (contador == frutas2.Length) break;
                   
            }

            Console.ReadKey();

            bool testigo = false;
            while (testigo == true)
            {
                Console.WriteLine("Se ejecuta el bloque de WHILE");
            }

            do
            {
                Console.WriteLine("Se ejecuta el bloque del DO/WHILE");
            } while (testigo == true);

            


            
            
            string[] frutas = { "naranja", "limón", "pomelo", "líma" };
            Object[] Objetos = { "naranja", 10, new Alumno(), new Reserva() };
            decimal[] numeros3 = { 10, 5, 345, 55, 13, 1000, 83 };

            //Recorremos las colecciones por posición
            for (int i = 0; i < frutas.Length; i = i + 1)
            {
                Console.WriteLine($"En la posición {i}, la fruta es {frutas[i]}");
            }

            // Preguntamos un numero
            // Tabla de multiplicar del numero
            Console.Write("Introduce un nº: ");
            int Mnum = int.Parse(Console.ReadLine());

            Console.WriteLine($"Tabla de multiplicar de {Mnum}");
            for (int n = 1; n < 11; n += 1)
            {
                Console.WriteLine($"{n} x {Mnum} = {n*Mnum}");
            }
         

            // Suma total y media
            // Max y Min
            decimal suma = 0;
            decimal max = 0;
            decimal min = 10;

            for (int e = 0; e < numeros3.Length; e += 1)
            {
                suma = suma + numeros3[e];
                if (numeros3[e] > max) max = numeros3[e];
                if (numeros3[e] < min) min = numeros3[e];

            }
            Console.WriteLine($"La suma total es {suma} y la media es {(suma/numeros3.Length)}");
            Console.WriteLine($"El Max es {max} y el Min es {min}");
            Console.WriteLine("");

            suma = 0;
            foreach (var n in numeros3)
            {
                suma += n;
                if (min > max) max = n;
                if (n < min) min = n;
            }
            Console.WriteLine($"La suma total es {suma} y la media es {(suma / numeros3.Length)}");
            Console.WriteLine($"El Max es {max} y el Min es {min}");
            Console.WriteLine("");

            Console.WriteLine($"La suma total es {numeros3.Sum()} y la media es {numeros3.Average()}");
            Console.WriteLine($"El Max es {numeros3.Max()} y el Min es {numeros3.Min()}");


            //Recorremos una colección recuperando sus valores
            foreach (string fruta in frutas)
            {
                Console.WriteLine($"Fruta: {fruta}");
            }

            foreach (var o in Objetos)
            {
                Console.WriteLine($"Tipo: {o.GetType().ToString()}");
            }

            foreach (decimal n in numeros3)
            {
                Console.WriteLine($"Num: {n}");
            }

            Reserva reserva = new Reserva();

            Console.Write("ID de la Reserva: ");
            reserva.id = Console.ReadLine();

            Console.Write("Nombre del Cliente: ");
            reserva.cliente = Console.ReadLine();

            //100: Habitación individual  200: Habitación doble   300: Junior suite    400: Suite
            Console.Write("Tipo de Reserva: ");
            //reserva.tipo = Convert.ToInt32(Console.ReadLine());

            string respuesta = Console.ReadLine();
            int.TryParse(respuesta, out reserva.tipo);

            Console.Write("Es Fumador ? ");
            //reserva.fumador = Convert.ToBoolean(Console.ReadLine()); 

            string respuesta2 = Console.ReadLine();
            if (respuesta2.ToLower().Trim()== "si" || respuesta2.ToLower().Trim()== "sí")
            {
                reserva.fumador = true;
            }
            else 
            {
                reserva.fumador = false;
            }


            if (respuesta2.ToLower().Trim()== "si" || respuesta2.ToLower().Trim()== "sí")
                reserva.fumador = true;
            else reserva.fumador = false;

            reserva.fumador = (respuesta2.ToLower().Trim() == "si" || respuesta2.ToLower().Trim() == "sí") ? true : false;

            switch (respuesta2.ToLower().Trim())
            {
                case "si":
                    reserva.fumador = true;
                    break;
                case "sí":
                    reserva.fumador = true;
                    break;
                default:
                    reserva.fumador = false;
                    break;
            }

            Console.Clear();

            //Pinta nº de reserva
            Console.Write("ID Reserva:");
            Console.WriteLine (reserva.id);

            //Pinta nonmbre cliente
            Console.WriteLine ("El nombre del cliente es " + reserva.cliente);

            //Pinta tipo de reserva en texto
            if (reserva.tipo == 100)
                Console.WriteLine("Has reservado una habitación individual.");
            else if (reserva.tipo == 200)
                Console.WriteLine("Has reservado una habitación doble.");
            else if (reserva.tipo == 300)
                Console.WriteLine("Has reservado una junior suite.");
            else if (reserva.tipo == 400)
                Console.WriteLine("Has reservado una suite.");
            else
                Console.WriteLine("No has reservado una habitación.");

            //Pinta si es fumador en texto
            switch (reserva.fumador)
            {
                case true:
                    Console.WriteLine ("El cliente es fumador.");
                    break;
                default:
                    Console.WriteLine ("El cliente es no fumador.");
                    break;
            }



            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de variables
            //  [tipo] [nombre variable] = [valor inicial (opcional)]
            //
            //  Valor por defecto para variables de tipo valor (númericas), 0
            //  Valor por defecto para variables de tipo referencía Null
            //
            ///////////////////////////////////////////////////////////////

            string texto = "Hola Mundo !!!";
            string otroTexto;
            int numero = 10;
            int otroNumero;
            decimal a, b, c;


            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de variables que contienen objetos
            //  [tipo] [nombre variable] = [new constructor (opcional)]
            //
            ///////////////////////////////////////////////////////////////

            //Instanciamos un objeto y modificamos sus propiedades o variables
            Alumno alumno = new Alumno()
            {
                Nombre = "David",
                Apellidos = "Sánchez",
                Edad = 23
            };

            //Instanciamos un objeto y modificamos sus propiedades o variables
            Alumno alumno1 = new Alumno();
            alumno1.Nombre = "David";
            alumno1.Apellidos = "Sánchez";
            alumno1.Edad = 23;

            //Instaciamos un objeto con VAR, OBJECT y DYNAMIC
            var alumno2 = new Alumno();
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();

            Console.WriteLine("Tipo Variable 1: " + alumno1.GetType());
            Console.WriteLine("Nombre: {0}", alumno1.Nombre);

            Console.WriteLine("Tipo Variable 2: {0}", alumno2.GetType());
            Console.WriteLine("Nombre: {0}", alumno2.Nombre);

            Console.WriteLine($"Tipo Variable 3: {alumno3.GetType()}");
            //Console.WriteLine("Nombre: {0}", alumno3.Nombre));
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno3).Nombre);

            Console.WriteLine("Tipo Variable 4: " + alumno4.GetType());
            Console.WriteLine("Nombre: {0}", alumno4.Nombre);
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno4).Nombre);


            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de un Array
            //  [tipo][] [nombre variable] = [valor inicial]
            //
            ///////////////////////////////////////////////////////////////

            int[] numeros = new int[10];
            int[] numeros2 = { 10, 5, 345, 55, 13, 1000, 83 };

            numeros[7] = 32;
            Console.WriteLine(numeros2[5]);

            Alumno[] alumnos = new Alumno[20];
            Alumno[] alumnos2 = { new Alumno() { Nombre = "David", Apellidos = "Sánchez", Edad = 23 }, new Alumno(), new Alumno() };
            Alumno[] alumnos3 = { new Alumno(), new Alumno(), new Alumno() };

            alumnos3[1].Nombre = "María Jesus";
            alumnos3[1].Apellidos = "Campos";
            alumnos3[1].Edad = 22;
            Console.WriteLine(alumnos3[1].Nombre);


            ///////////////////////////////////////////////////////////////
            //
            //  Conversión de variables
            //
            ///////////////////////////////////////////////////////////////

            byte num1 = 10;        //8 bits
            int num2 = 32;         //32 bits
            string num3 = "42";

            Console.WriteLine("A: {0} - B: {1}", num1, num2);

            //Conversión implicita, SI es posible porque el receptor es de mayor tamaño en bits
            num2 = num1;

            //Conversión implicita, NO es posible porque el receptor es de menor tamaño en bits
            //num1 = num2;      

            //Conversión explicita, indicada por el programador
            num1 = (byte)num2;

            //Conversion explicita, con el objeto CONVERT
            num1 = Convert.ToByte(num2);
            num1 = Convert.ToByte(num3);

            //Conversión explicita utilizando el método Parse
            num1 = byte.Parse(num3);

            //Conversión explicita utilizando el método TryParse
            byte.TryParse(num3, out num1);

            Console.WriteLine("A: {0} - B: {1}", num1, num2);



            int n1 = 10;
            int? n2 = null;

            int r1;

            r1 = n1;
            //r1 = n2;
            r1 = (int)n2;

            if (n2 == null) r1 = 0;
            else r1 = (int)n2;

            r1 = (n2 == null) ? r1 = 0 : r1 = (int)n2;



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

        public void Funcion()
        { }
    }

    public class Reserva
    {
        public string id;
        public string cliente;

        //100: Habitación individual  200: Habitación doble   300: Junior suite    400: Suite
        public int tipo;
        public bool fumador;
    }
}

namespace Universidad
{
    class Alumno
    {
        string Nombre;
        string Apellidos;
        int Edad;
    }
}