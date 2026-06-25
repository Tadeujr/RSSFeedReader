# Pilha de tecnologia para o Leitor de Feed RSS

Nosso leitor de feed RSS usará um backend de API Web ASP.NET Core e um frontend Blazor WebAssembly. Essa combinação permite um desenvolvimento rápido do MVP, ao mesmo tempo em que suporta melhorias futuras preparadas para produção.

## Por que ASP.NET Core Web API + Blazor WebAssembly?

Construir um leitor de feed RSS com um backend de **ASP.NET Core Web API** e um frontend de **Blazor WebAssembly** oferece várias vantagens:

1. **Desenvolvimento rápido**: Ambas as tecnologias funcionam bem juntas com configuração mínima, permitindo um desenvolvimento rápido da demonstração.

2. **Separação de responsabilidades**: O backend cuida do gerenciamento de dados e, no Extended-MVP, das operações de feed, enquanto o frontend se concentra na interação do usuário.

3. **Multiplataforma**: Tanto o ASP.NET Core quanto o Blazor são multiplataforma, permitindo que a aplicação seja executada no Windows, macOS e Linux.

4. **Complexidade incremental**: Comece com o gerenciamento simples de assinaturas (MVP), depois adicione a recuperação de feeds (Extended-MVP) e, por fim, adicione persistência e recursos avançados.

5. **Arquitetura preparada para o futuro**: Embora o MVP seja mínimo (apenas o gerenciamento da lista de assinaturas), essa arquitetura suporta a adição de:

   - Recuperação e análise de feeds (`System.ServiceModel.Syndication`)
   - Persistência de banco de dados (EF Core + SQLite)
   - Processamento em segundo plano (`BackgroundService` para polling)
   - Recursos avançados (ler/não lido, pastas, etc.)

6. **Código compartilhado**: O Blazor WebAssembly usa C#, permitindo o compartilhamento de código entre frontend e backend, se necessário.

## Responsabilidades

Para o MVP (apenas gerenciamento de assinaturas):

**O backend** é responsável por:

- Expor uma API para adicionar assinaturas
- Armazenar assinaturas na memória
- Retornar a lista de assinaturas

**O frontend** é responsável por:

- Interface de gerenciamento de assinaturas (campo de entrada + botão de adicionar)
- Exibir a lista de assinaturas

Para o Extended-MVP (adição da recuperação de feeds):

**O backend** adiciona:

- Recuperar e analisar feeds RSS/Atom quando solicitado
- Retornar os itens do feed para a interface

**O frontend** adiciona:

- Botão de atualização manual
- Exibir itens (título e link como mínimo)
- Mensagens básicas de erro

## Abordagem de implementação priorizando o MVP

Para entregar o MVP rapidamente:

**MVP (apenas gerenciamento de assinaturas):**

- **Armazenamento**: Usar armazenamento em memória (List<string> ou modelo simples). As assinaturas são perdidas quando o aplicativo é encerrado.
- **Sem operações de feed**: Sem cliente HTTP, sem biblioteca de análise e sem recuperação de feeds
- **Foco**: Interface básica e comunicação com a API (adicionar assinatura, obter lista de assinaturas)

**Extended-MVP (adicionar recuperação de feeds):**

- **Análise**: Adicionar `System.ServiceModel.Syndication` para análise básica de RSS/Atom
- **Cliente HTTP**: Adicionar HttpClient para buscar feeds
- **Atualização**: Apenas manual — sem polling ou agendamento em segundo plano
- **Tratamento de erros**: Mensagens simples de "falha ao carregar", sem diagnósticos detalhados
- **Exibição de conteúdo**: Apenas texto simples (título + link), sem necessidade de renderização HTML

Essa abordagem incremental torna o desenvolvimento extremamente rápido, mantendo a arquitetura limpa para melhorias futuras.

## Desenvolvimento local

### Inicialização do projeto Blazor

Ao criar um novo projeto Blazor WebAssembly a partir do template, o projeto inclui páginas de demonstração que devem ser removidas para evitar conflitos com os recursos do MVP.

**⚠️ CRÍTICO: Essa limpeza deve ser concluída na Fase 2 (Fundamental) e VERIFICADA antes de qualquer implementação de recurso de interface. Erros de execução causados por uma limpeza incompleta desperdiçarão tempo de desenvolvimento.**

**Etapas obrigatórias de limpeza:**

1. **Remover as páginas de demonstração do template** de `frontend/[ProjectName].UI/Pages/`:
   - Excluir `Home.razor` (conflita com a rota raiz)
   - Excluir `Counter.razor` (página de demonstração)
   - Excluir `Weather.razor` (página de demonstração)

2. **Atualizar o menu de navegação** em `frontend/[ProjectName].UI/Layout/NavMenu.razor`:
   - Remover links de navegação para as páginas de demonstração removidas
   - Atualizar os itens do menu para refletir apenas os recursos do MVP
   - Alterar o texto do link de navegação raiz para combinar com a página inicial (por exemplo, "Subscriptions")

3. **Verificar as rotas**:
   - Garantir que apenas UMA página use a diretiva `@page "/"` (sua página principal do MVP)
   - Todas as outras páginas devem usar rotas exclusivas (por exemplo, `@page "/settings"`)

4. **Verificar a conclusão da limpeza** antes de prosseguir com a implementação:

   ```powershell
   # Listar todas as páginas Razor — deve mostrar APENAS as páginas do MVP (por exemplo, NotFound.razor, Subscriptions.razor)
   Get-ChildItem frontend/[ProjectName].UI/Pages/ -Filter *.razor | Select-Object Name
   ```

   **PARADA: Não prossiga com a implementação de recursos até que:**
   - ✗ Home.razor tenha sido REMOVIDA
   - ✗ Counter.razor tenha sido REMOVIDA
   - ✗ Weather.razor tenha sido REMOVIDA
   - ✓ Restem apenas as páginas do seu MVP

5. **Testar conflitos de roteamento imediatamente** após a limpeza:

   ```powershell
   # Build limpo para remover assemblies em cache
   dotnet clean frontend/[ProjectName].UI/[ProjectName].UI.csproj
   dotnet build frontend/[ProjectName].UI/[ProjectName].UI.csproj

   # Iniciar o frontend para verificar se não há erros de roteamento
   dotnet run --project frontend/[ProjectName].UI
   ```

   Acesse a URL do frontend em seu navegador. Se você vir um erro de "ambiguous route" no console do navegador (Ferramentas do desenvolvedor, F12), a limpeza está incompleta. **Corrija o problema antes de implementar qualquer recurso.**

**Por que isso é importante:**

Os templates do Blazor incluem páginas de demonstração com rotas pré-configuradas. Se você criar novas páginas com as mesmas rotas (especialmente a rota raiz `/`), encontrará **exceções de rota ambígua** em tempo de execução. A mensagem de erro será semelhante a:

```
System.InvalidOperationException: The following routes are ambiguous:
'' in '[ProjectName].UI.Pages.Home'
'' in '[ProjectName].UI.Pages.YourFeature'
```

Esses erros só aparecem em tempo de execução depois que você já implementou recursos, o que torna a depuração cara. Os passos de verificação acima detectam esse problema imediatamente durante a limpeza da Fase 2, antes de qualquer trabalho de implementação.

Limpar as páginas do template antes de implementar os recursos do MVP evita esses conflitos e garante uma estrutura de projeto limpa, focada nos requisitos de negócio.

### Configuração de portas

A API do backend e a interface do frontend rodam em portas localhost separadas. **A consistência das portas é crítica** — elas devem ser coordenadas em três locais:

1. **Porta do backend** (definida em `backend/RSSFeedReader.Api/Properties/launchSettings.json`):

   - Padrão: `http://localhost:5151`
   - Este é o local onde a API escuta as requisições

2. **Porta do frontend** (definida em `frontend/RSSFeedReader.UI/Properties/launchSettings.json`):

   - Padrão: `http://localhost:5213`
   - Este é o local onde o aplicativo Blazor é executado

3. **URL base da API** (configurada em `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`):

   - Deve corresponder à porta do backend do passo 1
   - Exemplo: `{"ApiBaseUrl": "http://localhost:5151/api/"}`

4. **Política CORS** (configurada em `backend/RSSFeedReader.Api/Program.cs`):

   - Deve permitir a porta do frontend do passo 2
   - Exemplo: `.WithOrigins("http://localhost:5213", "https://localhost:7025")`

### Melhores práticas de configuração

- **Frontend Program.cs**: Ler a URL da API a partir da configuração, em vez de codificar:

  ```csharp
  var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5151/api/";
  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
  ```

- **CORS do backend**: Permitir as portas reais do frontend a partir do launchSettings.json

- **Configuração para testes**: Antes de testar, verificar:

  1. O backend está em execução e acessível na porta configurada
  2. O arquivo appsettings.json do frontend aponta para a porta correta do backend
  3. O CORS permite a origem do frontend

**Para o MVP:** Testar adicionando URLs de assinatura e verificando se elas aparecem na lista.

**Para o Extended-MVP:** Testar com um feed conhecido e funcional, como <https://devblogs.microsoft.com/dotnet/feed/>

## Melhorias futuras (pós-MVP)

Quando estiver pronto para expandir além da demonstração básica, essa arquitetura suporta:

- **Persistência de banco de dados**: Adicionar EF Core + SQLite para armazenar assinaturas e itens entre sessões
- **Polling em segundo plano**: Implementar `BackgroundService` para atualizar feeds automaticamente em um intervalo
- **Sanitização de HTML**: Adicionar a biblioteca `HtmlSanitizer` para exibir conteúdo rico dos feeds com segurança
- **Descoberta de feed a partir de site**: Usar `HtmlAgilityPack` para localizar URLs de feed a partir de links de sites
- **Melhor tratamento de erros**: Implementar lógica de retry, timeouts e mensagens de erro detalhadas
- **Testes**: Adicionar testes unitários e de integração usando xUnit
- **Otimização**: Implementar cache HTTP (ETag/Last-Modified), deduplicação e melhorias de desempenho

## Resumo

O ASP.NET Core Web API com Blazor WebAssembly oferece um caminho simples para construir o leitor de feed RSS de forma incremental:

- **MVP**: Apenas gerenciamento de assinaturas (adicionar + listar) — extremamente simples, sem operações de feed
- **Extended-MVP**: Adicionar recuperação de feeds e exibição de itens — ainda simples, com armazenamento em memória e atualização manual
- **Futuro**: Adicionar persistência, processamento em segundo plano e recursos avançados

A arquitetura foi intencionalmente mantida minimalista para permitir um desenvolvimento rápido, enquanto as escolhas tecnológicas suportam a adição de recursos prontos para produção mais tarde, sem exigir uma reescrita completa.
