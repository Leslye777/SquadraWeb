using System;
using System.Collections.Generic;

namespace SquadraWeb.Api.Models
{
    public partial class LivroDTO
    {


        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

    }
}
