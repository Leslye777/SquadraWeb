using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SquadraWeb.Api.Models
{
    public partial class Venda
    {
        public string IdLivro { get; set; }
        public int? IdCliente { get; set; }
        public int Quantidade { get; set; }
        public int Id { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal? Total { get; set; }
        
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }

        [JsonIgnore]
        public virtual Livro Livro { get; set; }
    }
}
