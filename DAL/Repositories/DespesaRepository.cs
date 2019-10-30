using ControleFrotasDLL.BLL;
using ControleFrotasDLL.BLL.Libraries.Login;
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
   public class DespesaRepository:IDespesaRepository
    {
        private IConfiguration _conf;

        private ControleFrotasContext _banco;

        private LoginCliente _login;

        public DespesaRepository(ControleFrotasContext banco, IConfiguration configuration, LoginCliente loginCliente)
        {
            _banco = banco;
            _conf = configuration;
            _login = loginCliente;
        }


        public void Atualizar(Despesa despesa)
        {
            _banco.Update(despesa);
            _banco.SaveChanges();
        }

        public void Cadastrar(Despesa despesa)
        {
       
            _banco.Add(despesa);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Despesa despesa = ObterDespesa(Id);
            _banco.Remove(despesa);
            _banco.SaveChanges();
        }

        public Despesa ObterDespesa(int Id)
        {
            return _banco.Despesas.Find(Id); //Include(a => a.Cliente).Include(a => a.Veiculo).Include(a => a.Veiculo.Modelo).FirstOrDefault(x => x.VeiculoClienteId.Equals(Id));
        }

        public IPagedList<Despesa> ObterTodasDespesas(int? pagina)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;

            return (_login.Tipo() == null) ? _banco.Despesas.Include(a=>a.UnidadeMedida).Include(a => a.Cliente).ToPagedList(numeroPagina, RegistroPorPagina) :
                _banco.Despesas.Include(a=>a.UnidadeMedida).Include(a => a.Cliente).Where(a => _login.Tipo().Equals(a.DespesaClienteId)).ToPagedList(numeroPagina, RegistroPorPagina);
        }

        public IEnumerable<Despesa> ObterTodasDespesas()
        {
            return _banco.Despesas.ToList();
        }
     
    }
}
