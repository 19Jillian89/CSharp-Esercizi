# C# – Esercizi Base: Conversioni, Tipi di Dato e Classi

![C#](https://img.shields.io/badge/language-C%23-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-Console%20App-512BD4?logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/status-completed-brightgreen)

Raccolta di esercizi introduttivi su C#, incentrati su conversioni di tipo, tipi di dato primitivi, stringhe, individuazione di errori comuni e una prima classe completa (`Cinema`). Progetto realizzato con Visual Studio Community, usando i **top-level statements** di C# 9+.

---

## 📋 Indice esercizi

1. [Esercizio 1 – Conversioni tra tipi](#1--conversioni-tra-tipi)
2. [Esercizio 2 – I tipi di dato](#2--i-tipi-di-dato)
3. [Esercizio 3 – Stringhe](#3--stringhe)
4. [Esercizio 4 – Trova gli errori](#4--trova-gli-errori)
5. [Esercizio 5 – Classe `Cinema`](#5--classe-cinema)

---

## 1. 🔄 Conversioni tra tipi

Dimostrazione pratica delle conversioni **implicite** (automatiche, senza perdita di dati: `int → double`, `char → int`) e **esplicite** (cast manuale, con possibile perdita di dati: `double → int`, `int → char`), verificate a runtime con `GetType()`.

**Concetti applicati**:
- Cast esplicito `(tipo)` e troncamento (non arrotondamento) nella conversione `double → int`
- Conversioni implicite tra tipi "compatibili" (nessun rischio di perdita)
- Corrispondenza tra `char` e i codici ASCII/Unicode
- `GetType()` per verificare il tipo effettivo di una variabile a runtime

---

## 2. 🗂️ I tipi di dato

Dichiarazione di variabili con il tipo più appropriato per ciascun dato (età, altezza, voto, prezzo, iniziale, booleano, nome), con motivazione della scelta per ciascun tipo.

**Concetti applicati**: `int`, `double`, `float` (suffisso `f`), `decimal` (suffisso `m`), `char`, `bool`, `string` — e il criterio di scelta tra tipi numerici in base alla precisione richiesta.

---

## 3. 🔤 Stringhe

Concatenazione di due stringhe (nome e cognome) in una terza variabile, tramite l'operatore `+`.

---

## 4. 🐛 Trova gli errori

Analisi di sei dichiarazioni di variabili scorrette, con identificazione e spiegazione di ciascun errore:

| Riga | Errore |
|---|---|
| `var x;` | `var` deve essere inizializzata subito |
| `var y = null;` | `null` non permette l'inferenza di tipo |
| `int numero = null;` | i value type non possono essere `null` (serve `int?`) |
| `char c = "A";` | il `char` vuole apici singoli, non doppi |
| `float f = 3.14;` | manca il suffisso `f` (altrimenti è un `double`) |
| `decimal prezzo = 15.5;` | manca il suffisso `m` |

---

## 5. 🎬 Classe `Cinema`

Modellazione di un cinema con nome, numero di sale e posti occupati, con calcolo dei posti totali e dei posti liberi.

**Attributi**: `Nome`, `NumeroSale`, `PostiDisponibili`, più una costante privata `postiSala` (fissa a 130 per ogni sala).

**Metodi**:
- `MostraInformazioni()` → stampa nome e numero di sale
- `PostiTotali()` → calcola `NumeroSale * postiSala`
- `PostiLiberi()` → calcola `PostiTotali() - PostiDisponibili`, riusando il metodo precedente invece di duplicare il calcolo

**Concetti applicati**: `const`, costruttore parametrico, uso di `this` per distinguere attributi e parametri omonimi, metodi con valore di ritorno vs `void`.

> **Nota tecnica**: usando i top-level statements, la classe `Cinema` è definita **dopo** tutte le istruzioni eseguibili del file (le istruzioni di primo livello devono precedere ogni dichiarazione di tipo).

---

## 🎯 Concetti generali ripassati in questo progetto

| Concetto | Dove viene applicato |
|---|---|
| Cast esplicito vs implicito | Esercizio 1 |
| Suffissi numerici (`f`, `m`) | Esercizi 2 e 4 |
| `GetType()` | Esercizio 1 |
| Value type non nullable | Esercizio 4 |
| `const` | Esercizio 5 |
| `this` nel costruttore | Esercizio 5 |
| Riuso di metodi (DRY) | Esercizio 5 (`PostiLiberi` richiama `PostiTotali`) |

---

## 🛠️ Come eseguire

Aprire il progetto in Visual Studio Community, oppure eseguire `dotnet run` da terminale nella cartella del progetto. Nessun input da tastiera richiesto: tutti i valori sono già definiti nel codice.

---

## 📚 Note

Progetto realizzato nell'ambito del percorso di studio C# (Unity/C#/SQL), come esercitazione pratica sui fondamenti del linguaggio.
