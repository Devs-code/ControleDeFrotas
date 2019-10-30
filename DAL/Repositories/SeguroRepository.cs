using ControleFrotasDLL.BLL;
using ControleFrotasDLL.DAL.Database.SQL;
using ControleFrotasDLL.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories
{
   public class SeguroRepository:ISeguroRepository
    {
        private IConfiguration _conf;

        private ControleFrotasContext _banco;

        public SeguroRepository(ControleFrotasContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }


        public void Atualizar(Seguro seguro)
        {
            _banco.Update(seguro);
            _banco.SaveChanges();
        }

        public void Cadastrar(Seguro seguro)
        {
            _banco.Add(seguro);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Seguro seguro = ObterSeguro(Id);
            _banco.Remove(seguro);
            _banco.SaveChanges();
        }

        public Seguro ObterSeguro(int Id)
        {
            return _banco.Seguros.Find(Id);
        }

        public IPagedList<Seguro> ObterTodosSeguros(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            var bancoSeguro = _banco.Seguros.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                //Não Vazio
                bancoSeguro = bancoSeguro.Where(a => a.Nome.Contains(pesquisa.Trim()));
            }

            return bancoSeguro.Include(a => a.Fornecedor).ToPagedList<Seguro>(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<Seguro> ObterTodosSeguros()
        {
            return _banco.Seguros.Include(a=>a.Fornecedor);
        }
    }
}