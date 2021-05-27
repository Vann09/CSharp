using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _1A.Ejercicios.ConsoleApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Adivinanza();
        }

        static void Saludo()
        {
            string cadena = "Hola mundo !!";
            //A1. Pregunta el nombre de Operador y muestra un saludo incluyendo el contenido de la variable cadena.
            Console.WriteLine("Dime tu nombre: ");
            string name = Console.ReadLine();
            string txt = $"{cadena} Soy {name}";
            Console.WriteLine(txt);

            //A2. Muestra el saludo en mayúsculas, minúsculas y con la letra de cada palabra en mayúsculas.
            Console.WriteLine(txt.ToUpper());
            Console.WriteLine(txt.ToLower());
            Console.WriteLine(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(txt));
        }

        static void Numero()
        {
            //B1. Pregunta un número al operador y muestra el resultado de multiplicarlo por PI.
            Console.WriteLine("Dime un número: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{num} x {Math.PI} = {num*Math.PI}" + Environment.NewLine);

            //B2. Muestra la raíz cuadrada del mismo número.
            Console.WriteLine($"La raíz cuadrada de {num} es {Math.Sqrt(num)}" + Environment.NewLine);

            //B3.Muestra el arco coseno del mismo número.
            if (num  > 1 || num < -1)
            {
                Console.WriteLine("El número no es correcto");
            }
            else Console.WriteLine($"El arco coseno de {num} es {Math.Acos(num)}");

        }   

        static void Array()
        {
            //C1.Muestra el número de elementos de ***lista * **
            string[] lista = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            Console.WriteLine($"Hay {lista.Length} elementos en la lista.");

            //C2. Muestra el primer y el último elemento de ***lista***
            Console.WriteLine($"El primer elemento de la lista es {lista[0]} y el último {lista[22]}");

        }

        static void Dni()
        {
            string[] lista = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            //D1. Pregunta al operador su DNI sin letra.
            Console.WriteLine("Dime tu DNI sin la letra: ");
            var dni = Console.ReadLine();
            if (dni.Length == 8)
            {
                //D2. Calcula el resto de dividir el número del DNI entre 23.
                var letra = Convert.ToInt32(dni) % 23;

                //D3. Muestra el DNI con la letra. El resto de la división representa la posición de la letra del DNI en ***lista***.
                Console.WriteLine($"La letra del DNI es {lista[letra]} y el DNI completo es {dni}-{lista[letra]}");
            }
            else Console.WriteLine("El DNI introducido no es válido.");


        }

        static void Adivinanza()
        {
            //E1. Pregunta un número al operador y muestra el mensaje los siguientes mensajes:
            int numero = 100;
            Console.WriteLine("Dime un número: ");
            Convert.ToInt32(Console.ReadLine());
        }
    }   
}


