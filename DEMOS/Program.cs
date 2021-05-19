using System;
using System.Collections;
using System.Collections.Generic;

namespace DEMOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary();
        }

        static void ArrayList() 
        {
            var array = new ArrayList();

            //Elimina todos los elementos de la colección
            array.Clear();

            //Añadir elementos a la colección
            array.Add("azul");
            array.Add("rojo");
            array.Add("amarillo");
            array.Add("verde");

            //Añadir todos los elemtos de otra colección
            var colores = new string[] { "marrón", "naranja", "morado" };
            array.AddRange(colores);

            //Número de elementos
            Console.WriteLine($"Número de items: {array.Count}");

            //Recorrer elementos
            foreach (var item in array)
            {
                Console.WriteLine("Item: {0}", item);
            }
            for (var i = 0; i < array.Count; i++)
            {
                Console.WriteLine("Item: {0}", array[i]);
            }

            //Eliminar un elemento de la colección
            array.Remove("verde");
            array.RemoveAt(4);
            array.RemoveRange(2, 2);
        }

        static void HashTable()
        {
            var dicc = new Hashtable();

            //Eliminar todos los elementos del diccionario
            dicc.Clear();

            //Añadir elementos
            dicc.Add("ANATR", "Ana Trujillo");
            dicc.Add("ANTON", "Antonio Sanz");
            dicc.Add("CARSA", "Carlos Sánchez");

            //Recorrer elementos
            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine($"{clave}-> {dicc[clave]}");
            }

            //Mostrar el nº de elementos
            Console.WriteLine("Número de elementos {0}", dicc.Count);

            //Eliminar un elemento
            dicc.Remove("ANTON");
        }
    
        static void List()
        {
            var lista = new List<string>();


            lista.Clear();

            //Añadir elementos
            lista.Add("azul");
            lista.Add("verde");
            lista.Add("amarillo");
            lista.Add("rojo");
            lista.Add("negro");
            lista.Add("Blanco");

            //Recorrer
            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            //Mostrar el nº de elementos
            Console.WriteLine("Número de elementos {0}", lista.Count);

            //Eliminar elementos
            lista.Remove("azul");
            lista.RemoveAt(4);
            


        }

        static void Dictionary()
        {
            var dicc = new Dictionary<int, string>();

            dicc.Clear();

            dicc.Add(1, "azul");
            dicc.Add(2, "verde");
            dicc.Add(10, "rojo");
            dicc.Add(100, "amarillo");
            dicc.Add(95, "rosa");
            dicc.Add(80, "negro");

            Console.WriteLine("Número de elementos {0}", dicc.Count);

            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine("Clave: {0} - Valor: {1}", clave, dicc[clave]);
            }

            dicc.Remove(90);
        }
    }   

}
