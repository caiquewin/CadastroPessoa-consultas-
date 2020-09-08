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
        public async Task<IActionResult> Index()
        {
            var list = await _clienteService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var clien = await _clienteService.FindAllAsync();
                var viewModel = new ConsultaFormViewModel { Cliente=clien };
                return View(viewModel);
            }
            await _clienteService.InsertAsync(cliente);
            return RedirectToAction(nameof(Index));
            

        }

    }
}
