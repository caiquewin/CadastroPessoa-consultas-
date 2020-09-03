﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //anotação que o método abaixo é um post
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialista especialista)
        {
            _especialistaService.Insert(especialista);
            return RedirectToAction(nameof(Index));
        }
    }
}