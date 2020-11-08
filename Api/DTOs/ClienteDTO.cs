using System;
using System.Collections.Generic;

namespace SquadraWeb.Api.DTOs
{
    public partial class ClienteDTO
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
