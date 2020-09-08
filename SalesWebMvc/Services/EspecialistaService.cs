using Microsoft.AspNetCore.Mvc;
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
    public class EspecialistaService
    {
        private readonly SalesWebMvcContext _contex;
        bool veri=false;
        public EspecialistaService(SalesWebMvcContext context)
        {
            _contex = context;
        }
        public async Task<List<Especialista>> FindAllAsync()//operação sincrona 
        {
            return await _contex.Especialista.Include(obj =>obj.Departamento).ToListAsync();
        }

       public async Task InsertAsync(Especialista obj)//adiciona um novo Especialista do Create.cshtml dela envia pra esse metodo e vai pro BD
        {
            _contex.Add(obj);
           await _contex.SaveChangesAsync();
        }
        public async Task<Especialista> FindByIdAsync(int Id)
        {
            return await _contex.Especialista.Include(obj =>obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == Id);
        }
        public async Task RemoveAsync(int Id)
        {
            bool veri = await _contex.Consulta.AnyAsync(obj => obj.Especialista.Id == Id);//se for verdadeira não vai possivel fazer o try
            if (!veri)
            {
                try
                {
                    var obj = await _contex.Especialista.FindAsync(Id);
                    _contex.Especialista.Remove(obj);
                    await _contex.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw new IntergrityException(e.Message);
                }
            }
        }
       
        public async Task UpdateAsync(Especialista obj)
        {
            bool hasAny = await _contex.Especialista.AnyAsync(x => x.Id == obj.Id);// verificando se tem algum usuário com esse id no bd
            if (!hasAny)
            {
                throw new NotFoundException("Usuario não encontrado");
            }
            try
            {
                _contex.Update(obj);
               await _contex.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
            
        }
        
    }
}
