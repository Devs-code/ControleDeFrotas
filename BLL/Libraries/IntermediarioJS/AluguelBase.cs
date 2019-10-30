using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFrotasDLL.BLL.Libraries.IntermediarioJS
{
   public class AluguelBase
    {
        
        public string DataInicio { get; set; }

       
        public string DataPrevista { get; set; }

       
        public double ValorPrevisto { get; set; }

      
        public string Seguro { get; set; }

        
        public int? AluguelVeiculoId { get; set; }

        public int? AluguelClienteId { get; set; }

    }
}
