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

        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<Postagem> postagemCollection = this._postagemApp.GetAll();
                if (postagemCollection == null)
                    throw new KeyNotFoundException();

                return Request.CreateResponse(HttpStatusCode.OK, postagemCollection);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = "Não foi encontrado itens na consulta";
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
        public HttpResponseMessage Get(string id)
        {
            try
            {
                Postagem postagem = this._postagemApp.GetById(id);
                if (postagem == null)
                    throw new KeyNotFoundException();

                return Request.CreateResponse(HttpStatusCode.OK, postagem);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("O item {0} não foi encontrado.", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
            catch (Exception ex)
            {   
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
                
        public HttpResponseMessage Post([FromBody] Postagem postagem)
        {
            HttpResponseMessage response = null;
            try
            {
                if (postagem == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                this._postagemApp.IsValid(postagem);
                this._postagemApp.Add(postagem);
                
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
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
                
        public void Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                var postagem = this._postagemApp.GetById(id);
                if (postagem == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                this._postagemApp.Remove(postagem);
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }


    }
}
