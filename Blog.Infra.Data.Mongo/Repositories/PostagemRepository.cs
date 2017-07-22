using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Mongo.Repositories
{
    public class PostagemRepository : RepositoryBase<Postagem>, IPostagemRepository
    {
        
    }
}
