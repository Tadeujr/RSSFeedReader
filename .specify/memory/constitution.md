<!--
Sync Impact Report
- Version change: template placeholder → 1.0.0
- Modified principles: none (initial constitution)
- Added sections: Technical Constraints, Development Workflow
- Removed sections: none
- Templates requiring updates: .specify/templates/plan-template.md — ✅ reviewed, no change required; .specify/templates/spec-template.md — ✅ reviewed, no change required; .specify/templates/tasks-template.md — ✅ reviewed, no change required
- Follow-up TODOs: none
-->

# Constituição do RSS Feed Reader

## Princípios Centrais

### I. Segurança por padrão
Todos os recursos que recebem entrada do usuário, chamam serviços externos ou exibem conteúdo remoto DEVEM validar as entradas e rejeitar dados malformados antes que eles cheguem à lógica da aplicação. Os manipuladores da API DEVEM retornar respostas de erro claras e NÃO DEVEM expor detalhes internos da implementação, segredos ou rastros de pilha. O conteúdo de feeds exibido na interface DEVEM ser tratado como não confiável e NÃO DEVE ser renderizado como HTML bruto no MVP.

### II. Manutenibilidade por meio de limites claros
As responsabilidades do frontend e do backend DEVEM permanecer separadas: a interface cuida da interação e da apresentação, enquanto a API cuida dos dados de assinatura e das futuras operações de feed. A lógica compartilhada DEVE ser centralizada em um único lugar, e a lógica duplicada DEVE ser evitada. Novos recursos DEVEM ser implementados com componentes, serviços e endpoints pequenos, com nomes claros, fáceis de entender e estender.

### III. Qualidade de código por meio de design testável
Todo comportamento voltado ao usuário DEVE ser implementado de forma que possa ser verificado localmente e, quando for prático, por meio de testes automatizados. Fluxos críticos, como adicionar assinaturas, retornar listas de assinaturas e lidar com rotas, DEVEM ser cobertos por pelo menos um teste automatizado ou por uma verificação manual explícita antes que o trabalho seja considerado concluído. Código que adiciona complexidade sem um requisito claro NÃO DEVE ser introduzido.

### IV. Entrega priorizando o MVP
O projeto DEVE priorizar o escopo do MVP de adicionar uma URL de assinatura e exibir a lista de assinaturas. Recursos fora do MVP, incluindo busca de feeds, persistência e processamento em segundo plano, NÃO DEVEM ser introduzidos antes que o fluxo principal funcione de ponta a ponta. Qualquer expansão além do MVP DEVE ser registrada como uma etapa separada e NÃO DEVE comprometer a experiência atual do usuário.

### V. Configuração explícita e confiabilidade local
O desenvolvimento local DEVE usar configuração explícita para URLs da API, portas e rotas. Novos valores de configuração DEVEM ser documentados no local em que são usados, e a aplicação DEVE ser verificável sem pressupostos ocultos sobre a configuração do ambiente local. A equipe DEVE confirmar que o frontend, o backend e a configuração de CORS funcionem em conjunto antes de considerar um recurso concluído.

## Restrições Técnicas

A solução DEVE usar um backend ASP.NET Core Web API e um frontend Blazor WebAssembly. O MVP DEVE usar armazenamento simples em memória para assinaturas e DEVE evitar parsing de feeds ou operações de rede até que o fluxo principal de assinatura esteja funcionando. Futuras mudanças que adicionem busca de feeds, persistência ou processamento em segundo plano DEVEM ser introduzidas por meio de serviços dedicados e DEVEM preservar a separação existente entre as responsabilidades da interface e da API.

## Fluxo de Trabalho de Desenvolvimento

Todo trabalho neste repositório DEVE ser revisado de acordo com estes princípios antes da conclusão. Alterações que afetem contratos da API, rotas da interface ou configuração DEVEM atualizar a documentação relevante. Antes de um recurso ser considerado concluído, a equipe DEVE verificar a construção local, confirmar que o fluxo principal funciona e garantir que não haja conflitos de roteamento ou páginas de demonstração do template restantes na interface.

## Governança

Esta constituição rege todas as decisões de implementação para o projeto RSS Feed Reader. Qualquer alteração DEVE documentar a mudança, explicar a justificativa e atualizar os artefatos de planejamento ou especificação afetados. A versionamento segue regras semânticas: mudanças MAJOR removem ou redefinem a governança central; mudanças MINOR adicionam ou expandem materialmente um princípio; mudanças PATCH esclarecem a redação ou melhoram orientações não semânticas. As revisões de conformidade DEVEM confirmar que o novo trabalho está alinhado com os princípios de segurança, manutenibilidade e qualidade de código antes de ser aceito.

**Versão**: 1.0.0 | **Ratificada**: 2026-06-25 | **Última alteração**: 2026-06-25
