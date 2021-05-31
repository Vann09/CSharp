using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion.CSharp.ConsoleAppTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO APP");
            MainAsync();
            Console.WriteLine("FIN APP");
            Console.ReadKey();
            
        }
        static async void MainAsync()
        {
            var pruebas = new PruebaTask();

            //Usar metodo sincrono
            pruebas.Calculos();
            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i}: {pruebas.array[i]}");
            }

            //Usar metodo asincrono
            bool resultado = await pruebas.CalculosAsync();
            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i}: {pruebas.array[i]}");
            }

            //Usar metodo que retorna una tarea y no utilizamos await
            Task tarea = pruebas.CalculosAsync2();
            tarea.Start();
            tarea.Wait();
            for (int i = 0; i < pruebas.array.LongLength; i++)
            {
                Console.WriteLine($"Raíz cuadrada de {i}: {pruebas.array[i]}");
            }
            
            //Usar metodo asincrono sin await
            
            pruebas.FinCalculos += ((s, e) => {
                for (int i = 0; i < pruebas.array.LongLength; i++)
                {
                    Console.WriteLine($"Raíz cuadrada de {i}: {pruebas.array[i]}");
                }
            });
            pruebas.CalculosAsync3();

        }

        static void MainParallel()
        {
            double[] array = new double[5000000];
            List<string> frutas = new List<string>()
            {
                "manzana",
                "pera",
                "fresa",
                "melón",
                "platano",
            };

            foreach (var item in frutas)
            {
                Console.WriteLine($"Fruta: {item}");
            }
            Console.WriteLine("");
            Parallel.ForEach(frutas, item =>
            {
                Console.WriteLine($"Parallel Fruta: {item}");
            });

            //LINQ
            var frutas2 = from c in frutas
                          where c[0] == 'm'
                          select c;
            //PLINQ
            var frutas3 = from c in frutas.AsParallel()
                          where c[0] == 'm'
                          select c;


            Console.ReadKey();

            DateTime a1 = DateTime.Now;
            for (int i = 0; i < 50000000; i++) array[i] = Math.Sqrt(i);
            DateTime a2 = DateTime.Now;
            Parallel.For(0, 5000000, i => {
                array[i] = Math.Sqrt(i);
                Console.WriteLine($"Raíz cuadrada de {i}: {array[i]}");
            });
            DateTime a3 = DateTime.Now;

            Console.WriteLine("FOR -> {0}", a2.Subtract(a1).Milliseconds.ToString());
            Console.WriteLine("PARALLEL.FOR -> {0}", a3.Subtract(a2).Milliseconds.ToString());
            Console.ReadKey();
        }

        
    }

    class PruebaTask
    {

        public double[] array = new double[50000000];
        public event EventHandler<bool> FinCalculos;
        //Método de Ejecución Sincrona
        public bool Calculos()
        {
            for (int i = 0; i < 50000000; i++)
            {
                array[i] = Math.Sqrt(i);
            }

            return true;
        }

        //Método de Ejecución Asíncrono
        public async Task<bool> CalculosAsync()

        {

            return await Task<bool>.Run(() => {

                for (int i = 0; i < 50000000; i++)

                {

                    array[i] = Math.Sqrt(i);

                }



                return true;

            });

        }

        //Método que retorna una tarea sin iniciar
        public Task<bool> CalculosAsync2()

        {

            return new Task<bool>(() => {

                for (int i = 0; i < 50000000; i++)

                {

                    array[i] = Math.Sqrt(i);

                }



                return true;

            });

        }

        //El final del metodo se controla mediante un evento.
        public Task<bool> CalculosAsync3()

        {

            return Task.Run<bool>(() => {

                for (int i = 0; i < 50000000; i++)

                {

                    array[i] = Math.Sqrt(i);

                }

                FinCalculos?.Invoke(this, true);
                return true;

            });

        }

    }
}
