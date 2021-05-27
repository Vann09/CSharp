using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace Formacion.CSharp.WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        ModelNorthwind context;

        //Mostrar listado de clientes
        public IActionResult Index()
        {
            //var http = new HttpClient();
            //http.BaseAddress = new Uri ("");

           //var clientes = http.GetFromJsonAsync<List<Customers>>("customers").Result;

            var clientes = context.Customers.ToList();
            ViewBag.Title = "Listado de Clientes";

            return View(clientes);
        }

        public IActionResult Ficha(string id)
        {
            var cliente = context.Customers
                .Where (r => r.CustomerID == id)
                .FirstOrDefault();

            ViewBag.Title = $"Ficha de {cliente.CompanyName}";

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Grabar(Customers cliente)
        {
            context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Ficha", new { id = cliente.CustomerID});
            //return View("Ficha", cliente);
            //return RedirectToAction("Index");
        }


        public ClientesController(ModelNorthwind context)
        {
            this.context = context;
        }
    }
}
