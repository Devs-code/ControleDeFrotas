using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IVeiculoClienteRepository
    {
        //Crud
        void Cadastrar(VeiculoCliente veiculoCliente, Veiculo veiculo);
        void Atualizar(VeiculoCliente veiculoCliente, Veiculo veiculo);
        void Excluir(int Id);
        VeiculoCliente ObterVeiculoCliente(int Id);
        IPagedList<VeiculoCliente> ObterTodosVeiculosCliente(int? pagina, string pesquisa);
        IEnumerable<VeiculoCliente> ObterTodosVeiculosCliente();
        int QuantidadeTotalVeiculosCliente();
    }
}
