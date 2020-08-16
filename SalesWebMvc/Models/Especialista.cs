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
        public string NomeDoutor { get; set; }
        public double Salario { get; set; }
        public Especialidade especialidade { get; set; }
        public Especialista()
        {
        }
        public Especialista(int id,string nomeDoutor,double salario, Especialidade especialidade)
        {
            Id = id;
            NomeDoutor = nomeDoutor;
            Salario = salario;
            this.especialidade = especialidade;
        }
         
    }
}
