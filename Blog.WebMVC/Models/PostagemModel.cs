using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebMVC.Models
{
    public class PostagemModel
    {
        public string PostagemId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Texto { get; set; }
    }
}