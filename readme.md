# Produtos API

API RESTful para cadastro, consulta, atualização e remoção de produtos, utilizando .NET, Oracle e Entity Framework Core.

---

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Oracle Database](https://www.oracle.com/database/technologies/) (local ou remoto)
- Ferramenta de teste de API (ex: [VS Code REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client), [Postman](https://www.postman.com/), [curl](https://curl.se/))

---

## Passo a Passo para Rodar o Projeto

### 1. Clone o repositório

```sh
git clone <url-do-repositorio>
cd <pasta-do-projeto>
```

### 2. Configure a string de conexão do Oracle

No arquivo `.env.sample`, preencha as informações de acesso ao seu banco Oracle, por exemplo:

```
ORACLE_USER=SEU_USUARIO
ORACLE_PASSWORD=SUA_SENHA
ORACLE_HOST=SEU_SERVIDOR
ORACLE_PORT=1521
ORACLE_SERVICE=SEU_SERVICO
```

Depois, **renomeie** o arquivo `.env.sample` para `.env` e ajuste o `appsettings.json` (ou `appsettings.Development.json`) para ler a string de conexão das variáveis de ambiente, se necessário:

```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=${ORACLE_USER};Password=${ORACLE_PASSWORD};Data Source=${ORACLE_HOST}:${ORACLE_PORT}/${ORACLE_SERVICE}"
}
```

> **Dica:** Se o projeto não estiver configurado para ler variáveis de ambiente automaticamente, copie os valores do `.env` e substitua diretamente no `appsettings.json`.

### 3. Restaure os pacotes NuGet

```sh
dotnet restore
```

### 4. Aplique as migrations (crie as tabelas no banco)

```sh
dotnet ef database update --project ProdutosData --startup-project ProdutosApi
```

### 5. Rode a aplicação

```sh
dotnet run --project ProdutosApi
```

A API estará disponível em `http://localhost:5189` (ou outra porta informada no console).

---

## Como Testar a API

Você pode usar o arquivo `Produtos.http` no VS Code (com a extensão REST Client) ou qualquer ferramenta de API.

### Exemplos de requisições

#### Listar todos os produtos

```http
GET http://localhost:5189/api/produtos
Accept: application/json
```

#### Criar um novo produto

```http
POST http://localhost:5189/api/produtos
Content-Type: application/json

{
  "nome": "Boneca Barbie Collector",
  "preco": 99.90
}
```

#### Obter produto por ID

```http
GET http://localhost:5189/api/produtos/1
Accept: application/json
```

#### Atualizar produto

```http
PUT http://localhost:5189/api/produtos/1
Content-Type: application/json

{
  "id": 1,
  "nome": "Produto Atualizado",
  "preco": 120.00
}
```

#### Remover produto

```http
DELETE http://localhost:5189/api/produtos/1
Accept: application/json
```

---

## Documentação Interativa

Acesse o Swagger em:  
```
http://localhost:5189/swagger
```

---

## Observações

- Certifique-se de que o Oracle está acessível e o usuário tem permissão para criar tabelas e inserir dados.
- Caso rode em outra máquina, repita os passos acima e ajuste a string de conexão conforme o ambiente.

---