using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class ClienteService
    {
        private readonly SalesWebMvcContext _context;
        public ClienteService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> FindAllAsync()//operação sicrona
        {
            return await _context.Cliente.ToListAsync();

        }
        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task InsertAsync(Cliente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
