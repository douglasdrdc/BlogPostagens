using Blog.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.Application.Interface;
using Blog.Domain.Entities;

namespace Blog.API.Controllers
{
    [RoutePrefix("api/postagem")]
    public class PostagemController : ApiController
    {
        private readonly IPostagemAppService _postagemApp;

        public PostagemController(IPostagemAppService postagemApp)
        {
            this._postagemApp = postagemApp;
        }

        // GET: api/Postagem
        public IEnumerable<Postagem> Get()
        {
            IEnumerable<Postagem> postagemCollection = this._postagemApp.GetAll();            
            return postagemCollection;
        }

        // GET: api/Postagem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Postagem
        public HttpResponseMessage Post([FromUri] Postagem value)
        {
            try
            {
                value.DataCadastro = DateTime.Now.AddDays(-3);
                value.Titulo = "Concurso Público";
                value.Subtitulo = "Foi realizada a abertura das vendas destes ingressos";
                value.Texto = "É um fato conhecido ...";

                this._postagemApp.Add(value);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Postagem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Postagem/5
        public void Delete(int id)
        {
        }
    }
}
