using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IUnidMedRepository
    {
        void Cadastrar(UnidadeMedida medida);
        void Atualizar(UnidadeMedida medida);
        void Excluir(int Id);
        UnidadeMedida ObterUnidMed(int Id);
        IPagedList<UnidadeMedida> ObterTodasUnidMeds(int? pagina, string pesquisa);
        IEnumerable<UnidadeMedida> ObterTodasUnidMeds();
    }
}
