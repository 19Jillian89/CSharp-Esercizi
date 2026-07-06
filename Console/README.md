# ⚔️ Guerriero & Mercante — Console App in C#

Piccolo progetto console in C# che simula l'inizio di un'avventura fantasy: si crea un **Guerriero**, lo si sottopone a un attacco, e infine si acquista una **pozione curativa** da un **Mercante**, con tanto di ricevuta formattata.

Realizzato come esercizio di ripasso su input/output da console, gestione degli errori di conversione, incapsulamento e formattazione delle stringhe in C#.

---

## 📖 Cosa fa il programma

1. Chiede il nickname del guerriero e mostra un messaggio di benvenuto.
2. Chiede gli **HP massimi** e gli **HP attuali**, validando l'input.
   - Se gli HP attuali superano il massimo, vengono automaticamente riportati al valore massimo.
   - Lo **stato** del guerriero (`Pronto al combattimento` / `Svenuto`) viene calcolato con un operatore ternario in base agli HP.
3. Simula un attacco: il guerriero subisce danno, gli HP vengono aggiornati e lo stato ricalcolato di conseguenza.
4. Il **Mercante** propone una pozione: si inserisce prezzo e sconto, e viene stampata una ricevuta formattata in stile scontrino.

---

## 🧠 Concetti C# messi in pratica

| Concetto | Dove |
|---|---|
| Classi e incapsulamento | `Guerriero`, `Mercante` |
| Proprietà auto-implementate (`get; set;`) | tutte le proprietà delle due classi |
| `int.TryParse()` | validazione HP massimi/attuali |
| `Convert.ToDecimal()` / `Convert.ToDouble()` + `try/catch` | lettura prezzo pozione, con fallback |
| Operatore ternario `?:` | calcolo dello stato del guerriero |
| Cast esplicito `(decimal)` | conversione tra `double` (sconto) e `decimal` (prezzo) |
| Interpolazione di stringhe (`$"..."`) | messaggi a console |
| Formattazione numerica (`:C`, `:P0`) e allineamento (`{0,-20}`) | ricevuta del mercante |
| `Console.ReadKey()` | pausa tra le sezioni del programma |

---

## 🗂️ Struttura del codice

```
Program.cs
├── class Guerriero
│   ├── Nome, HPMassimi, HPAttuali, Stato   → proprietà
│   ├── StampaInfo()                        → stampa il riepilogo del personaggio
│   └── EroeAttaccato(int danno)            → applica danno e aggiorna stato
│
├── class Mercante
│   ├── PrezzoBase, Sconto                  → proprietà
│   └── MostraRicevuta()                    → calcola e stampa la ricevuta
│
└── class Program
    └── Main(string[] args)                 → orchestra il flusso del programma
```

---

## ▶️ Come eseguirlo

```bash
dotnet run
```

Oppure, da Visual Studio, apri la soluzione e premi **Avvia** (F5).

---

## 💻 Esempio di esecuzione

```
Inserisci Nickname: Bob
Benvenuto, Bob! Il regno ha bisogno di un eroe come te.

Hp massimi sono: 200
Hp attuali sono: 200

--- Caratteristiche Guerriero ---
Nome: Bob
HP: 200/200
Stato: Pronto al combattimento

Oh no! Il nostro eroe è stato attaccato!! Quanti danni sono stati inflitti? 150
Bob subisce 150 danni! HP rimanenti: 50/200

--- Caratteristiche Guerriero ---
Nome: Bob
HP: 50/200
Stato: Pronto al combattimento

Salve guerriero, hai bisogno di una bella pozione!!

La pozione costa: 55
Mi sei simpatico, ti farò uno sconto: 0,20

--- RICEVUTA MERCANTE ---
Prezzo Iniziale:            € 55,00
Sconto Applicato:                20%
Prezzo Finale:               € 44,00
GRAZIE!
-------------------------
```

> ⚠️ **Nota sulla localizzazione**: per vedere correttamente il simbolo `€` nella console, potrebbe essere necessario impostare `Console.OutputEncoding = System.Text.Encoding.UTF8;` all'inizio del `Main`, a seconda della code page di default della console in uso. Inoltre, su sistemi con cultura italiana, lo sconto va inserito con la **virgola** (es. `0,20`) e non con il punto, per essere interpretato correttamente da `Convert.ToDouble()`.

---

## 🚀 Possibili estensioni future

- Aggiungere un ciclo `while` per permettere più round di combattimento.
- Introdurre un `enum` per il tipo di nemico o di pozione.
- Validare anche l'input dello sconto con `TryParse`/`try-catch`, invece di assumere che sia sempre corretto.
- Trasformarlo in un vero game loop testuale con `Console.ReadKey()` per i comandi, in stile roguelike.

---

## 👤 Autore

Ilaria Nassi
