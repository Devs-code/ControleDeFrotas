using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
   public interface IFaturaAluguelRepository
    {
        void Cadastrar(FaturaAluguel faturaAluguel);
        IEnumerable<FaturaAluguel> ObterTodasFaturasAlugueis();
        IPagedList<FaturaAluguel> ObterTodasFaturasAlugueis(int? pagina);
        decimal ValorTotalAlugueis();
        int QuantidadeTotalBoletoBancario();
        int QuantidadeTotalCartaoCredito();
        int QuantidadeTotalAlugueis();
    }
}
