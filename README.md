# ClientHub

## Descrição
O ClientHub é um sistema de cadastro de clientes desenvolvido utilizando o padrão MVC e WebApi com .NET 6.0 Razor. A estrutura do projeto foi organizada de forma a maximizar a reutilização de código e facilitar a escalabilidade para futuros projetos similares.

## Padrão de Projeto
No projeto ClientHub, optou-se por utilizar uma abordagem que centraliza a lógica de negócios, acesso a dados e serviços em uma biblioteca de classes (ClassLibrary). Essa biblioteca contém todos os métodos comuns que serão utilizados tanto no projeto MVC quanto no WebApi. Dessa forma, a parte de banco de dados, migrações, modelos, serviços e interfaces são centralizados nessa biblioteca, promovendo a reutilização de código e uma estrutura mais organizada.

## Benefícios
- **Reutilização de Código:** Evita a repetição de código, uma vez que a lógica de negócios é compartilhada entre os projetos MVC e WebApi.
- **Facilidade de Manutenção:** Centralizando a lógica de negócios e acesso a dados, as atualizações e manutenções tornam-se mais simples e menos propensas a erros.
- **Escalabilidade:** A estrutura modular permite a criação de novos projetos para outros clientes, aproveitando a mesma biblioteca de classes.
  
[![](https://mermaid.ink/img/pako:eNpNj7EOgzAMRH8l8gw_kKFSBZU6lKlVO5AOhpgSKSQodVQh4N8bytLJp3s--TxD6zWBhM76T9tjYHErlSvqi2kChqmwhhzTOTZPkecHsTyoOY5mEWWdxk43mCI7r-7FIk71X045ISCDgcKARqdT8-Yo4J4GUiCT1NRhtKxAuTWtYmR_nVwLkkOkDOKokak0-Ao4gOzQvpNL2rAP1V7_98X6BVPmRgM?type=png)](https://mermaid.live/edit#pako:eNpNj7EOgzAMRH8l8gw_kKFSBZU6lKlVO5AOhpgSKSQodVQh4N8bytLJp3s--TxD6zWBhM76T9tjYHErlSvqi2kChqmwhhzTOTZPkecHsTyoOY5mEWWdxk43mCI7r-7FIk71X045ISCDgcKARqdT8-Yo4J4GUiCT1NRhtKxAuTWtYmR_nVwLkkOkDOKokak0-Ao4gOzQvpNL2rAP1V7_98X6BVPmRgM)

# Tecnologias Utilizadas:

- .NET 6.0
- Entity Framework 6.0
- Razor
- JavaScript
- AJAX
- Banco de Dados SQL Server
- Visual Studio 2022

# Dependências e Versões Necessárias:

- .NET SDK 6.0
- Entity Framework 6.0
- SQL Server Management Studio (SSMS) 18.0 ou superior
  
# Pacotes NuGet Utilizados

A seguir estão listados os pacotes NuGet utilizados no projeto ClientHub, juntamente com suas versões correspondentes:

- **Microsoft.AspNetCore.Authentication.JwtBearer 6.0.29**
  - Descrição: Oferece suporte à autenticação baseada em tokens JWT (JSON Web Token) no ASP.NET Core.

- **Microsoft.AspNetCore.Http 2.2.2**
  - Descrição: Fornece classes e interfaces para manipulação de solicitações HTTP e respostas HTTP no ASP.NET Core.

- **Microsoft.AspNetCore.Http.Features 5.0.17**
  - Descrição: Contém interfaces para recursos de solicitações e respostas HTTP no ASP.NET Core.

- **Microsoft.AspNetCore.Mvc.Abstractions 2.2.0**
  - Descrição: Contém interfaces e classes abstratas relacionadas ao ASP.NET Core MVC (Model-View-Controller).

- **Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 6.0.29**
  - Descrição: Habilita a compilação em tempo de execução das visualizações Razor em aplicativos ASP.NET Core MVC.

- **Microsoft.EntityFrameworkCore.Design 6.0.29**
  - Descrição: Fornece ferramentas de design do Entity Framework Core, incluindo o Scaffold-DbContext.

- **Microsoft.EntityFrameworkCore.SqlServer 6.0.29**
  - Descrição: Oferece suporte ao provedor de banco de dados SQL Server para o Entity Framework Core.

- **Microsoft.EntityFrameworkCore.Tools 6.0.29**
  - Descrição: Contém ferramentas adicionais para trabalhar com o Entity Framework Core, como migrações de banco de dados.

- **Swashbuckle.AspNetCore.Annotations 6.0.7**
  - Descrição: Permite a anotação de operações Swagger usando atributos ASP.NET Core.

- **Swashbuckle.AspNetCore.SwaggerGen 6.5.0**
  - Descrição: Implementa a geração de especificações OpenAPI (anteriormente conhecidas como Swagger) para aplicativos ASP.NET Core.

- **Swashbuckle.AspNetCore.SwaggerUI 6.5.0**
  - Descrição: Oferece uma interface do usuário para visualização e teste de APIs documentadas com o Swagger.

Esses pacotes são essenciais para a construção e funcionamento do projeto ClientHub, fornecendo funcionalidades como autenticação, manipulação de solicitações HTTP, geração de documentação de API, entre outras.

# Para rodar o projeto, siga os passos abaixo:

1. **Restaurar Banco de Dados:**
   - Na pasta do projeto, você encontrará um arquivo de banco de dados como backup. Restaure este banco de dados no SQL Server.
   - Configure a string de conexão no arquivo `DbClientHubContext.cs`, localizado em `LibraryClientHub/Models/DbClientHubContext.cs`. Por exemplo: 
     `"Server=localhost;Database=DbClientHub;Trusted_Connection=True;"`.

2. **Abrir o Projeto no Visual Studio 2022:**
   - Abra o projeto com o Visual Studio 2022.

3. **Configurar Projeto de Inicialização:**
   - Clique com o botão direito no projeto `ClientHub` e selecione a opção "Definir Projeto de Inicialização".
   - Execute o projeto. Isso iniciará o projeto MVC `ClientHub`.

4. **Gerenciar Clientes via MVC:**
   - Após iniciar o projeto MVC, você terá uma interface para gerenciar seus clientes e seus endereços. Você poderá visualizar, criar, atualizar e excluir registros.

5. **Iniciar a API:**
   - Repita o processo de definir o projeto de inicialização, mas desta vez selecione o projeto `ApiClientHub`.
   - Execute o projeto. Isso iniciará a API.
   - Faça a autenticação no endpoint `/Login`. Será gerado um token.
   - Na parte superior direita, há um botão "Authorize". Informe o token gerado, precedido pela palavra "Bearer". Exemplo: "Bearer oawienhfoianfoknalsavfdawf".

Agora você terá acesso ao Swagger com todos os endpoints para consumir os dados dos clientes.

Para confirmar que a aplicação está rodando corretamente, você pode verificar se consegue acessar a interface do projeto MVC e interagir com os clientes e endereços. Além disso, certifique-se de que pode autenticar-se na API e acessar os endpoints via Swagger.



# 📌 (ClientHub) - Informações importantes sobre a aplicação (MVC)  📌

## ClientController

Este controlador é responsável por lidar com as operações relacionadas aos clientes no sistema.

### Métodos

- **Index() : Task<IActionResult>**
  - Descrição: Retorna a página inicial da aplicação, exibindo a lista de clientes cadastrados.
  - **Funcionalidades:**
    - Busca os clientes cadastrados no sistema.
    - Converte o logo de cada cliente de bytes para um arquivo do tipo `IFormFile`.
    - Retorna a view `Index` com a lista de clientes.

- **Upsert(int? id) : Task<IActionResult>**
  - Descrição: Retorna a view para adicionar ou atualizar um cliente.
  - **Parâmetros:**
    - `id` (opcional): O ID do cliente a ser atualizado, se fornecido.
  - **Funcionalidades:**
    - Se nenhum ID for fornecido, retorna a view com um novo cliente.
    - Se um ID for fornecido, busca o cliente pelo ID e retorna a view preenchida com os dados do cliente encontrado.

- **Upsert(ClientViewModel client) : Task<IActionResult>**
  - Descrição: Adiciona ou atualiza um cliente com base nos dados fornecidos.
  - **Parâmetros:**
    - `client`: Um objeto `ClientViewModel` contendo os dados do cliente a ser adicionado ou atualizado.
  - **Funcionalidades:**
    - Valida os dados fornecidos pelo usuário.
    - Converte o logo do cliente de `IFormFile` para um array de bytes.
    - Verifica se o email já está em uso (apenas para novos clientes).
    - Adiciona um novo cliente se o ID for zero ou atualiza o cliente existente.
    - Retorna a view com uma mensagem de sucesso ou erro.

- **Delete(int id) : ActionResult**
  - Descrição: Exclui um cliente com base no ID fornecido.
  - **Parâmetros:**
    - `id`: O ID do cliente a ser excluído.
  - **Funcionalidades:**
    - Busca o cliente pelo ID fornecido.
    - Exclui o cliente encontrado.
    - Retorna uma mensagem de sucesso ou erro.

### Dependências

- **IClientsServises _clientsServises**: Uma instância da interface `IClientsServises` para realizar operações relacionadas aos clientes.

### Métodos Auxiliares

- **ConvertFileToByteArray(IFormFile file) : byte[]**
  - Descrição: Converte um arquivo do tipo `IFormFile` em um array de bytes.
  - **Parâmetros:**
    - `file`: O arquivo a ser convertido.
  - **Retorno:**
    - Um array de bytes representando o arquivo fornecido.

- **ConvertByteArrayToFormFile(byte[] fileBytes, string fileName, string contentType) : IFormFile**
  - Descrição: Converte um array de bytes em um arquivo do tipo `IFormFile`.
  - **Parâmetros:**
    - `fileBytes`: O array de bytes representando o arquivo.
    - `fileName`: O nome do arquivo.
    - `contentType`: O tipo de conteúdo (MIME type) do arquivo.
  - **Retorno:**
    - Um objeto `IFormFile` representando o arquivo convertido.
# 📌 (ClientHub) - Informações importantes sobre a aplicação  📌

## AddressClientController

Este controlador é responsável por lidar com as operações relacionadas aos endereços dos clientes no sistema.

### Métodos

- **Index() : Task<IActionResult>**
  - Descrição: Retorna a página inicial da aplicação, exibindo a lista de endereços de clientes cadastrados.
  - **Funcionalidades:**
    - Busca os endereços de clientes cadastrados no sistema.
    - Retorna a view `Index` com a lista de endereços de clientes.

- **Upsert(int? id) : Task<IActionResult>**
  - Descrição: Retorna a view para adicionar ou atualizar um endereço de cliente.
  - **Parâmetros:**
    - `id` (opcional): O ID do endereço a ser atualizado, se fornecido.
  - **Funcionalidades:**
    - Se nenhum ID for fornecido, retorna a view com um novo endereço de cliente.
    - Se um ID for fornecido, busca o endereço pelo ID e retorna a view preenchida com os dados do endereço encontrado.

- **Upsert(AddressClientViewModel address) : Task<IActionResult>**
  - Descrição: Adiciona ou atualiza um endereço de cliente com base nos dados fornecidos.
  - **Parâmetros:**
    - `address`: Um objeto `AddressClientViewModel` contendo os dados do endereço a ser adicionado ou atualizado.
  - **Funcionalidades:**
    - Valida os dados fornecidos pelo usuário.
    - Busca o cliente associado ao endereço.
    - Adiciona um novo endereço se o ID for zero ou atualiza o endereço existente.
    - Retorna a view com uma mensagem de sucesso ou erro.

- **Delete(int id) : Task<IActionResult>**
  - Descrição: Exclui um endereço de cliente com base no ID fornecido.
  - **Parâmetros:**
    - `id`: O ID do endereço a ser excluído.
  - **Funcionalidades:**
    - Busca o endereço pelo ID fornecido.
    - Exclui o endereço encontrado.
    - Retorna uma mensagem de sucesso ou erro.

### Dependências

- **IAddressClientServices _addressClientsServises**: Uma instância da interface `IAddressClientServices` para realizar operações relacionadas aos endereços dos clientes.
- **IClientsServises _clientsServises**: Uma instância da interface `IClientsServises` para realizar operações relacionadas aos clientes.
- 


# 📌 (ApiClientHub) - Informações importantes sobre a aplicação (WebApi) 📌

## AuthController

Este controlador é responsável pela autenticação dos usuários no sistema.

### Rotas

- **POST /api/auth/login**
  - Realiza o login do cliente e gera um token de acesso.

### Métodos

- **Login([FromBody] LoginViewModel login) : Task<IActionResult>**
  - Realiza a autenticação do cliente com base nas credenciais fornecidas.
  - **Descrição:** 
    - Um objeto `LoginViewModel` contendo o nome de usuário e a senha do cliente.
  - **Respostas:**
    - 200 OK: Retorna um token de acesso se o login for bem-sucedido.
    - 401 Unauthorized: Retorna se as credenciais fornecidas forem inválidas ou se o usuário não existir.

### Dependências

- **IAuthServices _authServices**: Uma instância da interface `IAuthServices` para realizar operações relacionadas à autenticação do usuário.

### Exemplo de Uso
```http
POST /api/auth/login

### Exemplo de Retorno
Content-Type: application/json

{
  "username": "exampleuser",
  "password": "examplepassword"
}


## ClientsController

Este controlador é responsável por lidar com operações relacionadas aos clientes no sistema.

### Rotas

- **GET /api/clients**
  - Obtém todos os clientes cadastrados.

- **GET /api/clients/{id}**
  - Obtém um cliente específico por ID.

- **PUT /api/clients/{id}**
  - Atualiza as informações de um cliente existente.

- **POST /api/clients**
  - Cria um novo cliente.

- **DELETE /api/clients/{id}**
  - Exclui um cliente existente com base no ID fornecido.

- **GET /api/clients/email/{email}**
  - Verifica a existência de um email de cliente.

### Métodos

- **GetClients() : Task<ActionResult<IEnumerable<Clients>>>**
  - Descrição: Retorna uma lista de todos os clientes cadastrados.

- **GetClient(int id) : Task<ActionResult<Clients>>**
  - Descrição: Retorna um cliente específico com base no ID fornecido.

- **PutClient(int id, BodyClientViewModel client) : Task<IActionResult>**
  - Descrição: Atualiza as informações de um cliente existente com base no ID fornecido.
  - Parâmetros:
    - `id` (rota): O ID do cliente a ser atualizado.
    - `client` (corpo da requisição): Um objeto contendo as informações atualizadas do cliente.
  - Respostas:
    - 204 No Content: Retorna se a atualização for bem-sucedida.
    - 400 BadRequest: Retorna se o ID fornecido não corresponder ao ID do cliente fornecido ou se os dados do cliente forem inválidos.
    - 404 NotFound: Retorna se o cliente não for encontrado.

- **PostClient(BodyClientViewModel client) : Task<ActionResult<Clients>>**
  - Descrição: Cria um novo cliente com base nas informações fornecidas.
  - Parâmetros:
    - `client` (corpo da requisição): Um objeto contendo as informações do novo cliente a ser criado.
  - Respostas:
    - 201 Created: Retorna o novo cliente criado.
    - 400 BadRequest: Retorna se os dados do cliente forem inválidos ou se o email fornecido já estiver em uso.

- **DeleteClient(int id) : Task<ActionResult>**
  - Descrição: Exclui um cliente existente com base no ID fornecido.
  - Parâmetros:
    - `id` (rota): O ID do cliente a ser excluído.
  - Respostas:
    - 204 No Content: Retorna se o cliente for excluído com sucesso.
    - 404 NotFound: Retorna se o cliente não for encontrado.

- **EmailExists(string email) : Task<IActionResult>**
  - Descrição: Verifica se um email de cliente já está em uso.
  - Parâmetros:
    - `email` (rota): O email a ser verificado.
  - Respostas:
    - 200 OK: Retorna true se o email já estiver em uso, caso contrário, retorna false.
    - 404 NotFound: Retorna se o email não estiver em uso.

### Dependências

- **IClientsServises _clientsServises**: Uma instância da interface `IClientsServises` para realizar operações relacionadas aos clientes.

### Exemplo de Uso

```http
GET /api/clients

### Exemplo de Retorno

[
  {
    "id": 1,
    "name": "Exemplo Cliente",
    "email": "cliente@example.com",
    "logoType": "logo.png"
  },
  {
    "id": 2,
    "name": "Outro Cliente",
    "email": "outrocliente@example.com",
    "logoType": "outrologo.png"
  }
]

## AddressClientController

Este controlador é responsável por lidar com operações relacionadas aos endereços de clientes no sistema.

### Rotas

- **GET /api/addressclient**
  - Obtém todos os endereços de clientes cadastrados.

- **GET /api/addressclient/{id}**
  - Obtém um endereço de cliente específico por ID.

- **PUT /api/addressclient/{id}**
  - Atualiza as informações de um endereço de cliente existente.

- **POST /api/addressclient**
  - Cria um novo endereço de cliente.

- **DELETE /api/addressclient/{id}**
  - Exclui um endereço de cliente existente com base no ID fornecido.

### Métodos

- **GetAddressClients() : Task<ActionResult<IEnumerable<AddressClient>>>**
  - Descrição: Retorna uma lista de todos os endereços de clientes cadastrados.

- **GetAddressClient(int id) : Task<ActionResult<AddressClient>>**
  - Descrição: Retorna um endereço de cliente específico com base no ID fornecido.

- **PutAddressClient(int id, BodyAddressClientViewModel address) : Task<IActionResult>**
  - Descrição: Atualiza as informações de um endereço de cliente existente com base no ID fornecido.
  - **Parâmetros:**
    - `id` (rota): O ID do endereço de cliente a ser atualizado.
    - `address` (corpo da requisição): Um objeto contendo as informações atualizadas do endereço de cliente.
  - **Respostas:**
    - 204 No Content: Retorna se a atualização for bem-sucedida.
    - 400 BadRequest: Retorna se o ID fornecido não corresponder ao ID do endereço fornecido ou se os dados do endereço forem inválidos.
    - 404 NotFound: Retorna se o endereço de cliente não for encontrado.

- **PostAddressClient(BodyAddressClientViewModel address) : Task<ActionResult<AddressClient>>**
  - Descrição: Cria um novo endereço de cliente com base nas informações fornecidas.
  - **Parâmetros:**
    - `address` (corpo da requisição): Um objeto contendo as informações do novo endereço de cliente a ser criado.
  - **Respostas:**
    - 201 Created: Retorna o novo endereço de cliente criado.
    - 400 BadRequest: Retorna se os dados do endereço de cliente forem inválidos ou se não for possível adicionar o endereço.

- **DeleteAddress(int id) : Task<IActionResult>**
  - Descrição: Exclui um endereço de cliente existente com base no ID fornecido.
  - **Parâmetros:**
    - `id` (rota): O ID do endereço de cliente a ser excluído.
  - **Respostas:**
    - 204 No Content: Retorna se o endereço de cliente for excluído com sucesso.
    - 404 NotFound: Retorna se o endereço de cliente não for encontrado.

### Dependências

- **IAddressClientServices _addressClientServices**: Uma instância da interface `IAddressClientServices` para realizar operações relacionadas aos endereços de clientes.
- **IClientsServises _clientsServises**: Uma instância da interface `IClientsServises` para realizar operações relacionadas aos clientes.

### Exemplo de Uso

```http
GET /api/addressclient
