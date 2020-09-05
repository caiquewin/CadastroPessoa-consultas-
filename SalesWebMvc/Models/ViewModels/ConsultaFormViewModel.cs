using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class ConsultaFormViewModel
    {
        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Especialista> Especialista{ get; set; }
        public Consulta Consulta { get; set; }

    }
}
