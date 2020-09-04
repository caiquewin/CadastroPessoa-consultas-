using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Especialista
    {
        public int Id { get; set; }

        [Display(Name = "Numero Do Cro")]//Nome Exibido pro usuário
        public int Cro { get; set; }
        [Display(Name = "Estado do Cro")]
        public string CroEstado { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Especialidade")]
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
