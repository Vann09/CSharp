using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            //Traspasamos info a la vista utilizando ViewBag

            ViewBag.numero = id;
            ViewBag.mensaje = $"Tabla de Multiplicar del {id}";

            //Traspasamos info como modelo de datos
            return View(id);
        }

        public IActionResult Demo() 
        {
            return View();
        }
    }


}
