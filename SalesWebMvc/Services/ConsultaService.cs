using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ConsultaService
    {
        readonly private SalesWebMvcContext _context;
        public ConsultaService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Consulta>FindAll()
        {
            return _context.Consulta.Include(obj => obj.Especialista).Include(obj =>obj.Cliente).ToList();
        }
        public void Insert(Consulta obj)
        {
            var a = Models.Enums.StatusPagamento.Efetuado;
            obj.StatusPagamento=a;
            _context.Add(obj);
            _context.SaveChanges();
        }
        
    }
}
