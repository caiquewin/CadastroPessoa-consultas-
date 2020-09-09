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

        [Display(Name = "Número Do Cro")]//Nome Exibido pro usuário
        [Required(ErrorMessage ="{0} Obrigatório")]
        [Range(1,99999,ErrorMessage ="{0} O Cro precisa esta entre {1} eté {2}")]
        public int Cro { get; set; }

        [Display(Name = "Estado do Cro")]
        [StringLength(2,MinimumLength =2,ErrorMessage ="{0} Coloque o estado que foi retirado seu Cro")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        public string CroEstado { get; set; }
        [Display(Name ="Nome do Doutor")]
        [Required(ErrorMessage = "{0} Obrigatório")]
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        [Display(Name ="Especialidade")]
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
