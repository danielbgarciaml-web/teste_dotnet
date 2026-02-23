**Gestão de Veículos API**
Esta é uma Web API profissional desenvolvida em ASP.NET Core 8, focada em boas práticas de arquitetura, segurança e performance. O projeto gerencia um estoque de veículos com autenticação de usuários via JWT e validação rigorosa de dados.

**Arquitetura e Padrões**
O projeto foi construído seguindo os princípios da Clean Architecture e CQRS, garantindo baixo acoplamento e alta testabilidade.

CQRS com MediatR: Lógica de negócio dividida entre Commands (Escrita) e Queries (Leitura).

Service Layer + Handlers: Camada de aplicação que abstrai a complexidade do domínio.

Repository Pattern: Desacoplamento entre a persistência de dados e a regra de negócio.

Segurança (JWT + BCrypt): Autenticação via tokens JWT. As senhas são protegidas com hashing BCrypt.

FluentValidation: Validações automáticas que garantem o retorno de HTTP 400 (Bad Request) para entradas inválidas.

**Tecnologias Utilizadas**
ASP.NET Core 8 (Web API)

Entity Framework Core (In-Memory Database)

MediatR (Padrão Mediator)

FluentValidation (Validação de Schemas)

BCrypt.Net (Criptografia de Senhas)

Swagger/OpenAPI (Documentação Interativa)

**Como Executar o Projeto**
Pré-requisitos: Ter o SDK do .NET 8 instalado.

Execução:

Bash
dotnet restore
dotnet run --project Veiculos.WebApi
Acesso: A API abrirá automaticamente no navegador através do Swagger. Caso não abra, acesse a URL indicada no console (ex: https://localhost:7139).

**Guia de Teste: Autenticação e Validação**
Como utilizamos um Banco de Dados em Memória, os dados são resetados a cada execução. Siga esta ordem para testar os endpoints protegidos:

1. Cadastrar Usuário
Vá ao endpoint POST /api/Usuarios.

Importante: A senha deve ter no mínimo 6 caracteres (regra do FluentValidation).

Envie o JSON:

JSON
{ "nome": "Administrador", "login": "admin", "senha": "123456" }
2. Realizar Login
Vá ao endpoint POST /api/Auth/login.

Use as credenciais criadas acima.

Copie o Token gerado na resposta (sem as aspas).

3. Habilitar o "Cadeado" no Swagger
No topo da página do Swagger, clique no botão Authorize.

No campo, digite: Bearer  seguido do seu token (ex: Bearer eyJhbGci...).

Clique em Authorize e depois em Close.

4. Acessar Endpoints Protegidos
Agora, os endpoints de /api/Veiculos retornarão 200 OK em vez de 401 Unauthorized.

**Exemplos de Payload**
Cadastro de Veículo (POST /api/Veiculos)
JSON
{
  "descricao": "Veículo completo e revisado",
  "marca": 1, 
  "modelo": "Civic G10",
  "opcionais": "Ar condicionado, Direção Hidráulica, Teto Solar",
  "valor": 98500.00
}
Nota: O campo marca é um Enum. Caso envie um valor fora do range definido, a API retornará erro de validação.

**Organização de Pastas**
Veiculos.Domain: Entidades, Enums e Interfaces dos Repositórios.

Veiculos.Application: Commands, Queries, Handlers e Validations (FluentValidation).

Veiculos.Infra: Contexto do EF Core e implementação dos Repositórios.

Veiculos.WebApi: Controllers e configurações de segurança/JWT (Program.cs).

Dica para o Avaliador:
Ao testar a validação, tente cadastrar um usuário com senha curta ou um veículo sem descrição para observar as mensagens de erro customizadas retornadas pelo FluentValidation.
