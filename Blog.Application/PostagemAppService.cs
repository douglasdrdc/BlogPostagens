using Blog.Application.Interface;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class PostagemAppService : AppServiceBase<Postagem>, IPostagemAppService
    {
        private readonly IPostagemService _postagemService;

        public PostagemAppService(IPostagemService postagemService)
            : base(postagemService)
        {
            _postagemService = postagemService;
        }

        public void IsValid(Postagem obj)
        {
            _postagemService.IsValid(obj);
        }
    }
}
