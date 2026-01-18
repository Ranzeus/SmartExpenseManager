# 📝 Exemplos de Requisições - Smart Expense Manager

## 🔌 Base URL
```
http://localhost:5000
```

## 📋 IDs Seed (Do banco de dados)

### Users
```
John Doe: f96c7a1d-ec3f-4235-836c-6c48d81de1c1
```

### Categories
```
Food: 841a1260-d6f3-4be3-ada9-2295f234bf1d
Transport: 0480d2a0-b85a-433b-9a00-7ba351215dcf
Entertainment: 8a5780cd-901b-4d7a-90c9-a121be6f1f31
```

### LedgerAccounts
```
Cash: 125a0224-72fb-46d7-be6e-c077f3174264
Bank Account: e3223432-0bf3-4f5d-ac85-606617dc6add
```

---

## ✅ Criar Expense (POST)

### Endpoint
```
POST /api/expenses
Content-Type: application/json
```

### Exemplo 1: Despesa de Alimentação em Dinheiro
```json
{
  "amount": 45.50,
  "currency": "USD",
  "date": "2026-01-18T14:30:00Z",
  "categoryId": "841a1260-d6f3-4be3-ada9-2295f234bf1d",
  "ledgerAccountId": "125a0224-72fb-46d7-be6e-c077f3174264",
  "userId": "f96c7a1d-ec3f-4235-836c-6c48d81de1c1",
  "description": "Almoço no restaurante"
}
```

### Exemplo 2: Despesa de Transporte no Banco
```json
{
  "amount": 25.00,
  "currency": "USD",
  "date": "2026-01-18T09:15:00Z",
  "categoryId": "0480d2a0-b85a-433b-9a00-7ba351215dcf",
  "ledgerAccountId": "e3223432-0bf3-4f5d-ac85-606617dc6add",
  "userId": "f96c7a1d-ec3f-4235-836c-6c48d81de1c1",
  "description": "Passagem de ônibus"
}
```

### Exemplo 3: Despesa de Entretenimento (sem descrição)
```json
{
  "amount": 15.99,
  "currency": "USD",
  "date": "2026-01-18T20:00:00Z",
  "categoryId": "8a5780cd-901b-4d7a-90c9-a121be6f1f31",
  "ledgerAccountId": "125a0224-72fb-46d7-be6e-c077f3174264",
  "userId": "f96c7a1d-ec3f-4235-836c-6c48d81de1c1",
  "description": null
}
```

---

## 🧪 Testar com cURL

```bash
curl -X POST http://localhost:5000/api/expenses \
  -H "Content-Type: application/json" \
  -d '{
    "amount": 45.50,
    "currency": "USD",
    "date": "2026-01-18T14:30:00Z",
    "categoryId": "841a1260-d6f3-4be3-ada9-2295f234bf1d",
    "ledgerAccountId": "125a0224-72fb-46d7-be6e-c077f3174264",
    "userId": "f96c7a1d-ec3f-4235-836c-6c48d81de1c1",
    "description": "Almoço no restaurante"
  }'
```

---

## 📌 Campos Obrigatórios

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `amount` | decimal | Valor da despesa (ex: 45.50) |
| `currency` | string | Código da moeda (ex: USD, BRL, EUR) |
| `date` | datetime | Data da despesa (formato ISO 8601) |
| `categoryId` | uuid | ID da categoria (veja lista acima) |
| `ledgerAccountId` | uuid | ID da conta contábil (veja lista acima) |
| `userId` | uuid | ID do usuário (veja lista acima) |
| `description` | string? | Descrição opcional da despesa |

---

## 📊 Resposta Esperada (201 Created)
```
Location: /api/expenses?id={expenseId}
Body: null
```

---

## 🔍 Swagger
Acesse: http://localhost:5000/swagger/index.html
