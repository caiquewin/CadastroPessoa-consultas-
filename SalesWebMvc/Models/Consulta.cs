using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
        public string Comentario { get; set; }
        public Especialista Especialista{ get; set; }
        public Cliente Cliente { get; set; }
        public Consulta()
        {

        }

        public Consulta(int id, DateTime data, StatusPagamento statusPagamento, string comentario, Especialista especialista, Cliente cliente)
        {
            Id = id;
            Data = data;
            StatusPagamento = statusPagamento;
            Comentario = comentario;
            Especialista = especialista;
            Cliente = cliente;
        }
    }
}
