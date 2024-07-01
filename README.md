# API de Notas Fiscais

Esta é uma API para gerenciar Notas Fiscais, Clientes e Fornecedores, seguindo princípios de DDD, SOLID e padrões de projeto como Repositório e Serviço. A API foi construída usando C# e MongoDB.

## Requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (ou utilizar um serviço de MongoDB na nuvem, como o [MongoDB Atlas](https://www.mongodb.com/cloud/atlas))

## Configuração do Projeto

1. **Clone o repositório**

    ```bash
    git clone https://github.com/Eduardo007-lang/teste_tecnico_BRGAAP_Backend.git

    cd teste_tecnico_BRGAAP_Backend
    ```

2. **Configure a string de conexão do MongoDB**

    No arquivo `appsettings.json`, configure a string de conexão do MongoDB, e na pasta `Schema.db`, importe os arquivos de .schema.json e depois as collections:

    ```json
    {
      "ConnectionStrings": {
        "MongoDb": "sua-string-de-conexao-do-mongodb"
      }
    }
    ```

3. **Restaure as dependências**

    ```bash
    dotnet restore
    ```

4. **Inicie o servidor**

    ```bash
    dotnet run
    ```

## Endpoints da API

### Notas Fiscais

- **GET /api/NotaFiscal**: Retorna todas as notas fiscais.
- **GET /api/NotaFiscal/{id}**: Retorna uma nota fiscal específica por ID.
- **POST /api/NotaFiscal**: Cria uma nova nota fiscal.


## Estrutura do Projeto

O projeto segue os princípios de DDD (Domain-Driven Design) e SOLID, com a seguinte estrutura:

- **Controllers**: Contém os controladores da API.
- **Models**: Contém os modelos de dados.
- **Services**: Contém a lógica de negócios.
- **Repositories**: Contém a lógica de acesso aos dados.

## Tecnologias Utilizadas

- **C# e ASP.NET Core**: Plataforma para desenvolvimento do backend.
- **MongoDB**: Banco de dados NoSQL para armazenamento dos dados.
