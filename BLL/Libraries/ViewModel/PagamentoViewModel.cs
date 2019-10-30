using ControleFrotasDLL.BLL.Libraries.IntermediarioJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFrotasDLL.BLL.Libraries.ViewModel
{
    public class PagamentoViewModel
    {
        public Aluguel Aluguel { get; set; }
        public CartaoCredito CartaoCredito { get; set; }

    }
}
