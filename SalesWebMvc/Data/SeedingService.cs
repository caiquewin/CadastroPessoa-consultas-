using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()//opração pra popular nossa table
        {
        if (_context.Especialista.Any() ||_context.Cliente.Any()|| _context.Consulta.Any() )
           //esse if vai verificar se tem algum dado no banco de dados(nas tables)
            {
                return;// 
            }
            Cliente c1 = new Cliente(1, "Fátima Juliana Pereira", new DateTime(1980, 02, 24), 986569882);
            Cliente c2 = new Cliente(2, "Caleb Luan Carlos Eduardo Carvalho", new DateTime(1998, 06, 09), 925734318);
            Cliente c3 = new Cliente(3, "Raimundo Jorge Gael Assunção", new DateTime(1985, 09, 12), 986569882);
            Cliente c4 = new Cliente(4, "Cristiane Gabrielly Débora Pereira", new DateTime(1981, 05, 12), 991858647);
            Cliente c5 = new Cliente(5, "Fátima Juliana Pereira", new DateTime(1999, 12, 24), 986569882);

            Especialista ep1 = new Especialista(1, "Gulacido",150, Especialidade.Ortodontia);
            Especialista ep2 = new Especialista(2, "Curuki", 175, Especialidade.Protese);
            Especialista ep3 = new Especialista(3, "Nepun", 200, Especialidade.Implante);

            

            Consulta cn1 = new Consulta(1, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep1,c1);
            Consulta cn2 = new Consulta(2, new DateTime(2020, 08, 25, 11, 00, 00), StatusPagamento.Analise, "", ep1,c2);
            Consulta cn3 = new Consulta(3, new DateTime(2020, 08, 25, 13, 00, 00), StatusPagamento.Analise, "", ep1,c3);
            Consulta cn4 = new Consulta(4, new DateTime(2020, 08, 25, 14, 00, 00), StatusPagamento.Analise, "", ep1,c4);
            Consulta cn5 = new Consulta(5, new DateTime(2020, 08, 25, 15, 00, 00), StatusPagamento.Analise, "", ep1,c5);

            Consulta cn6 = new Consulta(6, new DateTime(2020, 09, 25, 10, 00, 00), StatusPagamento.Analise, "", ep1,c1);
            Consulta cn7 = new Consulta(7, new DateTime(2020, 09, 25, 11, 00, 00), StatusPagamento.Analise, "", ep1,c2);
            Consulta cn8 = new Consulta(8, new DateTime(2020, 09, 25, 13, 00, 00), StatusPagamento.Analise, "", ep2,c3);
            Consulta cn9 = new Consulta(9, new DateTime(2020, 09, 25, 14, 00, 00), StatusPagamento.Analise, "", ep2,c4);
            Consulta cn10 = new Consulta(10, new DateTime(2020, 09, 25, 10, 00, 00), StatusPagamento.Analise, "", ep2,c5);

            Consulta cn11 = new Consulta(11, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep3,c1);
            Consulta cn12 = new Consulta(12, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep3,c2);
            Consulta cn13 = new Consulta(13, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep3,c3);
            Consulta cn14 = new Consulta(14, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep3,c4);
            Consulta cn15 = new Consulta(15, new DateTime(2020, 08, 25, 10, 00, 00), StatusPagamento.Analise, "", ep3,c5);

            _context.Cliente.AddRange(c1,c2,c3,c4,c5);
            _context.Especialista.AddRange(ep1, ep2, ep3);
            _context.Consulta.AddRange(cn1, cn2, cn3, cn4, cn5, cn6, cn7, cn8, cn9, cn10, cn11, cn12, cn13, cn14, cn15);
            _context.SaveChanges();
        }
    }
}

