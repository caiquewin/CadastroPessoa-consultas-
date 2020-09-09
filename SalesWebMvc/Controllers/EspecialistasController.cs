using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class EspecialistasController : Controller
    {
        private readonly EspecialistaService _especialistaService;
        private readonly DepartamentoService _departamentoService;
        public EspecialistasController(EspecialistaService especialistaService, DepartamentoService departamentoService)
        {
            _especialistaService = especialistaService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _especialistaService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new EspecialistaFormViewModel { Departamento = departamentos };
            return View(viewModel);
        }

        [HttpPost] //anotação que o método abaixo é um post
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Especialista especialista)
        {
            if (!ModelState.IsValid)//validação do JavaScript estiver desabilitado
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new EspecialistaFormViewModel { Departamento = departamentos };
                return View(viewModel);
            }
            await _especialistaService.InsertAsync(especialista);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _especialistaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not fund " });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _especialistaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntergrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _especialistaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);

        }
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provided" });
            }
            var obj = await _especialistaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            EspecialistaFormViewModel viewModel = new EspecialistaFormViewModel { Especialista = obj, Departamento = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Especialista especialista)
        {
            if (!ModelState.IsValid)//validação do JavaScript estiver desabilitado
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new EspecialistaFormViewModel { Departamento = departamentos };
                return View(viewModel);
            }
            if (id != especialista.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "id mismatch" });
            }
            try
            {
                await _especialistaService.UpdateAsync(especialista);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

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