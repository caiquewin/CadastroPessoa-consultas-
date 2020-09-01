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
        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
