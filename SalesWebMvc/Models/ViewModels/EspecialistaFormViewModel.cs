using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class EspecialistaFormViewModel
    {
        public Especialista Especialista { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
    }
}
