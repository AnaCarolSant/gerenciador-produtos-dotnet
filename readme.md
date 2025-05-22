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

### 2. Configure a string de conexão com o Oracle

No arquivo `.env.sample`, preencha as informações de acesso ao seu banco de dados Oracle:

```
ORACLE_USER=SEU_USUARIO
ORACLE_PASSWORD=SUA_SENHA
ORACLE_HOST=SEU_SERVIDOR
ORACLE_PORT=1521
ORACLE_SERVICE=SEU_SERVICO
```

Depois de preenchido, **renomeie o arquivo `.env.sample` para `.env`**:

```sh
mv .env.sample .env
```

> ⚠️ **Importante:** A aplicação **não está configurada para ler variáveis do `.env` automaticamente**. Portanto, você **deve copiar os valores definidos no `.env`** e substituir diretamente no arquivo `appsettings.json` (ou `appsettings.Development.json`) na seção de `ConnectionStrings`.

Exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_SERVIDOR:1521/SEU_SERVICO"
}
```

> 💡 Você pode configurar a leitura via variáveis de ambiente utilizando a biblioteca `DotNetEnv`, se desejar automatizar esse processo no futuro.

---

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
- O uso de um `.env` serve como modelo de configuração, mas **a string precisa ser corretamente ajustada no arquivo de configuração da aplicação (`appsettings`)**.

---