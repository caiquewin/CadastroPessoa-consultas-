using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Especialista
    {
        public int Id { get; set; }
        public int Cro { get; set; }
        public string CroEstado { get; set; }
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
        public Especialista()
        {
        }

        public Especialista(int id, int cro, string croEstado, string nome, Departamento departamento)
        {
            Id = id;
            Cro = cro;
            CroEstado = croEstado;
            Nome = nome;
            Departamento = departamento;
        }
        public double TotalConsulta(DateTime inicial, DateTime final)
        {
            return Consultas.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(item => item.Id);
        }

    }
}
