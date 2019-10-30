using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IModeloRepository
    {
        //Crud
        void Cadastrar(Modelo modelo);
        void Atualizar(Modelo modelo);
        void Excluir(int Id);
        Modelo ObterModelo(int Id);
        IPagedList<Modelo> ObterTodosModelos(int? pagina,string pesquisa);
        IEnumerable<Modelo> ObterTodosModelos();
    }
}
