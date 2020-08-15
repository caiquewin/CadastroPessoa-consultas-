using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            List<Cliente> lis = new List<Cliente>();
            lis.Add(new Cliente { Id = 1, Name = "Caique" });
            lis.Add(new Cliente { Id = 2, Name = "Alves" });
            return View(lis);
        }
    }
}