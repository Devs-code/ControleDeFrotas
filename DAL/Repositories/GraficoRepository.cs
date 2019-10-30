using ControleFrotasDLL.BLL;
using ControleFrotasDLL.BLL.Libraries.Login;
using ControleFrotasDLL.DAL.Database.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFrotasDLL.DAL.Repositories
{
   public class GraficoRepository
    {

        private ControleFrotasContext _banco;
        private LoginCliente _login;

        public GraficoRepository(ControleFrotasContext banco, LoginCliente login)
        {
            _banco = banco;
            _login = login;
        }
        
    }
}
