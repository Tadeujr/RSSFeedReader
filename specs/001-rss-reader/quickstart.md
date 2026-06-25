# Guia Rápido de Validação

## Pré-requisitos

- .NET SDK compatível com ASP.NET Core e Blazor WebAssembly.
- Repositório clonado em `c:\Users\tadeu\Documents\RSSFeedReader`.

## Passos de validação

1. Construir e iniciar o backend:

```powershell
cd c:\Users\tadeu\Documents\RSSFeedReader\backend\RSSFeedReader.Api
dotnet build
dotnet run
```

2. Construir e iniciar o frontend:

```powershell
cd c:\Users\tadeu\Documents\RSSFeedReader\frontend\RSSFeedReader.UI
dotnet build
dotnet run
```

3. Abrir a aplicação no navegador.
4. Inserir uma URL de feed no campo de assinatura e confirmar a adição.
5. Verificar que a URL aparece imediatamente na lista de assinaturas.

## Cenários de validação

- A interface deve carregar sem erros.
- Adicionar uma URL válida deve atualizar a lista sem recarregar a página.
- URLs vazias ou malformadas devem ser rejeitadas com mensagem de erro.
- Duplicatas devem ser impedidas e o usuário deve ser informado.

## Resultado esperado

- O backend responde a `GET /api/subscriptions` com a lista atual de assinaturas.
- O frontend mostra as assinaturas adicionadas.
- Não há persistência entre reinicializações do aplicativo no MVP.
