using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Postagem : EntityBase
    {
        [BsonId]
        public ObjectId PostagemId { get; set; }

        public DateTime DataCadastro { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Texto { get; set; }

        public override void IsValid()
        {
            if (DataCadastro == DateTime.MinValue)
                throw new ApplicationException("Data de Cadastro não informada");
            if (DataCadastro.Date < DateTime.Now.Date)
                throw new ApplicationException("Data de Cadastro inválida. Não é permitido informar uma data menor que a data do sistema.");
            if (string.IsNullOrEmpty(Titulo))
                throw new ApplicationException("Título não informado");
            if (string.IsNullOrEmpty(Subtitulo))
                throw new ApplicationException("Subtítulo não informado");
            if (string.IsNullOrEmpty(Texto))
                throw new ApplicationException("Texto não informado");
        }

    }
}
