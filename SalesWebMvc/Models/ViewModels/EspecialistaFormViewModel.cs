using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class EspecialistaFormViewModel
    {
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        public Especialista Especialista { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
    }
}
