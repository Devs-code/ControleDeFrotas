using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
    //Usar X.PageList
    public interface IMarcaRepository
    {
        //Crud
        void Cadastrar(Marca marca);
        void Atualizar(Marca marca);
        void Excluir(int Id);
        Marca ObterMarca(int Id);
        IPagedList<Marca> ObterTodasMarcas(int? pagina, string pesquisa);
        IEnumerable<Marca> ObterTodasMarcas();
    }
}
