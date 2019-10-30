using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface IClienteFisicoRepository
    {
        void Cadastrar(ClienteFisico clienteFisico, Cliente cliente);
        //void AtualizarSenha(ClienteFisico clienteFisico, Cliente cliente);
        void Atualizar(ClienteFisico clienteFisico, Cliente cliente);
        void Excluir(int Id);
        ClienteFisico ObterClienteFisico(int Id);
        IEnumerable<ClienteFisico> ObterTodosClientesFisicos();
        IPagedList<ClienteFisico> ObterTodosClientesFisicos(int? pagina, string pesquisa);
    }
}