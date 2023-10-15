
TODO:

- Criar camada de Domínio

- Definir Entidades --> E suas respectivas propriedades
- Criar validações de Domínio
- Criar notificações de erros de domínio.





- Criar camada de Infra.Data
- Criar contexto do Banco de Dados
- Configurar entidades (EntityTypeConfiguration) utilizando a FluentApi
- Criar repositorios para todas as entidades (CRUD)
- Criar as migrations
- APlicar as migrations e criar o banco de Dados

- Criar a camada de aplicação

- Criar os Services
- DTOs (COnfigurar os DataNotations) 
- 


- Criar camada de Apresentação
- Controllers
- Configurar autenticação e autorização

- No final quero ter um resultado igual ao do final do curso do DevIO.


- Criar no banco de dados campos (CreatedAt, UpdatedAt, User)

- Upload de documentos


dotnet ef migrations add InitDatabase --project PHDevIO.Infra.Data/PHDevIO.Infra.Data.csproj -s PHDevIO.Api/PHDevIO.Api.csproj -c ApplicationDbContext --verbose 

