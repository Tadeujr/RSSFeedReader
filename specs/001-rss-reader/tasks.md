# Tarefas: MVP RSS Reader

**Input**: Documentos de design de `specs/001-rss-reader/`

**Pré-requisitos**: `plan.md`, `spec.md`, `research.md`, `data-model.md`, `contracts/api.md`

## Fase 1: Configuração (Infraestrutura compartilhada)

- [X] T001 Criar a estrutura do projeto de backend em `backend/RSSFeedReader.Api/`
- [X] T002 Criar a estrutura do projeto de frontend Blazor WebAssembly em `frontend/RSSFeedReader.UI/`
- [X] T003 [P] Inicializar o projeto ASP.NET Core Web API em `backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj`
- [X] T004 [P] Inicializar o projeto Blazor WebAssembly em `frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj`
- [X] T005 [P] Criar o arquivo de configuração de API do frontend em `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`
- [X] T006 [P] Criar o arquivo `backend/RSSFeedReader.Api/Program.cs` e configurar CORS para permitir o frontend

---

## Fase 2: Fundacional (Pré-requisitos bloqueantes)

- [X] T007 Criar o modelo `Subscription` em `backend/RSSFeedReader.Api/Models/Subscription.cs`
- [X] T008 Criar o DTO `SubscriptionCreateRequest` em `backend/RSSFeedReader.Api/Models/SubscriptionCreateRequest.cs`
- [X] T009 Criar o serviço `SubscriptionService` em `backend/RSSFeedReader.Api/Services/SubscriptionService.cs` com lista em memória
- [X] T010 Implementar a lógica de validação de URL sintática e de duplicação no serviço `backend/RSSFeedReader.Api/Services/SubscriptionService.cs`
- [X] T011 Criar o controller `SubscriptionsController` em `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` com endpoints `GET /api/subscriptions` e `POST /api/subscriptions`
- [X] T012 Configurar a injeção de dependência do serviço `SubscriptionService` em `backend/RSSFeedReader.Api/Program.cs`
- [X] T013 Criar o serviço de API no frontend em `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs` para chamar `GET /api/subscriptions` e `POST /api/subscriptions`

---

## Fase 3: História de Usuário 1 - Adicionar uma assinatura de feed (Prioridade: P1)

**Objetivo**: Permitir que o usuário cole uma URL de feed, valide a sintaxe localmente, envie a assinatura ao backend e veja a assinatura adicionada na lista.

**Teste independente**: Abrir a página de assinaturas, inserir uma URL válida, confirmar a adição e verificar que a lista é atualizada imediatamente.

- [X] T014 [US1] Criar a página principal de assinaturas em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T015 [P] [US1] Implementar o formulário de URL de feed em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T016 [P] [US1] Implementar a validação de URL vazia e sintaticamente inválida no frontend em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T017 [US1] Implementar a chamada `POST /api/subscriptions` no frontend em `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs`
- [X] T018 [US1] Atualizar a lista de assinaturas na página após a adição bem-sucedida em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T019 [US1] Exibir mensagens de erro simples em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` para URLs vazias, inválidas ou duplicadas

---

## Fase 4: História de Usuário 2 - Visualizar a lista de assinaturas (Prioridade: P2)

**Objetivo**: Exibir todas as assinaturas adicionadas ao carregar ou atualizar a página, de forma simples e imediata.

**Teste independente**: Abrir a aplicação após várias assinaturas já terem sido adicionadas e verificar que a lista é exibida corretamente.

- [ ] T020 [US2] Implementar o carregamento inicial da lista de assinaturas em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T021 [P] [US2] Implementar `GET /api/subscriptions` no frontend em `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs`
- [ ] T022 [US2] Exibir a lista de assinaturas no frontend em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T023 [US2] Garantir que a lista atualizada permaneça disponível após recarregar a página em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T024 [US2] Ajustar a interface para evitar duplicação visual de assinaturas em `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`

---

## Fase 5: Polimento e preocupações transversais

**Objetivo**: Finalizar o MVP com clareza, tratamento de erros e documentação mínima.

- [ ] T025 [P] Atualizar `specs/001-rss-reader/quickstart.md` com os passos finais de validação do MVP
- [ ] T026 [P] Revisar `specs/001-rss-reader/contracts/api.md` para garantir que os endpoints documentados correspondem à implementação
- [ ] T027 Melhorar as mensagens de erro do backend em `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [ ] T028 Revisar o arquivo `frontend/RSSFeedReader.UI/wwwroot/appsettings.json` para garantir que a URL base da API está correta
- [ ] T029 [P] Verificar se não há páginas de demonstração restantes no frontend que causem conflitos de rota em `frontend/RSSFeedReader.UI/Pages/`

---

## Dependências e ordem de execução

- `T001` deve ser concluída antes da maioria das tarefas de configuração.
- `T002` é paralela a `T001` e à criação do frontend.
- `T003`, `T004`, `T005` e `T006` são paralelizáveis entre si após a estrutura básica existir.
- A Fase 2 depende da conclusão da Fase 1.
- As histórias de usuário (`T014` em diante) dependem da Fase 2 estar concluída.
- A Fase 5 pode ser iniciada após a Fase 2 estar pronta e deve ser concluída depois que as histórias principais forem implementadas.

## Oportunidades de execução paralela

- Configuração de backend e frontend pode ocorrer em paralelo (`T003`, `T004`, `T005`, `T006`).
- A criação de modelos e DTOs no backend (`T007`, `T008`) pode ocorrer em paralelo com a criação do serviço e do controller (`T009`, `T011`).
- A implementação do serviço de API no frontend (`T013`) pode ocorrer em paralelo com a criação da página de assinaturas (`T014`).
- A validação de URL e a lógica de atualização de lista no frontend (`T016`, `T018`) podem ser desenvolvidas em paralelo com a implementação da chamada POST (`T017`).
- A documentação e a revisão de contrato (`T025`, `T026`, `T029`) podem ser feitas enquanto a implementação principal avança.

## Critérios de teste independentes por história

- US1: A página de assinaturas deve permitir inserir uma URL, enviar a assinatura e atualizar a lista imediatamente.
- US2: A página deve carregar as assinaturas existentes e mostrar a lista corretamente após abertura ou atualização.

## Escopo MVP sugerido

- Entrega mínima: completar a Fase 1, a Fase 2 e a Fase 3 (História de Usuário 1).
- A história US1 é o núcleo do MVP: adicionar assinaturas e ver a lista atualizada imediatamente.
- US2 é a extensão imediata que garante a exibição da lista ao carregar a página.

## Validação de formato

- Todas as tarefas usam `- [ ]`.
- Todas as tarefas incluem `T###`.
- As tarefas de histórias de usuário incluem o rótulo `[US1]` ou `[US2]`.
- As tarefas de infraestrutura e polimento não incluem rótulos de história.
