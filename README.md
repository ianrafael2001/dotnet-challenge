#  Desafio Concert .NET API RESTFul

Para o desafio da Concert, foi desenvolvido uma aplicação backend em C# usando o Framework .NET Core que consiste em criar uma API RESTFul para  o gerenciamento de dados, como, cadastro, edição, remoção e visualização das entidades listadas no escopo (Projetos, Empregados e Membros).



# Metas
Para a entrega do desafio, foi estabelecido as Metas

**✅**• Utilizar banco de dados PostgresSQL ou Mysql para persistência. 

>Foi utilizado o PostgresSQL para fazer o armazenamento e perscistencia dos dados.

**✅**• A criação do banco de dados deve ser feita através de migrations 

>As tabelas de entidades foram criadas através de migrations utilizando o Entity Framework.

**✅**• Deve possuir documentação utilizando Swagger 

>Para documentação das rotas, foi utilizado o Swagger

**✅**• Tratar autenticação e autorização usando JWT 

>Foi criado rotas que demandam a autenticação e autorização.

**✅**• Os endpoints que contêm lista de objetos, deverá ter paginação 

>Para rotas de listagem das entidades, foi adicionado o recurso de paginação

**✅**• Escolha algum endpoint e adicione uma ou mais regras de negócio. Exemplo. “O Projeto não pode ter o nome de ‘Google’” 

>Utilizando Validations, foi adiocionado regras de negócio para certos endpoints, tais como, "Um projeto não deve ter nome repetido", "A data de encerramento não pode ser antes da data de criação"

**❌**• Executar projeto localmente via Docker

>Ainda não foi possivel executar o projeto localmente via Docker 

## Endpoints

...
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/endPoints.png)

## Tabelas no PostgresSQL

### Employees
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Employees.png)
### Projects
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Projects.png)
### Members
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Members.png)
...

## Paginação

...

## Autenticação e Autorização

...

## Regras de Negócio

...
