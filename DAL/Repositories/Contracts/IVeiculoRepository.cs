using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IVeiculoRepository
    {
        //Crud
        void Cadastrar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Excluir(int Id);
        Veiculo ObterVeiculo(int Id);
        IPagedList<Veiculo> ObterTodosVeiculos(int? pagina);
        IEnumerable<Veiculo> ObterTodosVeiculos();
    }
}
