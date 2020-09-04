using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Data de Nascimento")]
        public DateTime DataNasci { get; set; }
        [Display (Name ="Telefone")]
        public int NumeCel { get; set; }
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
        public Cliente()
        {

        }

        public Cliente(int id, string nome, DateTime dataNasci, int numeCel)
        {
            Id = id;
            Nome = nome;
            DataNasci = dataNasci;
            NumeCel = numeCel;
        }

        public void AddConsulta(Consulta consulta)// adicionar consulta
        {
            Consultas.Add(consulta);
        }
        public void RemovConsulta(Consulta consulta)// remover consulta
        {
            Consultas.Remove(consulta);
        }
        public double TotalConsulta()
        {
           return  Consultas.Sum(item => item.Id);
        }
    }
}
