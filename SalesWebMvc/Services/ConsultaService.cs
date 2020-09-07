using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class ConsultaService
    {
        readonly private SalesWebMvcContext _context;
        public ConsultaService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Consulta> FindAll()
        {
            return _context.Consulta.Include(obj => obj.Especialista).Include(obj => obj.Cliente).ToList();
        }
        public void Insert(Consulta obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Remove(int Id)
        {
            var obj = _context.Consulta.Find(Id);
            _context.Consulta.Remove(obj);
            _context.SaveChanges();
        }
        public Consulta FindById(int id )
        {
            return _context.Consulta.Include(obj => obj.Cliente).Include(obj => obj.Especialista).FirstOrDefault(obj => obj.Cliente.Id == id);
        }
        public void Update(Consulta obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
