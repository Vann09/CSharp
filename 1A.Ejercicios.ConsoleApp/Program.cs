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
            SecFor();
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
            int num;
            do
            {
                num = Convert.ToInt32(Console.ReadLine());
                if ((numero - num) >= 25)
                {
                    Console.WriteLine($"El número {num} es demasiado pequeño.");
                }
                else if (numero > num)
                {
                    Console.WriteLine($"El número {num} es  pequeño.");
                }
                if ((num - numero) >= 25)
                {
                    Console.WriteLine($"El número {num} es demasiado grande.");
                }
                else if (numero < num)
                {
                    Console.WriteLine($"El número {num} es grande.");
                }
                if (numero == num)
                {
                    Console.WriteLine($"Has acertado, el número era {num}.");
                }
                
            } while (numero != num);
            
        }
    
        static void SecFor()
        {
            //F1. Muestra las siguientes secuencias de número utilizando un FOR:

            /*del 1 al 100 DONE
            for (int i = 1; i < 101; i++) Console.WriteLine(i);*/

            /*del 200 al 190 DONE
            for (int i = 0; i < 11; i++ ) Console.WriteLine(200-i);*/

            /*del 10 a 10000 de 100 en 100
            for (int i = 1; i < 10000; i = i + 100) Console.WriteLine(i);*/

            /*los números impares del 51 al 91 DONE
            for (int i = 51; i < 93; i = i + 2) Console.WriteLine(i);*/


        }


    }   

}


