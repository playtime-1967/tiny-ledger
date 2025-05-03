# Tiny Ledger API

A simple in-memory ledger system implemented in .NET 9.0. It supports account creation, deposits, withdrawals, transfers, balance inquiries, and transaction history.

---

## 🚀 Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

---

## 🏃 Running the Application

```bash
# Run on the default port (5293)
dotnet run

# Run on a custom port (e.g., 5254)
dotnet run --urls=http://localhost:5254
````

---

## 📡 API Endpoints

### ✅ Create Account

```bash
curl --location 'http://localhost:5293/api/account/create' \
--header 'Content-Type: application/json' \
--data '{
    "owner": "Saman"
}'
```

### 💰 View Balance

```bash
curl --location 'http://localhost:5293/api/account/balance/{accountId}'
```

### ➕ Deposit

```bash
curl --location 'http://localhost:5293/api/account/deposit' \
--header 'Content-Type: application/json' \
--data '{
    "toAccountId": "{accountId}",
    "amount": 5.00
}'
```

### ➖ Withdraw

```bash
curl --location 'http://localhost:5293/api/account/withdraw' \
--header 'Content-Type: application/json' \
--data '{
    "fromAccountId": "{accountId}",
    "amount": 10.00
}'
```

### 🔁 Transfer Money

```bash
curl --location 'http://localhost:5293/api/account/transfer-money' \
--header 'Content-Type: application/json' \
--data '{
    "fromAccountId": "{fromAccountId}",
    "toAccountId": "{toAccountId}",
    "amount": 1.00
}'
```

### 📜 View Transactions

```bash
curl --location 'http://localhost:5293/api/account/transactions/{accountId}'
```

---

## 📥 Postman Collection

You can import the Postman collection from the `curls.json` file in the root of this repository.

---

## 🧠 Design Assumptions & Simplifications

> Some decisions here are simplified for the assignment scope and will be discussed in follow-up interviews.

### ⚠ Simplified or Omitted Features

* No `User` entity or `userId` field added to accounts.
* External sources/destinations for transactions are not supported.
* Domain-Driven Design (DDD) elements like aggregate roots, value objects, and sub-entities were not fully implemented.
* No unit tests or interfaces (e.g., for `AccountService`).
* No read/write separation or pagination for transaction history.
* Consistency in concurrent or distributed systems is **critical** — but out of scope. In real-world systems, you would apply mechanisms such as: Database-level locks or Distributed locks at the backend/service level

---

## 🤔 Technical Assumptions & Notes

* `AccountService` is registered as a **Singleton** to preserve in-memory state (via `Dictionary<Guid, Account>`). This is **not recommended** in production.
* Validation logic for `TransactionType` uses a `switch` statement. While simple, this breaks the **Open/Closed Principle**.
* In a DDD architecture, the `Account` entity could be modeled as the **aggregate root** for its transactions.  
* Logic could be better organized by **splitting `AccountService`** into multiple services:

  * `AccountManagement`
  * `PaymentService`
  * `TransactionQueryManagement`
* API responses avoid exposing domain entities like `Transaction` directly. A mapping layer (DTOs) is recommended.
