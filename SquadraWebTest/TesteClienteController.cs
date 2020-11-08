using SquadraWeb.Api.Models;
using SquadraWeb.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using SquadraWeb.Api;
using System.Data.Common;
using SquadraWeb.Api.DTOs;

namespace SquadraWebTest
{
    public class TesteClienteController
    {
        [Fact]
        public void GetClienteByNameSucces()
        {
            //Arrange

            SquadraWEBContext context = new SquadraWEBContext();

            ClientesController clientes = new ClientesController(context);
            ClienteDTO aux = new ClienteDTO();


            aux.Cpf = "12345678910";
            aux.Endereco = "teste";
            aux.Nome = "Jefferson";
            aux.Telefone = "teste";

            var resultado = clientes.PostCliente(aux);

            //Act
            var resultado2 = clientes.GetClienteByName(aux.Nome);

            //Assert
            Assert.Equal(aux.Nome, resultado2.Value.Nome);



        }

        [Fact]
        public void GetClienteByNameFail()
        {
            //Arrange

            SquadraWEBContext context = new SquadraWEBContext();

            ClientesController clientes = new ClientesController(context);

          
            // Acho que !!! não é um nome valido em nenhum idioma
            //Act
            var resultado2 = clientes.GetClienteByName("!!!");

            //Assert
            Assert.Equal("!!!", resultado2.Value.Nome);


        }

    }
}
