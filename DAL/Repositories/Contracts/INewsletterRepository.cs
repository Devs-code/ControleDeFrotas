using ControleFrotasDLL.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFrotasDLL.DAL.Repositories.Contracts
{
        public interface INewsletterRepository
        {
            void Cadastrar(NewsletterEmail newsletterEmail);

            IEnumerable<NewsletterEmail> ObterTodasNewsletter();

            int QuantidadeTotalNewsletters();
        }
    }
