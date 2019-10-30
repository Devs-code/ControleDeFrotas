using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IMotoristaRepository
    {
        void Cadastrar(Motorista motorista,Cliente cliente);
       
        void Atualizar(Motorista motorista, Cliente cliente);
        void Excluir(int Id);
        Motorista ObterMotorista(int Id); 
        IEnumerable<Motorista> ObterTodosMotoristas();
        IPagedList<Motorista> ObterTodosMotoristas(int? pagina,string pesquisa);
        int QuantidadeTotalMotoristas();
    }
}
