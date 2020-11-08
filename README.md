# SquadraWeb
Projeto asp.net core aplication commit inicial

O projeto consiste em um pequeno sistema que é capaz de realizar operações crud basicas. Algumas alterações foram feitas ao longo do projeto como a construção de DTO's
para a melhor visualização das funcionalidades no swagger. Durante a criação do banco de dados acabei me esquecendo de tratar CPF como valor unico e para não ter de refazer todo
o scaffolding novamente optei por tratar isso em codigo. Também acrescentei algumas funções básicas como  GetClientByName. Na controller de venda ela é capaz de subtrair um livro 
toda vez que ele for vendido e verificar se há o livro em estoque antes de vender e também calcula o total daquela compra. 

# Teste 
Optei por realizar um teste unitario que testa a controller cliente, mais especificamente o metodo  GetClienteByName, o teste foi satisfatorio e os resultados foram dentro do 
esperado. O banco de dados utilizado está disponivel para download. 

#Agradecimentos 
Agradeço a Ana Eliza Bastos por todo conhecimento e paciencia transmitidos durante o curso e a Squadra pela oportunidade de participar desse projeto  incrivel projeto que 
com certeza serei grato por toda a minha vida.
