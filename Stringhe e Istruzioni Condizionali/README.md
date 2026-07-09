# Pacchetto Esercizi — Stringhe e Istruzioni Condizionali (C#)

> BC Soft School Academy — Corso C# | Docente: Francesca Renne

Repository con 5 esercizi che uniscono i concetti su **istruzioni condizionali e cicli** con quelli su **stringhe e text processing**.

## 📁 Struttura del progetto

| Cartella/Progetto | Argomento | Concetti chiave |
|---|---|---|
| `Studente` | Esercizio 1 | classi, `foreach`, `string.Format`, `if-else` |
| `Negozio_Antiquariato` | Esercizio 2 | `Trim()`, `StartsWith()`, `goto`, controllo null |
| `Acquario` | Esercizio 3 | matrici bidimensionali, cicli annidati, `return` per uscita anticipata |
| `Changes` | Esercizio 4 | `Contains()`, `Replace()`, `int.Parse()`, `Math.Pow()` |
| `FiltriAcquario` | Esercizio 5 | parametri `out` multipli, valore di ritorno `bool`, funzioni locali |

## 🎯 Concetti trasversali affrontati

### Dal modulo "Istruzioni condizionali e cicli"
- `if / else if / else` per prendere decisioni in base a condizioni (Esercizio 1, 5)
- `for` e cicli annidati per scorrere array e matrici (Esercizio 3, 5)
- `foreach` per scorrere collezioni senza gestire manualmente un indice (Esercizio 1)
- `goto` e perché va usato con cautela — utile solo in casi specifici e didattici (Esercizio 2)
- `return` come alternativa pulita al `goto` per uscire da un metodo (Esercizio 3)

### Dal modulo "Stringhe e Text Processing"
- Immutabilità delle stringhe e conseguenze pratiche (es. serve sempre riassegnare il risultato di `Replace`/`Trim`)
- Metodi di ricerca e verifica: `Contains()`, `StartsWith()`
- Metodi di pulizia: `Trim()`
- Metodi di trasformazione: `Replace()`, `ToUpper()`
- Conversione stringa → numero: `int.Parse()`
- Formattazione output: `string.Format()` con specificatori (`{1:F2}`)

### Concetti C# più generali toccati negli esercizi
- Parametri `out` per restituire più valori da un unico metodo (Esercizio 5)
- Array bidimensionali `[,]` e relative diagonali (Esercizio 3)
- Funzioni locali (dichiarate dentro `Main`) vs metodi di classe separati (Esercizio 5)
- Controllo dei valori `null` **prima** di chiamare metodi su una stringa, per evitare `NullReferenceException`

## 🐛 Errori comuni incontrati (e utili da ricordare per l'orale)

Durante lo svolgimento sono emersi diversi bug tipici — riportarli è utile proprio per prepararsi a spiegarli a voce:

1. **Chiamare un metodo su una variabile `null` prima di controllarla** → `NullReferenceException`. Il controllo `if (x == null)` va sempre fatto *prima* di `x.Trim()` o simili.
2. **Refusi nei nomi di proprietà/metodi** (es. `Lenght` invece di `Length`, `IniziaCon` invece di `StartsWith`) → il compilatore non riconosce il membro e dà errore.
3. **`if` senza parentesi graffe** → si applica solo alla riga immediatamente successiva; se dopo ci sono più istruzioni da eseguire condizionalmente, servono le `{ }`.
4. **Nomi di variabili incoerenti tra dichiarazione e uso** (es. dichiarare `tempIniziali` e poi richiamare `temperature` in un altro scope) → il compilatore non trova la variabile.
5. **Annidare un metodo dentro un altro per errore** (es. `Main` scritto per sbaglio dentro un altro metodo) → il programma non ha un punto di ingresso valido.
6. **`Replace()` chiamato sulla stringa sbagliata**, rischiando di cancellare tutto il contenuto invece di rimuovere solo una parte.

## ▶️ Come eseguire i progetti

Ogni cartella è un progetto/`namespace` indipendente con il proprio `Main`. Da Visual Studio: aprire la soluzione, impostare il progetto desiderato come "progetto di avvio" (*Set as Startup Project*) ed eseguire con F5.

---

📎 Consulta il README specifico di ogni esercizio nella rispettiva cartella per la spiegazione dettagliata del codice.
