using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFrotasDLL.BLL;
using ControleFrotasDLL.BLL.Libraries.IntermediarioJS;
using ControleFrotasDLL.BLL.Libraries.Login;
using ControleFrotasDLL.DAL.Database.SQL;
using ControleFrotasDLL.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using X.PagedList;

namespace ControleFrotasDLL.DAL.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {

        private ControleFrotasContext _banco;
        private IConfiguration _conf;
        private LoginCliente _login;

        public RegistroRepository(ControleFrotasContext banco, IConfiguration configuration, LoginCliente loginCliente)
        {
            _banco = banco;
            _conf = configuration;
            _login = loginCliente;
        }

        public void Cadastrar(RegistroDespesa registro)
        {
            _banco.Add(registro);
            _banco.SaveChanges();
            ItemsRegistro items;

            var lista_itens = JsonConvert.DeserializeObject<List<ItemsRegistroJS>>(registro.ListaProdutos);
            for (int i = 0; i < lista_itens.Count; i++)
            {
                items = new ItemsRegistro
                {
                    RegistroId = registro.Id,
                    DespesaId = int.Parse(lista_itens[i].CodigoItem.ToString()),
                    PrecoUnitario = double.Parse(lista_itens[i].PrecoUnitario.ToString().Replace(",", ".")),
                    QuantidadeItem = double.Parse(lista_itens[i].QuantidadeItem.ToString()),

                };
                _banco.Add(items);
                _banco.SaveChanges();
            }
        }

        public IPagedList<RegistroDespesa> ObterTodosRegistros(int? pagina)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;
            return (_login.Tipo() == null) ? _banco.RegistrosDespesas.Include(a => a.Cliente).Include(a=>a.Motorista.Cliente).Include(a => a.VeiculoCliente).Include(a=>a.VeiculoCliente.Veiculo).ToPagedList<RegistroDespesa>(numeroPagina, RegistroPorPagina) :
                _banco.RegistrosDespesas.Include(a => a.Cliente).Include(a=>a.Motorista.Cliente).Include(a => a.VeiculoCliente).Include(a => a.VeiculoCliente.Veiculo).Where(a=>_login.Tipo()==a.RegistroClienteId).ToPagedList<RegistroDespesa>(numeroPagina, RegistroPorPagina);
        }

        public List<RegistroDespesa> ObterTodosRegistros()
        {
            return _banco.RegistrosDespesas.ToList();
        }

        public decimal ValorTotalRegistros()
        {
            return (_login.Tipo() == null) ? _banco.RegistrosDespesas.Sum(a => Convert.ToDecimal(a.Total)) : _banco.RegistrosDespesas.Where(a => a.RegistroClienteId == _login.Tipo()).Sum(a => Convert.ToDecimal(a.Total));
        }
    }
}
