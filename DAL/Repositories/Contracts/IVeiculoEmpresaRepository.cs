using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IVeiculoEmpresaRepository
    {
        //Crud
        void Cadastrar(VeiculoEmpresa veiculoEmpresa, Veiculo veiculo);
        void Atualizar(VeiculoEmpresa veiculoEmpresa, Veiculo veiculo);
        void Excluir(int Id);
        VeiculoEmpresa ObterVeiculoEmpresa(int Id);
        IPagedList<VeiculoEmpresa> ObterTodosVeiculosEmpresa(int? pagina, string pesquisa);
        IEnumerable<VeiculoEmpresa> ObterTodosVeiculosEmpresa();
        IPagedList<VeiculoEmpresa> ObterTodosVeiculosEmpresaRodizio(int? pagina, string pesquisa);
        IEnumerable<VeiculoEmpresa> ObterTodosVeiculosEmpresaRodizio();
        void BaixaNoVeiculo(int id);
        int QuantidadeTotalVeiculosEmpresa();
    }
}
