using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces.Repositories
{
    public interface IPostagemRepository // : IRepositoryBase<Postagem>
    {
        void Add(Postagem obj);

        Postagem GetById(string id);

        IEnumerable<Postagem> GetAll();


    }
}
