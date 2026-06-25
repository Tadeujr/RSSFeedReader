# Contrato de API

## GET /api/subscriptions

- Descrição: Retorna a lista de assinaturas de feed em memória.
- Resposta 200 OK
- Corpo:

```json
[
  {
    "url": "https://example.com/feed.xml"
  }
]
```

## POST /api/subscriptions

- Descrição: Adiciona uma nova assinatura de feed.
- Request body:

```json
{
  "url": "https://example.com/feed.xml"
}
```

- Resposta de sucesso: 201 Created
- Corpo de sucesso:

```json
{
  "url": "https://example.com/feed.xml"
}
```

## Erros

- 400 Bad Request: campo `url` ausente ou sintaticamente inválido.
- 409 Conflict: assinatura duplicada já existe.
- 500 Internal Server Error: erro inesperado no backend.

## Observações

- O MVP não expõe nenhum endpoint de parser ou item de feed.
- O contrato foca apenas no gerenciamento de assinaturas.
