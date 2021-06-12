# digital-school-messaging-azure-bus

Aplicação .Net Core 5.0 Web API desenvolvida com o objetivo didático de demonstrar o funcionamento de mensageria utilizando o Azure Service Bus.

Cenário: Aplicativo que envia um resumo diário para os pais/guardiões do dia a dia do aluno. Quando o serviço de Aluno recebe a requisição para incluir um novo aluno, são disparadas mensagens para que o serviço de autenticação já crie os usuários de autenticação (Identity) dos pais/guardiões.

# Este projeto contém:

- Arquitetura Microsserviços;
- Azure Service Bus;
- Pattern CQRS com MediatR;
- Pattern Repository;
- Fluent Validation;
- Mapeamento das entidades por Fluent API;
- Entity Framework (EF) Core; 
- Persistência em SQLServer;
- DTO e AutoMapper;
- Versionamento da API;
- Swagger/Swagger UI;

# Sobre Microsserviços:
- O projeto é didático, logo aceita-se que os serviços não tenham BD heterogêneos e que estes persistam no mesmo.

# Como executar:
- Clonar / baixar o repositório em seu workplace.
- Baixar o .Net Core SDK e o Visual Studio / Code mais recentes.
- Atualizar as connection strings do SQLServer e do Azure Service Bus

# TODO
- Desenvolver os demais controllers.
- Implementação dos testes.

# Sobre
Este projeto foi desenvolvido por Anderson Hansen sob [MIT license](LICENSE).
