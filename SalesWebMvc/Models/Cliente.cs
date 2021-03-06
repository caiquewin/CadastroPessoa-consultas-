﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name ="Nome do Cliente")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        public string Nome { get; set; }

        [Display(Name ="Data de Nascimento")]//descrição
        [DataType(DataType.Date)]//tipoe
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]//formato de exibição
        public DateTime DataNasci { get; set; }     
        [Display(Name ="Número de contato")]
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
