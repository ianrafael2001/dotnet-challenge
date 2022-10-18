#  Desafio Concert .NET API RESTFul

Para o desafio da Concert, foi desenvolvido uma aplicação backend em C# usando o Framework .NET Core que consiste em criar uma API RESTFul para  o gerenciamento de dados, como, cadastro, edição, remoção e visualização das entidades listadas no escopo (Projetos, Empregados e Membros).

# Como utilizar
## Clonar o repositório
<pre>
<code>git clone https://github.com/ianrafael2001/dotnet-challenge.git</code>
</pre>
## Rodar a API
<pre>
<code>cd dotnet-challenge/desafio</code>
<code>dotnet build</code>
<code>dotnet run</code>
</pre>

A aplicação irá rodar no endereço <code>https://localhost:7246/</code>

O Swagger poderá ser acessado apartir do endereço <code>https://localhost:7246/swagger/index.html</code>

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

>Utilizando Validator, foi adiocionado regras de negócio para certos endpoints, tais como, "Um projeto não deve ter nome repetido", "A data de encerramento não pode ser antes da data de criação"

**❌**• Executar projeto localmente via Docker

>Ainda não feito

## Endpoints

![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/39330420ebfc127e8152584b96ec5e64bc9c4e74/assets/endPoints.png)

## Tabelas no PostgresSQL

### Employees
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Employees.png)
### Projects
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Projects.png)
### Members
![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/67e5c782e9acb93426c3429ae363c8b2a0a07930/assets/Tabela%20Members.png)

## Paginação

Os endpoints que são permitido paginação são:

 <code>[GET] /Employee/page/{page}</code>; 
 <code>[GET] /Project/page/{page}</code>; 
 <code>[GET] /Member/page/{page}</code>
 
 Exemplo de paginação para os dados do empregado: 

 ![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/8af2cddff9aba196656cbf0d869517d84a327b2a/assets/Pagination.png)

## Autenticação e Autorização

 Para a realização da autenticação e autorização foi adicionado a rota <code>[POST] /Login</code>, que retorna um token que poderá ser utilizado nas rotas de adição e remoção de membros <code>[POST] /Member</code> e  <code>[DELETE] /Member/{id}</code>.
 Foi criado uma entidade estática <code>User</code> para poder simular o login.
 
### Login
User teste: <code>username: admin, password: admin</code>

 ![Preview](https://github.com/ianrafael2001/dotnet-challenge/blob/0108b0d4790440503d3b8d48a371fb9cab6018c0/assets/Login.png)


## Regras de Negócio
 Foram adicionado tais regras de negocio para as rotas:
 - <code>[POST] /Employee </code> : 
 > O primeiro nome deve ser obrigatorio
 - <code>[POST] /Project </code> : 
 > O nome do projeto deve ser obrigatorio;
 &nbsp;
  Não poderá ser cadastrado projetos com o mesmo nome;
 &nbsp;
  A data de encerramento deve ser posterior a data de criação do projeto;
 &nbsp;
