using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class ConsultasController : Controller
    {
        // private readonly SalesWebMvcContext _context;
        private readonly EspecialistaService _especialistaService;
        private readonly ClienteService _clienteService;
        private readonly ConsultaService _consultaService;

        public ConsultasController(ConsultaService consultaService,ClienteService clienteService,EspecialistaService especialistaService)
        {
            _consultaService = consultaService;
            _clienteService = clienteService;
            _especialistaService = especialistaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _consultaService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            
            var especialistas = await _especialistaService.FindAllAsync();
            var clientes = await _clienteService.FindAllAsync();
            var viewModel = new ConsultaFormViewModel { Especialista = especialistas, Cliente=clientes };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consulta consulta)
        {

            if (!ModelState.IsValid)//validação do JavaScript estiver desabilitado
            {
                var cliente = await _clienteService.FindAllAsync();
                var especialisa = await _especialistaService.FindAllAsync();
                var viewModel = new ConsultaFormViewModel { Cliente = cliente, Especialista = especialisa,Consulta=consulta};
                return View(viewModel);
            }
             await _consultaService.InsertAsync(consulta); 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _consultaService.FindByIdAsync(id.Value);
            return View(obj);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consultaService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
                var obj = await _consultaService.FindByIdAsync(id.Value);
            if(obj==null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _consultaService.FindByIdAsync(id.Value);//iremos procurar se existe a id da consulta

            List<Especialista> especialistas= await _especialistaService.FindAllAsync();//vamos refazer a lista de  todo especialistas
           
            List<Cliente> clientes = await _clienteService.FindAllAsync(); //vamos refazer a lista de  todo cliente
           
            ConsultaFormViewModel viewModel = new ConsultaFormViewModel {Consulta =obj, Especialista = especialistas, Cliente = clientes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Consulta consulta)
        {
            if (!ModelState.IsValid)//validação do JavaScript estiver desabilitado
            {
                var cliente = await _clienteService.FindAllAsync();
                var especialisa =await _especialistaService.FindAllAsync();
                var viewModel = new ConsultaFormViewModel { Cliente = cliente, Especialista = especialisa, Consulta = consulta };
                return View(viewModel);
            }
           await _consultaService.UpdateAsync(consulta);
                return RedirectToAction(nameof(Index));
            
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier//aqui estou pegando o Id da requisição
            };
            return View(viewModel);

        }
    }
}


