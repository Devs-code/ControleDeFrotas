using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IDespesaRepository
    {
        //Crud
        void Cadastrar(Despesa despesa);
        void Atualizar(Despesa despesa);
        void Excluir(int Id);
        Despesa ObterDespesa(int Id);
        IPagedList<Despesa> ObterTodasDespesas(int? pagina);
        IEnumerable<Despesa> ObterTodasDespesas();
    }
}
