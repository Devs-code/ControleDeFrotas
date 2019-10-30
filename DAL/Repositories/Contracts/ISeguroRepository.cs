using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    public interface ISeguroRepository
    {
        void Cadastrar(Seguro seguro);
        void Atualizar(Seguro seguro);
        void Excluir(int Id);
        Seguro ObterSeguro(int Id);
        IPagedList<Seguro> ObterTodosSeguros(int? pagina, string pesquisa);
        IEnumerable<Seguro> ObterTodosSeguros();
    }
}