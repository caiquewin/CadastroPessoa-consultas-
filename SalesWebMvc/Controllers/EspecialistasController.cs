using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;

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
            _especialistaService.Insert(especialista);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _especialistaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
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
                return NotFound();
            }
            var obj = _especialistaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
    }
}