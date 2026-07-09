# Esercizio 1 — Classe Studente

## 📋 Consegna

Creare una classe `Studente` con proprietà `Nome` (stringa) e `Voti` (array di interi). Nel `Main`, istanziare uno studente con almeno 5 voti e:
- calcolare la media usando un ciclo `foreach`
- formattare una stringa con il nome in maiuscolo e la media a 2 decimali
- determinare il giudizio in base alla media (`if-else` o `switch`)

## 🧠 Spiegazione concetti

### `Nome { get; set; }` — proprietà auto-implementata
A differenza di `Voti` (campo pubblico semplice), `Nome` usa la sintassi di **proprietà** con `get`/`set` automatici. Concettualmente espone lo stesso comportamento di un campo pubblico, ma è la forma preferita in C# per l'incapsulamento: permette in futuro di aggiungere logica di validazione dentro `get`/`set` senza cambiare il modo in cui la proprietà viene usata dall'esterno.

### `CalcoloMedia()` — foreach
```csharp
int numSomma = 0;
foreach (int voto in Voti)
    numSomma += voto;
return (double)numSomma / Voti.Length;
```
Il `foreach` scorre ogni elemento dell'array `Voti` senza gestire manualmente un indice. Il cast `(double)` prima della divisione è **obbligatorio**: senza di esso, `numSomma / Voti.Length` sarebbe una divisione tra interi (troncata, senza decimali).

### `strOutput()` — formattazione
```csharp
return string.Format("{0} - Media: {1:F2}", Nome.ToUpper(), media);
```
- `{0}` → primo argomento passato (`Nome.ToUpper()`, il nome in maiuscolo)
- `{1:F2}` → secondo argomento (`media`), formattato con 2 cifre decimali fisse (`F2` = *Fixed-point, 2 decimali*)

### `determinareGiudizio()` — istruzione condizionale
Applica tre fasce sulla media calcolata:

| Condizione | Giudizio |
|---|---|
| `media > 9` | Eccellente |
| `media >= 6 && media <= 9` | Superato |
| altrimenti | Non Superato |

```csharp
if (media >= 9)  // ✅ coerente con "Media ≥ 9"
```

## 🔍 Esempio di esecuzione

Con `voti = { 9, 6, 9, 6, 5 }`:
- somma = 35, media = 35 / 5 = **7.0**
- output: `ILARIA NASSI - Media: 7.00`
- giudizio: `Superato` (7.0 è compreso tra 6 e 9)
