# Modelo de Dados

## Entidade: Assinatura de Feed

- `Url` (string): URL do feed RSS/Atom. Obrigatória. Deve ser válida sintaticamente.
- `AddedAt` (DateTime?): Opcional, pode registrar quando a assinatura foi adicionada.
- `Id` (string ou GUID): Opcional para identificação interna, mas não exigido no MVP.

## Regras de validação

- `Url` não pode estar vazia.
- `Url` deve obedecer a um formato de URL válido.
- `Url` não pode duplicar uma assinatura já existente.

## Armazenamento

- A lista de assinaturas será mantida em memória no backend.
- O frontend obtém a lista via `GET /api/subscriptions`.
- Novas assinaturas são enviadas via `POST /api/subscriptions`.

## Transições de estado

1. Estado inicial: lista de assinaturas vazia.
2. Ao adicionar uma assinatura válida:
   - O backend adiciona a URL em memória.
   - O frontend atualiza a lista exibida.
3. A lista de assinaturas é exibida para o usuário sem persistir entre reinicializações.
