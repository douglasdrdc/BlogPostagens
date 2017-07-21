using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Mongo.Data
{
    public class PostagemData
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Texto { get; set; }
    }
}
