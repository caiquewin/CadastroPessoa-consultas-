using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {

        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Nome = "Departamento x", Salario = 3000.00 });
            list.Add(new Departamento { Id = 2, Nome = "Departamento y", Salario = 5000.00 });
            list.Add(new Departamento { Id = 3, Nome = "Departamento c", Salario = 4000.00 });
            return View(list);
        }
    }
}