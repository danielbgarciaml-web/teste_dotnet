# Veículos API - Teste Técnico .NET Sênior

Esta é uma API REST desenvolvida em .NET 8 seguindo os princípios de **Clean Architecture**, **DDD** e o padrão **CQRS** com MediatR.

 Tecnologias Utilizadas
- .NET 8 (ASP.NET Core)
- Entity Framework Core InMemory
- MediatR (Pattern CQRS)
- FluentValidation (Validação de entrada)
- JWT Authentication & Authorization
- BCrypt.Net (Hash de senha)
- Swagger (OpenAPI)

 Arquitetura
A solução está dividida em 4 camadas principais:
1. **Domain**: Entidades, Enums e Interfaces de Repositório (Core do negócio).
2. **Application**: Commands, Queries, Handlers, DTOs e Services.
3. **Infra**: Implementação do DbContext InMemory e Repositórios.
4. **Api**: Controllers, Configurações de JWT e Middleware de exceção.

Como Executar
1. Clone o repositório.
2. Certifique-se de ter o SDK do .NET 8 instalado.
3. Na pasta raiz, execute: `dotnet run --project Veiculos.Api`
4. Acesse o Swagger em: `https://localhost:PORTA/swagger`

Como Testar a Autenticação
1. **Cadastrar Usuário**: Use o endpoint `POST /api/usuarios` para criar sua conta.
2. **Login**: Use o endpoint `POST /api/auth/login` com as credenciais criadas. 
3. **Token**: Copie o `accessToken` retornado.
4. **Autorizar**: No Swagger, clique no botão **Authorize**, digite `Bearer SEU_TOKEN_AQUI` e clique em Authorize.
5. **Veículos**: Agora os endpoints de `/api/veiculos` estarão liberados.
