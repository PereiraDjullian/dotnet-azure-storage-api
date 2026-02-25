# 📂 Azure Blob Storage API (.NET 10)

Esta API foi desenvolvida para gerenciar o ciclo de vida de arquivos na nuvem utilizando o **Azure Blob Storage**. O projeto faz parte dos meus estudos de integração entre o ecossistema .NET e os serviços de infraestrutura da Microsoft Azure.

## 🚀 Funcionalidades implementadas

- **Upload de Arquivos**: Envio de documentos/imagens via `multipart/form-data`.
- **Listagem de Blobs**: Retorno de metadados (nome, tipo e URI) de todos os arquivos no container.
- **Download**: Recuperação de arquivos diretamente do armazenamento para o cliente.
- **Exclusão**: Remoção definitiva de arquivos do Azure.

## 🛠️ Stack Tecnológica

- **Linguagem**: C# (.NET 10)
- **Framework**: ASP.NET Core Web API (Controllers)
- **SDK**: [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs)
- **Documentação**: Swagger / OpenAPI

## ⚙️ Como configurar e rodar

1. **Pré-requisitos**: Possuir uma conta na Azure e uma Storage Account criada.
2. **Configuração**: No arquivo `appsettings.json`, insira suas credenciais:
   ```json
   {
     "BlobConnectionString": "SUA_CONNECTION_STRING",
     "BlobContainerName": "NOME_DO_SEU_CONTAINER"
   }
Execução:

Bash
dotnet restore
dotnet run
Testes: Acesse http://localhost:5000/swagger (ou a porta configurada) para testar os endpoints interativamente.
<img width="1868" height="551" alt="image" src="https://github.com/user-attachments/assets/6c8dc43b-d20a-4a26-b4e9-92b2492e50de" />

