# Objetivos do projeto

Construir um leitor simples de feeds RSS/Atom. O objetivo é demonstrar a capacidade mais básica (gerenciar uma lista de assinaturas) sem a complexidade de buscar e exibir conteúdo de feeds.

## Propósito

O app existe para demonstrar como um usuário pode construir uma lista de assinaturas para feeds RSS. Esta é uma prova de conceito focada na UI de gerenciamento de assinaturas.

## Escopo alvo (apenas MVP)

Esta é uma aplicação POC mínima para um único usuário, rodando localmente. Foi projetada para ser desenvolvida e testada no Windows, macOS ou Linux.

O MVP inclui apenas:

- Adicionar uma assinatura de feed por URL
- Exibir a lista de assinaturas na UI

Todos os outros recursos (buscar feeds, exibir itens, persistência, remover assinaturas, etc.) são adiados para Extended-MVP ou pós-MVP.

## Abordagem de entrega

O foco é desenvolvimento rápido do recurso MVP. Construa a funcionalidade mínima primeiro:

- Adicionar uma assinatura por URL
- Exibir a lista de assinaturas

Para manter o desenvolvimento rápido:

- Sem busca ou parsing de feeds para o MVP
- Sem validação de URLs de feed (assuma que o usuário fornece URLs válidas)
- Armazene assinaturas apenas em memória (abordagem mais simples)
- Mantenha a UI simples e funcional em vez de polida

## O que significa "MVP funcionando"

O MVP está completo quando:

1. Um usuário pode adicionar uma assinatura de feed colando uma URL
2. A UI exibe a lista de assinaturas atualizada

Nenhuma busca, parsing ou exibição de itens é necessária para o MVP.

## Extended-MVP (próxima fase)

Após o MVP básico funcionar, o Extended-MVP adiciona capacidades de busca e exibição de feeds:

1. Um usuário pode clicar em um botão para atualizar manualmente o feed
2. Itens do feed são exibidos (título e link como mínimo)

Teste com um feed RSS conhecido, por exemplo <https://devblogs.microsoft.com/dotnet/feed/>.

### Checklist de desenvolvimento local

Antes de testar o MVP, verifique:

- [ ] Backend roda sem erros e escuta na porta configurada
- [ ] Frontend roda sem erros e carrega no navegador
- [ ] Configuração do frontend (`wwwroot/appsettings.json`) aponta para a URL correta do backend
- [ ] CORS do backend permite a origem do frontend
- [ ] Console do DevTools do navegador não mostra erros de conexão ao carregar a página

## Melhorias futuras (pós-MVP)

Assim que o Extended-MVP estiver funcionando (gerenciamento de assinaturas + busca de feeds + exibição de itens), estes recursos podem ser adicionados:

- **Persistência**: Salvar assinaturas e itens entre sessões (requer implementação de banco de dados)
- **Remover assinaturas**: Permitir que usuários excluam feeds que não desejam mais
- **Polling em background**: Atualizar feeds automaticamente em uma programação
- **Melhor tratamento de erros**: Mostrar mensagens detalhadas para diferentes cenários de falha
- **Renderização de conteúdo**: Exibir conteúdo completo do item, não apenas título e link
- **Rastreamento lido/não lido**: Marcar itens como lidos e filtrar conforme necessário
- **Organização**: Agrupar feeds em pastas ou categorias

## Nota sobre seleção de tecnologia

Embora este MVP seja intencionalmente simples, as escolhas de tecnologia (ASP.NET Core + Blazor) devem suportar recursos prontos para produção no futuro sem exigir uma reescrita completa. A arquitetura permite adicionar persistência, operações em background e capacidades de UI aprimoradas conforme necessário.

## Como este documento se relaciona com os outros

- [AppFeatures.md](AppFeatures.md) descreve os recursos voltados ao usuário para o MVP
- [TechStack.md](TechStack.md) explica as escolhas tecnológicas e como elas suportam os objetivos do MVP