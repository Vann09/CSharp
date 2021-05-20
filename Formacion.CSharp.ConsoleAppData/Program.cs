using System;
using NorthWind.Models;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Formacion.CSharp.ConsoleAppData
{
    class Program
    {
        static void Main(string[] args)
        {
            TrabajandoConADONET();
        }

        static void TrabajandoConADONET()
        {
            //ADO.NET Access Data Object (manejamos la BD con Transat-SQL)

            //Consulta de Datos - SELECT
            //Equivalente a: SELECT * FROM Customers

            // Crear un objeto para definir la cadena de conexión
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "LOCALHOST",
                InitialCatalog = "NORTHWIND",
                UserID = "",
                Password = "",
                IntegratedSecurity = true
            };

            //Muestra la cadena de conexión resultante
            Console.WriteLine("Cadena de Conexión: {0}", connectionString.ToString());

            //Creamos un objeto conexión, representa la conexión con DB
            //Como paramétro en el constructor le pasamos la cadena de conexión
            var connect = new SqlConnection() 
            {
                ConnectionString = connectionString.ToString()
            };

            Console.WriteLine($"Estado: {connect.State.ToString()}");
            connect.Open();
            Console.WriteLine($"Estado: {connect.State.ToString()}");

            //Creamos un objeto Command que nos permite lanzar comandos contra la DB
            var command = new SqlCommand()
            {
                Connection = connect,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            //Creamos un obketo que funcione como cursor, permitiendo recorrer los datos retornados por la DB
            var reader = command.ExecuteReader();

            if(reader.HasRows == false) Console.WriteLine("Registros no encontrados.");
            else
            {
                while (reader.Read() == true)
                {
                    Console.WriteLine($"ID: {reader["CustomerID"]}");
                    Console.WriteLine($"Empresa: {reader.GetValue(1)}");
                    Console.WriteLine($"País: {reader["Country"]}" + Environment.NewLine);
                }
            }

            //Cerramos conexiones y destruimos variables
            reader.Close();
            command.Dispose();
            connect.Close();
            connect.Dispose();
        }

        static void TrabajandoConEF()
        {
            //EntityFramework (manejamos las BD como colecciones)

            //Consulta de Datos - SELECT
            //Equivalente a: SELECT * FROM Customers

            var db = new ModelNorthwind();

            var clientes = db.Customers
                .ToList();

            var clientes2 = from c in db.Customers
                            select c;

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.CustomerID}");
                Console.WriteLine($"Empresa: {cliente.CompanyName}");
                Console.WriteLine($"País: {cliente.Country}" + Environment.NewLine);
            }

        }
    }

}
