using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using NorthWind.Models;
using System.Net.Http.Headers;

namespace Formacion.CSharp.ConsoleAppAPIClient
{
    class Program
    {
        static readonly HttpClient http = new HttpClient();
        static readonly string url = "http://api.labs.com.es/v1.0/";

        static void Main(string[] args)
        {
            APINorthwindPut();
        }

        static void HttpwithDynamic()
        {
            http.BaseAddress = new Uri(url);
            var response = http.GetAsync("clientes.ashx?all").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", content);

                var clientes = JsonConvert.DeserializeObject<List<dynamic>>(content);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
        }

        static void HttpwithCustomers()
        {
            http.BaseAddress = new Uri(url);
            var response = http.GetAsync("clientes.ashx?all").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", content);

                var clientes = JsonConvert.DeserializeObject<List<Customers>>(content);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
        }

        static void HttpClientDemo()
        {
            http.BaseAddress = new Uri(url);
            var clientes = http.GetFromJsonAsync<List<Customers>>("clientes.ashx?all").Result;

            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
            }
        }

        static void HttpClientWithHeaders()
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, "http://api.labs.com.es/v1.0/clientes.ashx?all");

            request.Headers.Clear();
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("User-Agent", "ConsoleApp for Northwind");
            request.Headers.Add("Authorization", "key of access");

            var response = http.SendAsync(request).Result;
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", content);

                var clientes = JsonConvert.DeserializeObject<List<Customers>>(content);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
        }

        static void HttpClientWithHeaders2()
        {
            http.BaseAddress = new Uri(url);

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("ContentType", "application/json");
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("User-Agent", "ConsoleApp for Northwind");
            http.DefaultRequestHeaders.Add("Authorization", "key of access");

            var response = http.GetAsync("clientes.ashx?all").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Respuesta JSON: {0}", content);

                var clientes = JsonConvert.DeserializeObject<List<Customers>>(content);

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.CustomerID}# {c.CompanyName} - {c.Country}");
                }
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());

        }

        static void HttpClientPost()
        {
            http.BaseAddress = new Uri("http://postman-echo.com/");

            var region = new Region() {RegionID = 10, RegionDescription = "Comunidad de Madrid" };

            var regionJSON = JsonConvert.SerializeObject(region);
            Console.WriteLine($"Región en JSON: {regionJSON}");

            var content = new StringContent(regionJSON, System.Text.Encoding.UTF8, "application/json");

            var response = http.PostAsync("post", content).Result;
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Respuesta: {responseContent}");
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());

        }

        static void Ejercicio1()
        {

            http.BaseAddress = new Uri("http://ip-api.com/json/");
           
            Console.WriteLine("Dime una ip: ");
            var ip = Console.ReadLine();
          
            var response = http.GetAsync(ip).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var datos = JsonConvert.DeserializeObject<dynamic>(content);
                
                Console.WriteLine(datos.country);
                Console.WriteLine(datos.city);
                Console.WriteLine(datos["as"]);
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());

        }

        static void Ejercicio2()
        {
            http.BaseAddress = new Uri("https://localhost:44312/api/v1.0/");
            //empleados.ashx?id=3

            Console.WriteLine("ID Empleado: ");
            var id = Console.ReadLine();
            var response = http.GetAsync($"empleados.ashx?id={id}").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentType = response.Content.Headers.ContentType.MediaType;
                var content = response.Content.ReadAsStringAsync().Result;

                if (contentType == "text/plain")
                {
                    Console.WriteLine(content);
                }
                else
                {
                    var empleado = JsonConvert.DeserializeObject<Employees>(content);

                    Console.WriteLine($"{empleado.FirstName} {empleado.LastName}");
                    Console.WriteLine($"{empleado.Title}");
                    Console.WriteLine($"{empleado.Country} {empleado.City}");
                }
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
        }

        static void APINorthwindGet()
        {
            //products/15
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://localhost:44355/api/");
            Console.WriteLine("Id del producto: ");
            var id = Console.ReadLine();

            

            switch (id.ToLower())
            {
                case "all":
                    response = http.GetAsync("Products").Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var productos = JsonConvert.DeserializeObject<List<Products>>(content);

                        foreach (var p in productos)
                        Console.WriteLine($" {p.ProductID}# Producto: {p.ProductName} Proveedor: {p.Supplier}");
                    }
                    else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
                    break;
                default:
                    response = http.GetAsync($"Products/{id}").Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var producto = JsonConvert.DeserializeObject<Products>(content);

                        Console.WriteLine($" {producto.ProductID}# Producto: {producto.ProductName}");
                        Console.WriteLine($"Stock: {producto.UnitsInStock} Precio: {producto.UnitPrice}");
                    }
                    else Console.WriteLine("Error: {0}", response.StatusCode.ToString());
                    break;
            }
        }    

        static void APINorthwindPost() //78 he creado
        {
            http.BaseAddress = new Uri("https://localhost:44355/api/");
            HttpResponseMessage response;

            var producto = new Products();
            Console.WriteLine("Nombre del producto: ");
            producto.ProductName = Console.ReadLine();
            producto.UnitPrice = (decimal?)3.54;
            producto.UnitsInStock = 10;
            producto.SupplierID = 2;
            producto.QuantityPerUnit = "2";

            var productoJSON = JsonConvert.SerializeObject(producto);
            Console.WriteLine($"Producto en JSON: {productoJSON}");

            var content = new StringContent(productoJSON, System.Text.Encoding.UTF8, "application/json");

            response = http.PostAsync("products", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Respuesta: {responseContent}");
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());

        }

        static void APINorthwindPut()
        {
            http.BaseAddress = new Uri("https://localhost:44355/api/");
            HttpResponseMessage response;
           
            Console.WriteLine("Id del producto: ");
            var id = Console.ReadLine();

            var producto = http.GetFromJsonAsync<Products>($"Products/{id}").Result;
            Console.WriteLine("Nombre del producto: ");
            producto.ProductName = Console.ReadLine();
            Console.WriteLine("Precio: ");
            producto.UnitPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Unidades: ");
            producto.UnitsInStock = (short?)Convert.ToInt32(Console.ReadLine());
            producto.SupplierID = 2;
            producto.QuantityPerUnit = "2";

            var productoJSON = JsonConvert.SerializeObject(producto);
            Console.WriteLine($"Producto en JSON: {productoJSON}");

            var content = new StringContent(productoJSON, System.Text.Encoding.UTF8, "application/json");

            response = http.PutAsync("products", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Respuesta: {responseContent}");
                
            }
            else Console.WriteLine("Error: {0}", response.StatusCode.ToString());

        }

        static void APINorthwindDelete()
        {

        }
    }









}
    

