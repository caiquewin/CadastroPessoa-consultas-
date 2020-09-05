using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(20,MinimumLength =2, ErrorMessage ="{0} está acima de 15 Letras")]
        public String Nome { get; set; }

        [Display(Name ="Salário")]//definando o campo de leitura pro user
        [Range(980.00,9999.99, ErrorMessage ="{0} precisa está entre {1} até {2}")]
        [DisplayFormat(DataFormatString ="{0:F2}")]// definindo quantidade de casas decimais
        [Required(ErrorMessage ="{0} Obrigatório")]// definindo que o Salario o campo é obrigatório
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
