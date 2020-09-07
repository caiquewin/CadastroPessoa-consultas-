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
        public List<Cliente>FindAll()//operação sicrona
        {
            return _context.Cliente.ToList();

        }
        public Cliente FindById(int id)
        {
            return _context.Cliente.FirstOrDefault(obj => obj.Id == id);
        }
        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
