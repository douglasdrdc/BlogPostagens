using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using Blog.Infra.Data.Mongo.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Mongo.Repositories
{
    //public class PostagemRepository : RepositoryBase<Postagem>, IPostagemRepository
    public class PostagemRepository : IPostagemRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<PostagemData> _collection;

        public PostagemRepository()
        {
            _client = new MongoClient(Util.Util.MongoClientConnection);
            _database = _client.GetDatabase(Util.Util.MongoDataBase);
            _collection = _database.GetCollection<PostagemData>("Postagem");
        }

        public void Add(Postagem model)
        {
            PostagemData objData = ConvertModelToData(model);
            _collection.InsertOne(objData);
        }

        public IEnumerable<Postagem> GetAll()
        {
            List<Postagem> postagemCollection = new List<Postagem>();

            IEnumerable<PostagemData> postagemDataCollection = _collection.Find(new BsonDocument()).ToList<PostagemData>();
            if (postagemDataCollection != null && postagemDataCollection.Count() > 0)
            {
                foreach (PostagemData item in postagemDataCollection)
                {
                    postagemCollection.Add(ConvertDataToModel(item));
                }
            }

            return postagemCollection;
        }

        public Postagem GetById(string id)
        {
            Postagem postagem = new Postagem();

            var filter = Builders<PostagemData>.Filter.Eq("_id", ObjectId.Parse(id));
            PostagemData postagemData = _collection.Find(filter).First<PostagemData>();
                         
            if (postagemData != null)
            {
                postagem = ConvertDataToModel(postagemData);
            }

            return postagem;
        }

        private static Postagem ConvertDataToModel(PostagemData data)
        {
            Postagem postagemModel = new Postagem()
            {
                Id = data.Id.ToString(),
                Titulo = data.Titulo,
                Subtitulo = data.Subtitulo,
                DataCadastro = data.DataCadastro,
                Texto = data.Texto
            };
            
            return postagemModel; 
        }

        private static PostagemData ConvertModelToData(Postagem postagemModel)
        {
            PostagemData postagemData = new PostagemData()
            {                
                Titulo = postagemModel.Titulo,
                Subtitulo = postagemModel.Subtitulo,
                DataCadastro = postagemModel.DataCadastro,
                Texto = postagemModel.Texto
            };

            return postagemData;
        }
    }
}
