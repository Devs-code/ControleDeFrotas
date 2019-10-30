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
    public class ModeloRepository : IModeloRepository
    {
        private ControleFrotasContext _banco;
        private IConfiguration _conf;

        public ModeloRepository(ControleFrotasContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }


        public void Atualizar(Modelo modelo)
        {
            _banco.Update(modelo);
            _banco.SaveChanges();
        }

        public void Cadastrar(Modelo modelo)
        {
            _banco.Add(modelo);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Modelo modelo = ObterModelo(Id);
            _banco.Remove(modelo);
            _banco.SaveChanges();
        }

        public Modelo ObterModelo(int Id)
        {
            return _banco.Modelos.Find(Id);
        }

        public IPagedList<Modelo> ObterTodosModelos(int? pagina,string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            var bancoModelo = _banco.Modelos.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                //Não Vazio
                bancoModelo = bancoModelo.Where(a => a.Nome.Contains(pesquisa.Trim()));
            }

            return bancoModelo.Include(a => a.Marca).ToPagedList<Modelo>(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<Modelo> ObterTodosModelos()
        {
            return _banco.Modelos.ToList();
        }

    }
}
