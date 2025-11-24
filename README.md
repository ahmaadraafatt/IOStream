# C# Advanced – Streams, IDisposable Pattern & Decorator

This repository contains several small C# examples designed to illustrate
advanced .NET concepts related to resource management, file I/O, and 
stream decoration.

---

## 📌 1. IDisposable Pattern – `CurrencyService`

A custom service that uses an internal `HttpClient` and implements the full
IDisposable pattern (including finalizer, Dispose(bool), and suppression of finalization).

The project demonstrates four recommended ways of handling disposable objects:

- Manual disposal (not recommended)
- try / catch / finally
- using declaration (C# 8+)
- using block

The service also includes a simple real HTTP request:
```csharp
GerCurrencies()
