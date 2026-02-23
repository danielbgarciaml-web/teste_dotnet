Gestão de Veículos API
Esta é uma Web API profissional desenvolvida em ASP.NET Core 8, focada em boas práticas de arquitetura, segurança e performance. O projeto gerencia um estoque de veículos com autenticação de usuários via JWT.

Arquitetura e Padrões
O projeto foi construído seguindo os princípios da Clean Architecture e CQRS, garantindo baixo acoplamento e alta testabilidade.

CQRS com MediatR: A lógica de negócio é dividida entre Commands (Escrita) e Queries (Leitura), orquestrados pelo MediatR.

Service Layer + Handlers: Uma camada de aplicação que abstrai a complexidade do domínio.

Repository Pattern: Desacoplamento entre a persistência de dados e a regra de negócio.

Segurança com BCrypt: As senhas dos usuários nunca são salvas em texto plano; utilizamos hashing de mão única para proteção de dados.

FluentValidation: Validação robusta de entrada de dados para garantir a integridade do sistema.

Tecnologias Utilizadas
ASP.NET Core 8 (Web API)

Entity Framework Core (In-Memory Database)

MediatR (Padrão Mediator)

FluentValidation (Validação de Schemas)

BCrypt.Net (Criptografia de Senhas)

Swagger/OpenAPI (Documentação Interativa)

Como Executar o Projeto
Pré-requisitos: Ter o SDK do .NET 8 instalado.

Execução:

Bash
dotnet restore
dotnet run --project Veiculos.WebApi
Acesso: A API abrirá automaticamente no navegador através do Swagger: https://localhost:PORTA/swagger.

Como Utilizar a Autenticação (Swagger)
A API utiliza o padrão JWT Bearer. Siga os passos abaixo para testar endpoints protegidos:

Cadastrar Usuário:

Vá ao endpoint POST /api/Usuarios.

Envie um JSON: { "nome": "Seu Nome", "login": "admin", "senha": "123" }.

Realizar Login:

Vá ao endpoint POST /api/Auth/login.

Use o login e senha criados.

Copie o token gerado na resposta.

Habilitar o Cadeado:

No topo da página do Swagger, clique no botão Authorize.

No campo, digite: Bearer SEU_TOKEN_AQUI (importante manter o espaço após a palavra Bearer).

Clique em Authorize e depois em Close.

Testar Veículos: Agora, todos os endpoints de /api/Veiculos estarão liberados para o seu usuário.

Exemplos de JSON
Cadastro de Veículo (POST /api/Veiculos)
JSON
{
  "descricao": "Veículo completo e revisado",
  "marca": 1, 
  "modelo": "Civic G10",
  "opcionais": "Ar condicionado, Direção Hidráulica, Teto Solar",
  "valor": 98500.00
}
(Nota: O campo marca é um Enum. Ex: 1 = Fiat, 2 = Ford, etc.)

Organização de Pastas
Veiculos.Domain: Entidades, Enums e Interfaces dos Repositórios.

Veiculos.Application: Commands, Queries, Handlers e Validations.

Veiculos.Infra: Contexto do EF Core e implementação dos Repositórios.

Veiculos.WebApi: Controllers e configurações de inicialização.
