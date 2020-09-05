using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClientesController(ClienteService clienteService)
        {
            _clienteService= clienteService;
        }
        public  IActionResult Index()
        {
            var list = _clienteService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var clien = _clienteService.FindAll();
                var viewModel = new EspecialistaFormViewModel { Cliente=clien };
                return View(viewModel);
            }
            _clienteService.Insert(cliente);
            return RedirectToAction(nameof(Index));
            

        }

    }
}
