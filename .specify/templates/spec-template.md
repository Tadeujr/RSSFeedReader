# Especificação de Recurso: [NOME DO RECURSO]

**Branch do Recurso**: `[###-nome-do-recurso]`

**Criado em**: [DATA]

**Status**: Rascunho

**Entrada**: Descrição do usuário: "$ARGUMENTS"

## Cenários de Usuário e Testes *(obrigatório)*

<!--
  IMPORTANTE: As histórias de usuário devem ser PRIORIZADAS como jornadas do usuário ordenadas por importância.
  Cada história/jornada deve ser TESTÁVEL DE FORMA INDEPENDENTE — ou seja, se você implementar apenas uma delas,
  ainda assim deve existir um MVP viável (Produto Mínimo Viável) com valor.

  Atribua prioridades (P1, P2, P3, etc.) a cada história, onde P1 é a mais crítica.
  Pense em cada história como uma fatia independente de funcionalidade que pode ser:
  - Desenvolvida de forma independente
  - Testada de forma independente
  - Implantada de forma independente
  - Demonstrada aos usuários de forma independente
-->

### História de Usuário 1 - [Título Breve] (Prioridade: P1)

[Descreva essa jornada do usuário em linguagem simples]

**Por que essa prioridade**: [Explique o valor e por que ela recebe esse nível de prioridade]

**Teste Independente**: [Descreva como isso pode ser testado de forma independente — por exemplo: "Pode ser totalmente testado por [ação específica] e entrega [valor específico]"]

**Cenários de Aceitação**:

1. **Dado** [estado inicial], **quando** [ação], **então** [resultado esperado]
2. **Dado** [estado inicial], **quando** [ação], **então** [resultado esperado]

---

### História de Usuário 2 - [Título Breve] (Prioridade: P2)

[Descreva essa jornada do usuário em linguagem simples]

**Por que essa prioridade**: [Explique o valor e por que ela recebe esse nível de prioridade]

**Teste Independente**: [Descreva como isso pode ser testado de forma independente]

**Cenários de Aceitação**:

1. **Dado** [estado inicial], **quando** [ação], **então** [resultado esperado]

---

### História de Usuário 3 - [Título Breve] (Prioridade: P3)

[Descreva essa jornada do usuário em linguagem simples]

**Por que essa prioridade**: [Explique o valor e por que ela recebe esse nível de prioridade]

**Teste Independente**: [Descreva como isso pode ser testado de forma independente]

**Cenários de Aceitação**:

1. **Dado** [estado inicial], **quando** [ação], **então** [resultado esperado]

---

[Adicione mais histórias de usuário conforme necessário, cada uma com prioridade atribuída]

### Casos Limites

<!--
  AÇÃO NECESSÁRIA: O conteúdo desta seção representa espaços reservados.
  Preencha com os casos limites corretos.
-->

- O que acontece quando [condição limite]?
- Como o sistema lida com [cenário de erro]?

## Requisitos *(obrigatório)*

<!--
  AÇÃO NECESSÁRIA: O conteúdo desta seção representa espaços reservados.
  Preencha com os requisitos funcionais corretos.
-->

### Requisitos Funcionais

- **RF-001**: O sistema DEVE [capacidade específica, por exemplo: "permitir que usuários criem contas"]
- **RF-002**: O sistema DEVE [capacidade específica, por exemplo: "validar endereços de e-mail"]
- **RF-003**: Os usuários DEVEM conseguir [interação principal, por exemplo: "redefinir sua senha"]
- **RF-004**: O sistema DEVE [requisito de dados, por exemplo: "persistir preferências do usuário"]
- **RF-005**: O sistema DEVE [comportamento, por exemplo: "registrar todos os eventos de segurança"]

*Exemplo de marcação de requisitos não claros:*

- **RF-006**: O sistema DEVE autenticar usuários via [NEEDS CLARIFICATION: método de autenticação não especificado — e-mail/senha, SSO, OAuth?]
- **RF-007**: O sistema DEVE manter dados do usuário por [NEEDS CLARIFICATION: período de retenção não especificado]

### Entidades Principais *(inclua se o recurso envolver dados)*

- **[Entidade 1]**: [O que representa, atributos principais sem implementação]
- **[Entidade 2]**: [O que representa, relações com outras entidades]

## Critérios de Sucesso *(obrigatório)*

<!--
  AÇÃO NECESSÁRIA: Defina critérios de sucesso mensuráveis.
  Eles DEVEM ser independentes de tecnologia e mensuráveis.
-->

### Resultados Mensuráveis

- **CS-001**: [Métrica mensurável, por exemplo: "Usuários conseguem concluir a criação de conta em menos de 2 minutos"]
- **CS-002**: [Métrica mensurável, por exemplo: "O sistema lida com 1000 usuários simultâneos sem degradação"]
- **CS-003**: [Métrica de satisfação do usuário, por exemplo: "90% dos usuários concluem a tarefa principal na primeira tentativa"]
- **CS-004**: [Métrica de negócio, por exemplo: "Reduzir em 50% os tickets de suporte relacionados a [X]"]

## Premissas

<!--
  AÇÃO NECESSÁRIA: Defina as premissas corretas com base em valores padrão razoáveis
  escolhidos quando a descrição do recurso não especificou certos detalhes.
-->

- [Premissa sobre usuários-alvo, por exemplo: "Os usuários têm conexão estável com a internet"]
- [Premissa sobre limites de escopo, por exemplo: "Suporte mobile está fora do escopo da v1"]
- [Premissa sobre dados/ambiente, por exemplo: "O sistema de autenticação existente será reutilizado"]
- [Dependência de sistema/serviço existente, por exemplo: "Requer acesso à API existente de perfil do usuário"]
