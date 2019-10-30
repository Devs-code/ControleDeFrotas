using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ControleFrotasDLL.BLL.Libraries.ViewModel
{
    public class PrincipalViewModel
    {
        public NewsletterEmail newsletterEmail { get; set; }

        public IEnumerable<VeiculoEmpresa> veiculoEmpresas { get; set; }
    }
}