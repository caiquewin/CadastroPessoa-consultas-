using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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

        // GET: Consultas
        public IActionResult Index()
        {
            // return View(await Consulta.Include(obj =>obj.Especialista).Include(cli =>cli.Cliente).ToListAsync());
            var list = _consultaService.FindAll();
            return View(list);
        }

        // GET: Consultas/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }*/

        // GET: Consultas/Create
        public IActionResult Create()
        {
            var especialistas = _especialistaService.FindAll();
            var clientes = _clienteService.FindAll();
            var viewModel = new ConsultaFormViewModel { Especialista = especialistas, Cliente=clientes };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consulta consulta)
        {
            _consultaService.Insert(consulta); 
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var obj = _consultaService.FindById(id.Value);
            return View(obj);
        }
        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,StatusPagamento,Comentario")] Consulta consulta)
          {
              if (!ModelState.IsValid)
              {
                 // var Con = _consultaService.FindAll();
                  //var viewModel = new EspecialistaFormViewModel { Consultas =Con };
                  return View(RedirectToAction(nameof(Index)));
              }
              _consultaService.Insert(consulta);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }*/

        // GET: Consultas/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }*/

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,Data,StatusPagamento,Comentario")] Consulta consulta)
         {
             if (!ModelState.IsValid)
             {
                 return View(consulta);
             }
             if (id != consulta.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(consulta);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!ConsultaExists(consulta.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(consulta);
         }*/

        // GET: Consultas/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }
        */
        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _consultaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
             var obj = _consultaService.FindById(id.Value);
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            var obj = _consultaService.FindById(id.Value);
            return View(obj);
        }
        /*private bool ConsultaExists(int id)
        {
            return _context.Consulta.Any(e => e.Id == id);

        }*/
    }
}


