using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.Infra.Data.Mongo.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<TEntity> _collection;

        public RepositoryBase()
        {
            _client = new MongoClient(Util.Util.MongoClientConnection);
            _database = _client.GetDatabase(Util.Util.MongoDataBase);
            _collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }


        public TEntity GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).First<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList<TEntity>();            
        }

        public void Add(TEntity obj)
        {
            _collection.InsertOne(obj);
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
