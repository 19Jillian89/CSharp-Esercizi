## Esercizio 3 — Ferie e Permessi Dipendenti
 
### Cosa chiedeva l'esercizio
1. Ogni dipendente ha giorni di ferie e ore di permesso presi ad agosto
2. Esistono dei **minimi aziendali** che nessun dipendente può avere sotto
3. Serve un totale, sommando i valori di **tutti** i dipendenti (con l'esempio: Gianni 3 giorni, Luisa 4 giorni, Marco 16 ore permesso → totale 9 giorni ferie)
### Come l'ho affrontato
 
Questo esercizio è quello che sfrutta di più **la validazione nel `set` della proprietà**, il concetto di incapsulamento spiegato a inizio README. Il vincolo "non è possibile che i giorni di ferie/ore di permesso siano inferiori al minimo generale" si traduce direttamente in un controllo dentro il `set`:
 
```csharp
public int GiorniFerie
{
    get { return giorniFerie; }
    set
    {
        if (value < GiorniFerieMinime)
            giorniFerie = GiorniFerieMinime;   // forza al minimo, non lascia passare valori troppo bassi
        else
            giorniFerie = value;
    }
}
```
 
Questo è ciò che fa tornare i conti dell'esempio della consegna: Marco ha messo `0` giorni ferie nel costruttore, ma la proprietà lo **forza automaticamente** a `GiorniFerieMinime = 2`, che è esattamente il valore mancante per arrivare a 9 (3 + 4 + 2 = 9).
 
```
 
### Punto sottile da notare
Nel costruttore, la riga
```csharp
GiorniFerie = giorniFerie;
```
scrive nella **proprietà** (lettera maiuscola), non nel campo privato direttamente. Questo è voluto: assegnando alla proprietà si passa per forza dal `set`, quindi anche i valori passati al costruttore vengono validati. Se avessi scritto `giorniFerie = giorniFerie;` (campo minuscolo), avrei bypassato del tutto il controllo, e un dipendente creato con `0` giorni sarebbe rimasto a `0` invece di essere forzato al minimo — vanificando tutta la logica di validazione.
 
### Errori incontrati durante lo sviluppo
- **`TotaleFerie` con `get { }` vuoto**: compilava con errore, perché una proprietà con un tipo di ritorno diverso da `void` deve sempre restituire qualcosa tramite `return`.
- **Parentesi graffa di chiusura mancante**: la classe non era chiusa correttamente, causando errori a cascata nel resto del file.
- **`Dipendenti.OrePermessi` nel `Main`**: errore concettuale, perché `OrePermessi` è una proprietà di **istanza** (serve un oggetto specifico, es. `marco.OrePermessi`), mentre serviva quella **statica** `TotalePermessi` per il totale generale.
### `Main` di test e output atteso
```csharp
Dipendenti gianni = new Dipendenti("Gianni", 3, 0);
Dipendenti luisa  = new Dipendenti("Luisa", 4, 0);
Dipendenti marco  = new Dipendenti("Marco", 0, 16);
 
Console.WriteLine(Dipendenti.TotaleFerie);      // 9  → 3 + 4 + 2(forzato)
Console.WriteLine(Dipendenti.TotalePermessi);   // 32 → 8(forzato) + 8(forzato) + 16
```
 
---
