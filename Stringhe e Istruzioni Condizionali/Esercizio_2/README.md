# Esercizio 2 — Negozio di Antiquariato

## 📋 Consegna

Data un array di codici identificativi (stringhe), validare ogni codice: deve iniziare con `"ANT-"`, dopo aver rimosso eventuali spazi bianchi iniziali/finali. Usare `goto` per saltare a un'etichetta di errore o di successo.

## 🧠 Spiegazione concetti

### Perché il controllo `null` viene per primo
```csharp
if (identificativo == null)
    goto CodiceNonValido;

identificativo = identificativo.Trim();
```
Se `identificativo` fosse `null` e si chiamasse `.Trim()` **prima** di controllarlo, il programma lancerebbe una `NullReferenceException` e si fermerebbe. Il controllo null deve **sempre** precedere qualsiasi chiamata a metodo sulla stringa.

### `Trim()` — pulizia degli spazi
Rimuove gli spazi bianchi solo a **inizio e fine** stringa (non quelli in mezzo). Serve perché un codice come `" ANT-4922"` (con spazio iniziale) deve comunque essere considerato valido dopo la pulizia.

### `StartsWith("ANT-")` — verifica del prefisso
Restituisce `true`/`false` a seconda che la stringa inizi esattamente con quella sequenza di caratteri. È **case-sensitive**: `"ant-4922"` (minuscolo) risulterebbe `false`.

### `goto` e le etichette
```csharp
goto CodiceNonValido;
...
CodiceNonValido:
    Console.WriteLine(...);
    continue;

CodiceValido:
    Console.WriteLine(...);
```
- Ogni etichetta (`CodiceNonValido:`, `CodiceValido:`) è un "punto di destinazione" a cui il `goto` salta direttamente.
- `continue` dopo il blocco di errore fa ripartire il `for` dalla prossima iterazione, **saltando** l'etichetta `CodiceValido` che si trova subito sotto.
- Se tutti i controlli passano, il `goto CodiceValido` salta direttamente al messaggio di successo.

⚠️ **Nota di stile**: questo esercizio richiede esplicitamente `goto` a scopo didattico. In un contesto reale, la stessa logica si scriverebbe in modo più leggibile senza `goto`, semplicemente con un `if` negato all'inizio del ciclo:

```csharp
for (int i = 0; i < codici.Length; i++)
{
    string identificativo = codici[i];

    if (identificativo == null || identificativo.Trim() == "" || !identificativo.Trim().StartsWith("ANT-"))
    {
        Console.WriteLine($"[Indice {i}] ERRORE: codice non valido.");
        continue;
    }

    identificativo = identificativo.Trim();
    Console.WriteLine($"[Indice {i}] Codice '{identificativo}' accettato correttamente!");
}
```

## 🔍 Traccia di esecuzione con l'array di esempio

| Indice | Codice originale | Esito |
|---|---|---|
| 0 | `"ANT-4922"` | ✅ Accettato |
| 1 | `""` | ❌ Non valido (stringa vuota) |
| 2 | `"ABC-4922"` | ❌ Non valido (prefisso errato) |
| 3 | `"ANT-1522"` | ✅ Accettato |
| 4 | `"ANT-4821"` | ✅ Accettato |
| 5 | `null` | ❌ Non valido (null) |

**Risultato**: 3 codici accettati, 3 non validi.
