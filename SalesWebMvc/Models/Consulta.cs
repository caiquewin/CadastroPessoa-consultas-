using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        [Display(Name ="Data e Hora")]
        public DateTime Data { get; set; }
        [Display(Name ="Status do Pagamento")]
        public StatusPagamento StatusPagamento { get; set; }
        public string Comentario { get; set; }
        [Display(Name ="Doutor")]
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
