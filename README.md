GitHub Spec Kit commands will use stakeholder documentation to help generate the constitution.md, spec.md, and plan.md files.
# Executar o MVP RSS Feed Reader

Este guia explica como executar a solução localmente e testar o fluxo principal do MVP.

## Pré-requisitos

- .NET SDK 8.0 ou superior instalado
- Terminal aberto na raiz do repositório

## Passo 1: Construir os projetos

No terminal, estando na raiz do repositório, execute:

```powershell
dotnet build backend\RSSFeedReader.Api\RSSFeedReader.Api.csproj

dotnet build frontend\RSSFeedReader.UI\RSSFeedReader.UI.csproj
```

## Passo 2: Iniciar o backend

No mesmo terminal ou em outro, estando na raiz do repositório, execute:

```powershell
dotnet run --project backend\RSSFeedReader.Api\RSSFeedReader.Api.csproj --urls http://localhost:5227
```

O backend ficará disponível em:

- `http://localhost:5227`

## Passo 3: Iniciar o frontend

Abra outro terminal e execute, estando na raiz do repositório:

```powershell
dotnet run --project frontend\RSSFeedReader.UI\RSSFeedReader.UI.csproj --urls http://localhost:5252
```

O frontend ficará disponível em:

- `http://localhost:5252`

## Passo 4: Acessar a aplicação

Abra o navegador e acesse:

- `http://localhost:5252`

Se preferir, acesse diretamente a página de assinaturas:

- `http://localhost:5252/subscriptions`

## Passo 5: Testar o fluxo do MVP

1. No campo de URL, cole uma URL de feed válida, por exemplo:
   - `https://example.com/feed.xml`
2. Clique em **Adicionar assinatura**.
3. Verifique se a URL aparece na lista de assinaturas.
4. Teste os casos de erro:
   - campo vazio → mensagem de erro
   - URL inválida → mensagem de erro
   - URL duplicada → mensagem de conflito

## Teste direto na API

### Verificar lista de assinaturas

```powershell
Invoke-RestMethod -Uri http://localhost:5227/api/subscriptions -Method Get | ConvertTo-Json
```

### Adicionar assinatura via API

```powershell
$body = @{ url = 'https://example.com/feed.xml' } | ConvertTo-Json
Invoke-RestMethod -Uri http://localhost:5227/api/subscriptions -Method Post -Body $body -ContentType 'application/json'
```

## Observações importantes

- A implementação atual usa armazenamento em memória: reiniciar o backend apaga as assinaturas.
- O frontend usa a URL do backend definida em `frontend\RSSFeedReader.UI\wwwroot\appsettings.json`.
- Para encerrar os servidores, pressione `Ctrl+C` no terminal onde eles estão rodando.
