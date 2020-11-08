using System;
using System.Collections.Generic;

namespace SquadraWeb.Api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
