using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IClienteJuridicoRepository
    {
        void Cadastrar(ClienteJuridico clienteJuridico, Cliente cliente);
        //void AtualizarSenha(ClienteJuridico clienteJuridico, Cliente cliente);
        void Atualizar(ClienteJuridico clienteJuridico, Cliente cliente);
        void Excluir(int Id);
        ClienteJuridico ObterClienteJuridico(int Id);
        IEnumerable<ClienteJuridico> ObterTodosClientesJuridicos();
        IPagedList<ClienteJuridico> ObterTodosClientesJuridicos(int? pagina, string pesquisa);
    }
}