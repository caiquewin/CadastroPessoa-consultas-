using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;

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

        public IActionResult Index()
        {
            var list = _especialistaService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new EspecialistaFormViewModel { Departamento = departamentos };
            return View(viewModel);
        }

        [HttpPost] //anotação que o método abaixo é um post
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialista especialista)
        {
            if (!ModelState.IsValid)
            {
                return View(especialista);
            }
            _especialistaService.Insert(especialista);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new {message="Id not provided"});
            }
            var obj = _especialistaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error),new {message ="Id not fund "});
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _especialistaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message="Id not provided" });
            }
            var obj = _especialistaService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);

        }
        public IActionResult Edit(int? id)
        {
             if(id == null)
            {
                return RedirectToAction(nameof(Error),new { message = "id not provided" });
            }
            var obj = _especialistaService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error),new { message = "Id not found" });
            }
            List<Departamento> departamentos = _departamentoService.FindAll();
            EspecialistaFormViewModel viewModel = new EspecialistaFormViewModel { Especialista = obj, Departamento = departamentos } ;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Especialista especialista)
        {
            if   (id != especialista.Id)
            {
                return RedirectToAction(nameof(Error),new {message="id mismatch" });
            }
            try
            {
                _especialistaService.Update(especialista);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error),new {message=e.Message});
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