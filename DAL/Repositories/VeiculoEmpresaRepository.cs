using ControleFrotasDLL.BLL;
using ControleFrotasDLL.BLL.Libraries.Login;
using ControleFrotasDLL.BLL.Libraries.Validacao;
using ControleFrotasDLL.DAL.Database.SQL;
using ControleFrotasDLL.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories
{
   public class VeiculoEmpresaRepository:IVeiculoEmpresaRepository
    {
        private IConfiguration _conf;

        private ControleFrotasContext _banco;

        // private LoginCliente _login;

        public VeiculoEmpresaRepository(ControleFrotasContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;

        }


        public void Atualizar(VeiculoEmpresa veiculoEmpresa, Veiculo veiculo)
        {

            _banco.Update(veiculo);
            _banco.Update(veiculoEmpresa);
            _banco.SaveChanges();
        }

        public void Cadastrar(VeiculoEmpresa veiculoEmpresa, Veiculo veiculo)
        {
            veiculoEmpresa.Status = 1;
            _banco.Add(veiculo);
            // _banco.SaveChanges();
            veiculoEmpresa.VeiculoEmpresaId = veiculo.Id;
            _banco.Add(veiculoEmpresa);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            VeiculoEmpresa veiculo = ObterVeiculoEmpresa(Id);
            _banco.Remove(veiculo);
            _banco.SaveChanges();
        }

        public VeiculoEmpresa ObterVeiculoEmpresa(int Id)
        {
            return _banco.VeiculosEmpresa.Include(a => a.Veiculo).FirstOrDefault(x => x.VeiculoEmpresaId.Equals(Id)); //Include(a => a.Cliente).Include(a => a.Veiculo).Include(a => a.Veiculo.Modelo).FirstOrDefault(x => x.VeiculoClienteId.Equals(Id));
        }

        public IPagedList<VeiculoEmpresa> ObterTodosVeiculosEmpresa(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            var bancoVeiculo = _banco.VeiculosEmpresa.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                //Não Vazio
                bancoVeiculo = bancoVeiculo.Where(a => a.Veiculo.Placa.Contains(pesquisa.Trim()));
            }

            return bancoVeiculo.Include(a => a.Veiculo).Include(a => a.Veiculo.Modelo).ToPagedList(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<VeiculoEmpresa> ObterTodosVeiculosEmpresa()
        {
            return _banco.VeiculosEmpresa.Include(a => a.Veiculo).Where(a => a.Status == 1).ToList();
        }

        public IPagedList<VeiculoEmpresa> ObterTodosVeiculosEmpresaRodizio(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            var bancoVeiculo = _banco.VeiculosEmpresa.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                //Não Vazio
                bancoVeiculo = bancoVeiculo.Where(a => a.Veiculo.Placa.Contains(pesquisa.Trim()));
            }

            Rodizio.Dias();

            return bancoVeiculo.Include(a => a.Veiculo).Include(a => a.Veiculo.Modelo).Where(x => !x.Veiculo.Placa.Substring(x.Veiculo.Placa.Length - 1, 1).Equals(Rodizio.Digito1) && !x.Veiculo.Placa.Substring(x.Veiculo.Placa.Length - 1, 1).Equals(Rodizio.Digito2)).ToPagedList(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<VeiculoEmpresa> ObterTodosVeiculosEmpresaRodizio()
        {
            Rodizio.Dias();
            return _banco.VeiculosEmpresa.Include(a => a.Veiculo).Where(a => a.Status == 1).Where(x => !x.Veiculo.Placa.Substring(x.Veiculo.Placa.Length - 1, 1).Equals(Rodizio.Digito1) && !x.Veiculo.Placa.Substring(x.Veiculo.Placa.Length - 1, 1).Equals(Rodizio.Digito2)).ToList();
        }

        public void BaixaNoVeiculo(int Id)
        {
            var veiculo = ObterVeiculoEmpresa(Id);
            veiculo.Status = 0;
            _banco.SaveChanges();
        }

        public int QuantidadeTotalVeiculosEmpresa()
        {
            return _banco.VeiculosEmpresa.Count();
        }
    }
}
