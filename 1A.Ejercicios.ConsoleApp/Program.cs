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
            Numero();
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


    }   
}


