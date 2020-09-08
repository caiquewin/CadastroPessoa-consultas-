using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMvcContext _contex;
        public DepartamentoService(SalesWebMvcContext context)
        {
            _contex = context;
        }
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _contex.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
