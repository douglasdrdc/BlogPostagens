using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Services
{
    public class PostagemService : ServiceBase<Postagem>, IPostagemService
    {
        public readonly IPostagemRepository _postagemRepository;

        public PostagemService(IPostagemRepository postagemRepository)
            : base(postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public void IsValid(Postagem obj)
        {
            obj.IsValid();
        }
    }
}
