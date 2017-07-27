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
                
        public IEnumerable<Postagem> Get()
        {
            try
            {
                IEnumerable<Postagem> postagemCollection = this._postagemApp.GetAll();
                return postagemCollection;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no processo de consulta.", ex);
            }            
        }
                
        public Postagem Get(string id)
        {
            try
            {
                Postagem postagem = this._postagemApp.GetById(id);
                return postagem;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no processo de consulta.", ex);
            }            
        }
                
        public Postagem Post([FromUri] Postagem value)
        {
            try
            {
                if (value == null)
                    throw new Exception("Parâmetro de entrada inválido nulo.");

                this._postagemApp.IsValid(value);
                this._postagemApp.Add(value);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public HttpResponseMessage Put([FromUri] Postagem value)
        {
            try
            {
                this._postagemApp.IsValid(value);
                this._postagemApp.Update(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
                
        public void Delete(int id)
        {
        }
    }
}
