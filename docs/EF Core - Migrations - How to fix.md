# EF Core - Migrations

No processo de desenvolvimento, uma das estratégias que pode ser adotada para a criação, edição e manutenção dos modelos de Banco de Dados é a denominada **Code-First** que pode ser utilizada em conjunto com o EF Core.

Neste contexto, durante o processo de desenvolvimento, a fim de criar e aplicar as migrations faz-se necessários as seguintes configurações:

- Instalação dos pacotes do EF Core

```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer //ou outro DataProvider
```
- Criação da Classes de contexto do EF Core e os seus respectiovos DbSets (Entidades a serem criadas tabelas no banco)
- Configuração das entidades utilizando a FluentAPI para definir as propriedades do Database a ser gerado.


# Problema

Ao executar o comando para criar uma nova migration:
```sh
dotnet ef migrations add InitialCreate
```
Obtive o erro:
![](https://i.stack.imgur.com/pm3dd.png)

A fim de depurar e enteder o problema pode-se utilizar o parâmetro **--verbose** no comando para entender os processos que estão sendo realizados pelo comando e buscar identificar o erro.

```sh
dotnet ef migrations add InitialCreate --verbose
```

A partir deste comando, foi possível identificar que o erro que de fato ocorria era semelhante a:

'Unable to resolve service for type ¨Microsoft.entityFrameworkCore.DbContextOptions¨1[LibraryData.LibraryContext] while attempting to activate

# Solução

Em uma rápida pesquisa na internet, verificou-se que isso ocorre principalmente em aplicações que estão separadas em diferentes camadas em que a classe de Startup.cs não está no mesmo projeto que a classe que possui o DbContext, desta forma a aplicação não consegue encontrar o DbContext e as conectionsStrings e concluir o processo.

Como solução basta executar o seguinte comando:

```sh
dotnet ef migrations add InitDatabase --project PHDevIO.Infra.Data/PHDevIO.Infra.Data.csproj -s PHDevIO.Api/PHDevIO.Api.csproj -c ApplicationDbContext --verbose 
```
Que possui os parâmetros:

- project --> que determina o projeto em que se encontra o DbContext de referência e que será gerado as Migrations
- s --> que determina o projeto de Startup da aplicação
- c --> NOme do DbContext

Desta forma, a aplicação consegue reconhecer todas as configurações e gerar corretamente as migrations;

Por fim, para executar as migrations no Database basta executar o comando:

```sh
dotnet ef database update --project PHDevIO.Infra.Data/PHDevIO.Infra.Data.csproj -s PHDevIO.Api/PHDevIO.Api.csproj -c ApplicationDbContext --verbose 
```



## References

[Docs Microsoft - Migrations Overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?source=recommendations&tabs=dotnet-core-cli)

[StackOverflow Solution](https://stackoverflow.com/questions/70273434/unable-to-resolve-service-for-type-%C2%A8microsoft-entityframeworkcore-dbcontextopti)


