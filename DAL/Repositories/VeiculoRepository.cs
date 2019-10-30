using ControleFrotasDLL.BLL;
using ControleFrotasDLL.DAL.Database.SQL;
using ControleFrotasDLL.DAL.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories
{
   
        public class VeiculoRepository: IVeiculoRepository
        {
            private IConfiguration _conf;

            private ControleFrotasContext _banco;

            public VeiculoRepository(ControleFrotasContext banco, IConfiguration configuration)
            {
                _banco = banco;
                _conf = configuration;
            }


            public void Atualizar(Veiculo veiculo)
            {
                _banco.Update(veiculo);
                _banco.SaveChanges();
            }

            public void Cadastrar(Veiculo marca)
            {
                _banco.Add(marca);
                _banco.SaveChanges();
            }

            public void Excluir(int Id)
            {
                Veiculo marca = ObterVeiculo(Id);
                _banco.Remove(marca);
                _banco.SaveChanges();
            }

            public Veiculo ObterVeiculo(int Id)
            {
                return _banco.Veiculos.Find(Id);
            }

            public IPagedList<Veiculo> ObterTodosVeiculos(int? pagina)
            {
                int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
                int numeroPagina = pagina ?? 1;
            return _banco.Veiculos.ToPagedList(numeroPagina, RegistroPorPagina);
            }

            public IEnumerable<Veiculo> ObterTodosVeiculos()
            {
            return _banco.Veiculos.ToList();
            }
        }
}
