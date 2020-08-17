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
    }
}