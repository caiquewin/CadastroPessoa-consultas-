using SalesWebMvc.Data;
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
    }
}
