using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IRegistroRepository
    {
        void Cadastrar(RegistroDespesa registro);
        List<RegistroDespesa> ObterTodosRegistros();
        IPagedList<RegistroDespesa> ObterTodosRegistros(int? pagina);
        decimal ValorTotalRegistros();
    }
}
