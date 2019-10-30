using ControleFrotasDLL.BLL;
using ControleFrotasDLL.DAL.Database.SQL;
using ControleFrotasDLL.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private IConfiguration _conf;

        private ControleFrotasContext _banco;

        public MarcaRepository(ControleFrotasContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }


        public void Atualizar(Marca marca)
        {
            _banco.Update(marca);
            _banco.SaveChanges();
        }

        public void Cadastrar(Marca marca)
        {
            _banco.Add(marca);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Marca marca = ObterMarca(Id);
            _banco.Remove(marca);
            _banco.SaveChanges();
        }

        public Marca ObterMarca(int Id)
        {
            return _banco.Marcas.Find(Id);
        }

        public IPagedList<Marca> ObterTodasMarcas(int? pagina,string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            var bancoMarca = _banco.Marcas.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                //Não Vazio
                bancoMarca = bancoMarca.Where(a => a.Nome.Contains(pesquisa.Trim()));
            }

            return bancoMarca.ToPagedList<Marca>(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<Marca> ObterTodasMarcas()
        {
            return _banco.Marcas;
        }
    }
}
