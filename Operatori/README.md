# C# – Esercizi su Operatori, DateTime, Classi e Array

![C#](https://img.shields.io/badge/language-C%23-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-Console%20App-512BD4?logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/status-completed-brightgreen)

Raccolta di esercizi svolti durante lo studio di C#, incentrati su operatori, gestione di date, nullable types, classi e manipolazione di array. Progetto realizzato con Visual Studio Community, usando i **top-level statements** introdotti da C# 9.

---

## 📋 Indice esercizi

1. [Esercizio Slide 1 – Tipi numerici e `typeof`](#1--tipi-numerici-e-typeof)
2. [Esercizio Slide 2 – Calcolo età e gestione errori](#2--calcolo-età-e-gestione-errori)
3. [Esercizio 2 PDF – Classe `Alieno`](#3--classe-alieno)
4. [Esercizio 3 PDF – Immutabilità delle stringhe](#4--immutabilità-delle-stringhe)
5. [Esercizio 4 PDF – Array, Range e iterazione](#5--array-range-e-iterazione)
6. [Esercizio 5 PDF – Operatori di shift](#6--operatori-di-shift)

---

## 1. 🔢 Tipi numerici e `typeof`

Dichiarazione di una variabile intera e verifica del tipo effettivo tramite `typeof`, per dimostrare che `int` corrisponde internamente a `System.Int32` (32 bit).

**Concetti applicati**: dichiarazione di variabili, operatore `typeof`, interpolazione di stringhe.

---

## 2. 📅 Calcolo età e gestione errori

Programma che chiede nome, cognome e data di nascita all'utente, calcola l'età con precisione (tenendo conto se il compleanno dell'anno corrente è già passato o no) e determina se si può prendere la patente.

**Concetti applicati**:
- `Console.ReadLine()` per l'input da tastiera
- `DateTime` e `DateTime.Parse()` per la conversione stringa → data
- Gestione degli errori con **`try/catch`** su `FormatException`, per evitare crash su input non validi
- Operatori logici (`&&`, `||`) per il calcolo preciso dell'età
- `if / else if / else` per la logica a tre rami (maggiorenne / compleanno non ancora arrivato / minorenne)

---

## 3. 👽 Classe `Alieno`

Modellazione di una classe `Alieno` tramite astrazione, con creazione di più istanze e applicazione di numerosi operatori e costrutti su di esse.

**Attributi**: `Name`, `Pianeta`, `Telefono`, `Ostile`, `Energia` (nullable, `int?`)

**Concetti applicati**:
- Costruttore parametrico
- **Nullable types** (`int?`) per gestire un attributo opzionale (energia non fornita)
- **Null-coalescing operator (`??`)** per fornire valori di default (telefono fittizio, energia a 0)
- Operatore ternario per messaggi condizionali (ostile/amico, provenienza da Marte)
- Operatore **`is`** con pattern matching per verificare il tipo a runtime
- Confronto tra stringhe con `==` (confronto per contenuto, non per riferimento)
- Metodo con valore di ritorno booleano che combina più condizioni con `&&`

> **Nota tecnica**: usando i top-level statements, la definizione della classe `Alieno` deve trovarsi **dopo** tutte le istruzioni eseguibili nel file (le istruzioni di primo livello devono precedere ogni dichiarazione di tipo) — per questo la classe si trova in fondo al file, mentre l'uso della classe avviene più in alto.

---

## 4. 🔤 Immutabilità delle stringhe

Dimostrazione pratica che i metodi delle stringhe come `ToUpper()` non modificano la stringa originale, ma restituiscono una nuova stringa — se il valore di ritorno non viene salvato, il risultato va perso.

**Concetti applicati**: immutabilità dei tipi `string`, valore di ritorno dei metodi.

---

## 5. 🐱 Array, Range e iterazione

Estrazione di porzioni di un array (prime N, ultime N, intervallo specifico) tramite l'operatore **Range (`..`)**, e stampa dei risultati sia con ciclo `for` (basato su indice) sia con `foreach` (iterazione diretta sugli elementi).

**Concetti applicati**:
- Operatore Range `[..]` per creare sotto-array
- `string.Join()` per stampare correttamente il contenuto di un array (evitando l'errore comune di concatenare `+` direttamente con un array)
- Differenza tra `for` (con indice) e `foreach` (senza indice)

---

## 6. ⚙️ Operatori di shift

Utilizzo degli operatori di shift bit a bit (`<<`, `>>`) per dimostrare la loro equivalenza aritmetica con moltiplicazione e divisione per 2.

```
16 >> 1 = 8    (16 / 2)
20 << 1 = 40   (20 * 2)
```

**Concetti applicati**: rappresentazione binaria dei numeri interi, operatori di shift.

---

## 🎯 Concetti generali ripassati in questo progetto

| Concetto | Dove viene applicato |
|---|---|
| Nullable types (`?`) | Classe `Alieno` (energia opzionale) |
| Null-coalescing (`??`) | Valori di default (telefono, energia) |
| Operatore ternario (`?:`) | Messaggi condizionali multipli |
| `try/catch` | Validazione input data di nascita |
| Pattern matching (`is`) | Verifica tipo a runtime |
| Range (`..`) | Estrazione sotto-array |
| Top-level statements | Struttura dell'intero programma |

---

## 🛠️ Come eseguire

Aprire il progetto in Visual Studio Community (o eseguire `dotnet run` da terminale nella cartella del progetto). Il programma richiede input da tastiera durante l'esecuzione (nome, cognome, data di nascita).
