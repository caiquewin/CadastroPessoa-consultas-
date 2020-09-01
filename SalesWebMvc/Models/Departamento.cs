using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public double Salario { get; set; }
        public ICollection<Especialista>Especialistas{ get; set; }= new List<Especialista>();
        public Departamento()
        {

        }

        public Departamento(int id, string nome, double salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }
        public void AddEspecialista(Especialista esp)
        {
            Especialistas.Add(esp);
        }
        public void RemEspecialista(Especialista esp)
        {
            Especialistas.Remove(esp);
        }
        public double TotalEspecialista(DateTime inicial,DateTime final)
        {
            return Especialistas.Sum(esp => esp.TotalConsulta(inicial, final));
        }
    }
}
