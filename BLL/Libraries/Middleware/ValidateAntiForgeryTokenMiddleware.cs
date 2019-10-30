using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFrotasDLL.BLL.Libraries.Middleware
{
    /*
     * Classe para validação de requisição do método post
     */
        public class ValidateAntiForgeryTokenMiddleware
        {
            private RequestDelegate _next;
            private IAntiforgery _antiforgery;

            public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
            {
                _next = next;
                _antiforgery = antiforgery;
            }

            public async Task Invoke(HttpContext context)
            {

                if (HttpMethods.IsPost(context.Request.Method))
                {
                    await _antiforgery.ValidateRequestAsync(context);
                }

                await _next(context);
            }


        }
    }