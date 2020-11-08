using System;
using System.Collections.Generic;

namespace SquadraWeb.Api.Models
{
    public partial class VendaDTO
    {
        public string IdLivro { get; set; }
        public int? IdCliente { get; set; }
        public int Quantidade { get; set; }
        public int Id { get; set; }
        public decimal? Total { get; set; }
    }
}
