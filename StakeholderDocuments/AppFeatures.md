# Recursos do aplicativo

Este leitor de RSS demonstra o gerenciamento de assinaturas como a base para um aplicativo leitor de feeds.

## Escopo do MVP (versão prova de conceito)

O MVP demonstra a funcionalidade mínima viável: gerenciar uma lista de assinaturas.

Para o MVP, o app DEVE:

- Permitir que um usuário adicione uma assinatura de feed colando uma URL do feed
- Exibir a lista de assinaturas na interface

Para o MVP, o app PODE:

- Armazenar dados apenas em memória (os dados são perdidos quando o app fecha)
- Aceitar qualquer URL sem validação (assumir URLs válidas de RSS/Atom)
- Exibir assinaturas em um formato simples de lista

## Comportamento do MVP

O MVP segue regras simples:

- Usuários podem adicionar assinaturas inserindo uma URL
- A lista de assinaturas é atualizada imediatamente quando uma assinatura é adicionada
- Sem busca, parsing ou validação de feed
- Sem necessidade de tratamento de erros (sem operações de rede)

## Recursos do Extended-MVP

Após o MVP básico (gerenciamento de assinaturas) estar funcionando, o Extended-MVP adiciona busca e exibição de feeds:

- **Atualização manual**: Usuários podem clicar em "refresh" para buscar o conteúdo do feed
- **Exibição de itens**: Mostrar itens com título e link
- **Tratamento básico de erros**: Mostrar "Failed to load feed" se algo der errado
- **Sem polling automático**: Apenas atualização manual, sem atualizações em segundo plano

## Recursos pós-MVP

Após desenvolver um Extended-MVP bem-sucedido, os seguintes recursos podem ser considerados para versões futuras:

### Melhorias essenciais

- **Persistência**: Armazenar assinaturas e itens em um banco de dados para que permaneçam disponíveis após reiniciar o app
- **Remover assinaturas**: Permitir que usuários excluam feeds
- **Melhor exibição de itens**: Mostrar resumos/conteúdo dos itens, não apenas títulos
- **Ordenação do mais novo primeiro**: Exibir itens em ordem cronológica

### Capacidades adicionais

- **Polling em background**: Atualizar feeds automaticamente em uma programação
- **Rastreamento lido/não lido**: Marcar itens como lidos e filtrar por status
- **Descoberta site-para-feed**: Permitir que usuários colem uma URL de site e encontrar automaticamente seu feed RSS
- **Pastas/organização**: Agrupar feeds em categorias
- **Melhor tratamento de erros**: Mostrar mensagens de erro específicas (feed movido, acesso negado, XML malformado, etc.)
- **Desduplicação**: Garantir que o mesmo item não seja armazenado múltiplas vezes
- **Renderização HTML**: Exibir com segurança conteúdo rico dos feeds

### Notas práticas para desenvolvedores

Para o MVP (somente gerenciamento de assinaturas):

- Use armazenamento simples em memória (List em C#)
- Ainda não há necessidade de bibliotecas de parsing de feed
- Nenhum cliente HTTP necessário para o MVP
- Foque na UI básica e no gerenciamento de estado

Para o Extended-MVP (adicionar busca de feeds):

- Use `System.ServiceModel.Syndication` para parsing
- Teste com feeds conhecidos e funcionando (ex.: <https://devblogs.microsoft.com/dotnet/feed/>)
- Evite casos complexos de parsing — trate apenas formatos básicos RSS/Atom

## Recursos adicionais (longo prazo)

Se o app evoluir além de uma demonstração básica, estes recursos podem ser considerados:

- **Busca e filtragem**: Encontrar itens por palavra-chave, filtrar por data ou categoria
- **Importação/exportação OPML**: Transferir assinaturas entre leitores de feeds
- **Organização avançada**: Tags, itens salvos, prioridades
- **Sincronização entre dispositivos**: Compartilhar assinaturas e estado de leitura entre dispositivos
- **Notificações**: Alertar sobre novos itens de feeds importantes
- **Integrações**: Compartilhar por e-mail, ferramentas de chat ou serviços de leitura posterior
- **Leitura offline**: Cache do conteúdo completo para leitura offline
- **Apps móveis**: Aplicativos nativos para celulares e tablets