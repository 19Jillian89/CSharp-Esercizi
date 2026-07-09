# Esercizio 3 — Acquario (matrice 4×4)

## 📋 Consegna

Rappresentare un acquario come matrice bidimensionale 4×4 di stringhe. Contare vasche piene/vuote, stampare la mappa e le due diagonali, cercare una specie specifica terminando la ricerca appena trovata, con messaggio speciale se si trova il "Delfino".

## ⚠️ Attenzione — bug strutturale corretto!

Nel codice originale, il metodo `Main` lo avevo scritto **annidato dentro `CercaPesce`** (come funzione locale), invece che come metodo separato della classe `Program`. Questo impedisce la compilazione: un programma C# deve avere un `Main` definito come **membro della classe**, non come funzione locale dentro un altro metodo — il compilatore non lo riconoscerebbe come punto di ingresso dell'applicazione.

**Struttura corretta**: `Main` e `CercaPesce` devono essere due metodi separati, allo stesso livello dentro la classe `Program`.

## 🧠 Spiegazione concetti

### Matrice bidimensionale `string[,]`
Ogni cella si accede con `acquario[riga, colonna]`. `GetLength(0)` restituisce il numero di righe, `GetLength(1)` il numero di colonne.

### Cicli annidati per scorrere la matrice
```csharp
for (int i = 0; i < righe; i++)       // scorre le righe
    for (int j = 0; j < colonne; j++) // scorre le colonne di quella riga
```
Per ogni riga `i`, il ciclo interno scorre tutte le colonne `j` prima di passare alla riga successiva — equivale a leggere una tabella riga per riga.

### Diagonale principale vs secondaria
- **Principale**: `acquario[i, i]` — riga e colonna hanno lo stesso indice (angolo alto-sinistra → basso-destra)
- **Secondaria**: `acquario[i, righe - 1 - i]` — la colonna è "specchiata" rispetto alla riga (angolo alto-destra → basso-sinistra)

### `CercaPesce` — perché `return` e non `goto`
```csharp
if (acquario[i, j] == specie)
{
    Console.WriteLine(...);
    return; // esce SUBITO dal metodo
}
```
Essendo la ricerca dentro un **metodo separato** (non dentro `Main`), `return` è la scelta corretta e idiomatica per interrompere l'esecuzione appena trovato l'elemento cercato — non serve `goto`. Se il valore non viene mai trovato, i due `for` terminano naturalmente e si arriva all'ultima riga del metodo (messaggio "non presente").

### Perché `CercaPesce` è `static`
Essendo `static`, il metodo appartiene alla classe stessa e non a una singola istanza — è richiamabile direttamente (`CercaPesce(...)`) senza dover fare `new Program()`.

## 🔍 Traccia di esecuzione

Con la matrice dell'esempio:
- `CercaPesce(acquario, "Pesce Pagliaccio")` → trovato in `[0,0]`, il metodo esce subito
- `CercaPesce(acquario, "Delfino")` → trovato in `[1,3]`, messaggio di vincita
- `CercaPesce(acquario, "Balena")` → mai trovato, i cicli scorrono tutte le 16 celle e stampano "non presente nell'acquario"
