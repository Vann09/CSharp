using System;
using System.Collections.Generic;
using System.Linq;

namespace Formacion.CSharp.ConsoleAppInherited
{
    class Program
    {
        static void Main(string[] args)
        {
            Lavadora lavadora = new Lavadora();
            IElectrodomestico nevera = new Nevera();
            
            var demo = new DemoB();
            demo.Nombre = "Jose";
            demo.Apellidos = "Izquierdo";
            demo.Edad = 27;

            demo.PintaDatos();
        }
    }
    
    class DemoA
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public virtual void PintaDatos()
        {
            Console.WriteLine($"{Nombre} {Apellidos}");
        }
    }

    sealed class DemoB : DemoA
    {
        public override void PintaDatos()
        {
            base.PintaDatos();
            Console.WriteLine($"Nombre: {Nombre} {Apellidos}");
            Console.WriteLine($"Edad: {Edad}");

        }
        public void PintaDatos2()
        {
            Console.WriteLine($"{Nombre} {Apellidos} - {Edad}");
        }
        public void PintaDatosHijo()
        {
            PintaDatos();
            
        }
        public void PintaDatosPadre()
        {
            base.PintaDatos();

        }
    }

    class DemoC 
    {
        
    }

    interface IElectrodomestico
    {
        int ConsumoWatt { get; set; }
        string Nombre { get; set; }
        string Color { get; set; }
        void Encender();
        void Apagar();

    }

    interface IDispositivoDomotica
    {
        void Encender();
        void Apagar();
    }

    class Nevera : IElectrodomestico, IDispositivoDomotica
    {
        public int ConsumoWatt { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Puertas { get; set; }
        public int TempMin { get; set; }
        public void Apagar()
        {
            Console.WriteLine(" Nevera Off");
        }
        public void Encender()
        {
            Console.WriteLine(" Nevera On");
        }
        void IDispositivoDomotica.Apagar()
        {
            Console.WriteLine("Domótica Nevera Off");
        }

        void IDispositivoDomotica.Encender()
        {
            Console.WriteLine("Domótica Nevera On");
        }
         void IElectrodomestico.Apagar()
        {
            Console.WriteLine("Electro Nevera Off");
        }

         void IElectrodomestico.Encender()
        {
            Console.WriteLine("Electro Nevera On");
        }

        public void TurboCool()
        {
            Console.WriteLine("Nevera TurboCool");
        }
    }

    class Lavadora : IElectrodomestico
    {
        public int ConsumoWatt { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Revoluciones { get; set; }
        
        public void Apagar()
        {
            Console.WriteLine("Lavadora Off");
        }

        public void Encender()
        {
            Console.WriteLine("Lavadora On");
        }
        public void PintarFicha()
        {
            Console.WriteLine($"Lavadora de color {Color}, con un máximo de {Revoluciones} revoluciones.");
        }
    }
}

