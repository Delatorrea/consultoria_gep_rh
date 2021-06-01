# ProEventosApp

## Avaliação técnica

Desenvolvimento de API em .NET Core com persistência de dados em Banco de dados SQLite e Front End Angular para Cadastro, Edição e Exclusão de dados. 

### Tenologias utilizadas:

- Angular na versão 11.2.12.
- Bootstrap 5
- Web API .NET 5
- Entity Framework
- Swagger


## Iniciando a Aplicação

### Para subir o Back end siga os passos abaixo:

Acese a pasta do projero: ...src\ProEventos.API


No CLI digite o seguinte comando para criar as Migrations do Banco de dados


| dotnet ef migrations add InitialMigration


Em seguida Crie o banco de dados


| dotnet ef database update


Após isso basta subir a aplicação para ter a API e o Swagger rodando.


| dotnet run


### Para subir o Front end siga os passos abaixo:

| ng serve -o

 `http://localhost:4200/`
