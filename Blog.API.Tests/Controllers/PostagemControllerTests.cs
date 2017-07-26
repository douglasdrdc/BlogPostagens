﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Blog.API.Controllers;
using Blog.Domain.Entities;
using Blog.Application.Interface;


namespace Blog.API.Controllers.Tests
{
    [TestClass()]
    public class PostagemControllerTests
    {
        private PostagemController _controller;
        private Postagem _postagem;

        [TestInitialize()]
        public void Initialize()
        {
            var repository = new Blog.Infra.Data.Mongo.Repositories.PostagemRepository();
            var service = new Domain.Services.PostagemService(repository);
            var application = new Application.PostagemAppService(service);
            _controller = new PostagemController(application);

            _postagem = new Postagem()
            {
                Titulo = "Teste Título Postagem",
                Subtitulo = "Teste Subtitulo Postagem",
                Texto = "Teste Texto Postagem",
                DataCadastro = DateTime.Now.Date
            };
        }

        #region Post

        [TestMethod()]
        public void PermitirInclusaoDeNovaPostagemValida()
        {
            try
            {
                _postagem = _controller.Post(_postagem);
                var postagemGet = _controller.Get(_postagem.PostagemId.ToString());
                Assert.AreEqual(_postagem.PostagemId, postagemGet.PostagemId);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Era esperado a inclusão com sucesso porem ocorreu uma Exception. {0}", ex.Message));
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemNula()
        {
            try
            {
                _controller.Post(null);
                Assert.Fail("Era esperado uma exceção referente a entrada inválido nulo.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Parâmetro de entrada inválido nulo.", ex.Message);
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemSemTitulo()
        {
            try
            {                
                _postagem.Titulo = string.Empty;
                _controller.Post(_postagem);
                Assert.Fail("Era esperado uma exceção referente ao título não informado.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Título não informado", ex.Message);
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemSemSubtitulo()
        {
            try
            {                
                _postagem.Subtitulo = string.Empty;
                _controller.Post(_postagem);
                Assert.Fail("Era esperado uma exceção referente ao Subtítulo não informado.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Subtítulo não informado", ex.Message);
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemSemTexto()
        {
            try
            {   
                _postagem.Texto = string.Empty;
                _controller.Post(_postagem);
                Assert.Fail("Era esperado uma exceção referente ao Texto não informado.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Texto não informado", ex.Message);
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemSemDataCadastro()
        {
            try
            {
                _postagem.DataCadastro = DateTime.MinValue;
                _controller.Post(_postagem);
                Assert.Fail("Era esperado uma exceção referente a Data de Cadastro não informada.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Data de Cadastro não informada", ex.Message);
            }
        }

        [TestMethod()]
        public void NaoPermitirInclusaoDeNovaPostagemComDataCadastroMenorQueDataSistema()
        {
            try
            {
                _postagem.DataCadastro = DateTime.Now.AddDays(-2);
                _controller.Post(_postagem);
                Assert.Fail("Era esperado uma exceção referente a Data de Cadastro inválida.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Data de Cadastro inválida. Não é permitido informar uma data menor que a data do sistema.", ex.Message);
            }
        }

        #endregion
        
    }
}