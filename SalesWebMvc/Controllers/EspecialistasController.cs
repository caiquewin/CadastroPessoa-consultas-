using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class EspecialistasController : Controller
    {
        private readonly EspecialistaService _especialistaService;

        public EspecialistasController(EspecialistaService especialistaService)
        {
            _especialistaService = especialistaService;
        }
        public IActionResult Index()
        {
            var list = _especialistaService.FindAll();
            return View(list);
        }
        public IActionResult Create()// ação pra criar um Especialista novo (
        {
            return View();
        }
        [HttpPost]//estou indicando que ação é uma ação de POST não de GET
        [ValidateAntiForgeryToken]//prevenção contra ataques (CSRF)
        public IActionResult Create(Especialista especialista)
        {
            _especialistaService.Insert(especialista);
            return RedirectToAction(nameof(Index));
        }
    }
}