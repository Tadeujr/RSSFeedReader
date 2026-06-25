# Pesquisa: MVP RSS Reader

## Decisões

- Usar backend ASP.NET Core Web API e frontend Blazor WebAssembly.
- Manter armazenamento em memória para assinaturas.
- Validar apenas a sintaxe da URL localmente, sem checagem HTTP remota.

## Justificativas

- Os documentos de stakeholder confirmam a arquitetura ASP.NET Core + Blazor para o MVP e a necessidade de entrega rápida do gerenciamento de assinaturas.
- A especificação do recurso limita o MVP a adicionar assinaturas e exibir a lista, sem busca ou parsing de feeds.
- A validação de sintaxe atende aos casos de uso de rejeitar URLs vazias ou malformadas sem adicionar dependências de rede.

## Alternativas consideradas

- Validação de URL com requisição HTTP: rejeitada porque gera dependência de rede e foge do escopo do MVP.
- Persistência local no MVP: rejeitada pela exigência explícita de apenas armazenamento em memória.
- Parser RSS/Atom no MVP: rejeitado pelo requisito RF-005 e pelos objetivos do MVP.
