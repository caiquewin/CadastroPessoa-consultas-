using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
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

        public async Task<List<Consulta>> FindAllAsync()
        {
            return await _context.Consulta.Include(obj => obj.Especialista).Include(obj => obj.Cliente).ToListAsync();
        }
        public async Task InsertAsync(Consulta obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int Id)
        {
            var obj = await _context.Consulta.FindAsync(Id);
            _context.Consulta.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Consulta> FindByIdAsync(int id)
        {
            return await _context.Consulta.Include(obj => obj.Cliente).Include(obj => obj.Especialista).FirstOrDefaultAsync(obj => obj.Cliente.Id == id);
        }
        public async Task UpdateAsync(Consulta obj)
        {
            bool hasAny = await _context.Consulta.AnyAsync(x => x.Id == obj.Id);// verificando se tem algum usuário com esse id no bd
            if (!hasAny)
            {
                throw new NotFoundException("Usuario não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
