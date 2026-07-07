# Esercizi OOP in C# — Cliente Autofficina, Ordinazioni Ristorante, Ferie Dipendenti

Tre esercizi di programmazione orientata agli oggetti, pensati per esercitarsi su: campi `private` vs `public`, proprietà con validazione, campi `static` condivisi, `const`, overload dei costruttori e generazione di numeri casuali con `Random`.

Prima degli esercizi, una sezione di teoria applicata: **perché** si sono fatte certe scelte, non solo **come**.

---

## 📖 Indice
- [Perché private e public](#perché-private-e-public)
- [Perché string per certi campi](#perché-string-per-certi-campi)
- [Perché enum (e perché è meglio di string in certi casi)](#perché-enum-e-perché-è-meglio-di-string-in-certi-casi)
- [Come funziona lo switch e cos'è break](#come-funziona-lo-switch-e-cosè-break)
- [Perché const (e quando invece no)](#perché-const-e-quando-invece-no)
- [Perché static per i totali](#perché-static-per-i-totali)
- [Perché una proprietà e non un campo pubblico](#perché-una-proprietà-e-non-un-campo-pubblico)
- [Esercizio 1 — Cliente Autofficina](#esercizio-1--cliente-autofficina)
- [Esercizio 2 — Ordinazioni Ristorante](#esercizio-2--ordinazioni-ristorante)
- [Esercizio 3 — Ferie e Permessi Dipendenti](#esercizio-3--ferie-e-permessi-dipendenti)

---

## Perché `private` e `public`

Questa è la domanda più importante di tutte, perché è il cuore dell'**incapsulamento**.

Una classe deve decidere cosa il mondo esterno può vedere/toccare e cosa deve restare un dettaglio interno. La regola pratica che ho seguito in tutti e tre gli esercizi è:

> **Un campo che rappresenta un dato "grezzo" e che potrebbe aver bisogno di essere validato o protetto → `private`.**
> **Un modo controllato di leggere (o scrivere) quel dato dall'esterno → proprietà `public`.**

Esempio concreto, da `Dipendenti`:

```csharp
private int giorniFerie;          // il dato vero è nascosto
public int GiorniFerie             // l'accesso passa SEMPRE da qui
{
    get { return giorniFerie; }
    set
    {
        if (value < GiorniFerieMinime)
            giorniFerie = GiorniFerieMinime;   // non permette valori sotto il minimo
        else
            giorniFerie = value;
    }
}
```

Se `giorniFerie` fosse stato `public` direttamente (senza proprietà), **chiunque** avrebbe potuto scrivere `gianni.giorniFerie = -100;` e il programma avrebbe accettato un valore assurdo, senza nessun controllo. Rendendolo `private` e passando da una proprietà `public`, la classe **si difende da sola**: non importa da dove arriva la scrittura, il controllo nel `set` scatta sempre.

Questo è esattamente lo stesso schema della `Potenza` di `Personaggio` che avevi visto a lezione: `potenza` privata, `Potenza` pubblica con validazione (`if (value < 0) potenza = 0;`).

**Quando invece un campo può restare `public` senza proprietà?** Quando davvero non serve nessuna logica di controllo e il dato è pensato per essere letto/scritto liberamente (è il caso di `Nome`/`Razza` in `Personaggio` nell'esercizio originale della prof). Negli esercizi che abbiamo fatto ho preferito comunque `private` + proprietà anche per `Nome`/`Targa`/`IdTavolo`, perché sono identificativi che una volta assegnati non ha senso lasciar modificare a piacimento dall'esterno.

---

## Perché `string` per certi campi

`string` si usa ogni volta che il dato è **testo**, non un numero su cui si fanno calcoli:

- `Nome`, `Targa` (Cliente) → un nome o una targa non si "sommano" o si "moltiplicano", sono etichette testuali
- `TipoMenu` (Ordinazione) → è una categoria testuale (`"Vegano"`, `"Carne"`, `"Pesce"`), non un numero

La domanda da farsi è sempre: *"Ha senso fare aritmetica su questo dato?"* Se la risposta è no, e il dato è fatto di caratteri, è quasi sempre `string`. Le ore di manodopera, invece, sono un numero su cui **serve** fare calcoli (moltiplicazioni per la tariffa) → `decimal`, non `string`.

Per `TipoMenu`, nella prima versione dell'esercizio avevo usato `string`; nella versione aggiornata è diventato un **`enum`** — vedi la sezione successiva per il perché.

---

## Perché `enum` (e perché è meglio di `string` in certi casi)

Un `enum` (enumerazione) è un tipo che può assumere **solo un numero fisso e predefinito di valori**, che tu stesso elenchi in fase di scrittura del codice:

```csharp
public enum TipoMenu
{
    Vegano,
    Carne,
    Pesce
}
```

Perché è stato un miglioramento rispetto a `string`:

| Con `string` | Con `enum` |
|---|---|
| `"vegano"`, `"Vegano "` (spazio), `"Vegetariano"` sono tutte stringhe diverse, e il compilatore le accetta tutte senza lamentarsi | `TipoMenu.Vegano` è **l'unico** modo corretto di scrivere quel valore: se sbagli a digitarlo, **non compila proprio**, non lo scopri solo a runtime |
| Serve un controllo a mano (il `default` nello switch) per intercettare valori scritti male | Il controllo di validità lo fa il compilatore stesso, prima ancora di eseguire il programma |
| Il "significato" del valore è nella tua testa, il computer vede solo testo | Il tipo `TipoMenu` comunica da solo, leggendo il codice, quali sono TUTTI i valori possibili |

Nella versione con input da tastiera (`Console.ReadLine()`), l'utente scrive comunque una stringa (perché digita da tastiera), ma questa stringa viene **subito convertita** in un valore dell'enum tramite:

```csharp
if (Enum.TryParse(inputMenu, true, out TipoMenu menuScelto))
```

- `Enum.TryParse(...)` prova a convertire la stringa digitata nel valore corrispondente dell'enum `TipoMenu`
- Il secondo parametro `true` dice di **ignorare maiuscole/minuscole** (quindi `"carne"`, `"Carne"`, `"CARNE"` vengono tutte accettate e convertite correttamente)
- Se la conversione riesce, il risultato viene salvato nella variabile `menuScelto` (dichiarata al volo con `out`) e il blocco `if` restituisce `true`
- Se la stringa non corrisponde a nessun valore dell'enum (es. l'utente scrive `"pizza"`), `TryParse` restituisce `false` e si entra nell'`else` con il messaggio "menù non valido"

Da quel momento in poi, dentro il programma, non si maneggiano più stringhe ma **valori dell'enum**: tutto il resto del codice (switch, confronti, salvataggio nella proprietà `Tipo`) lavora su `TipoMenu`, un tipo sicuro, invece che su testo libero.

---

## Come funziona lo `switch` e cos'è `break`

Lo `switch` è un modo per confrontare **una singola variabile** con una serie di valori possibili, eseguendo un blocco di codice diverso per ciascun caso — un'alternativa più leggibile a una lunga catena di `if / else if` quando i confronti sono tutti sulla stessa variabile.

```csharp
switch (tipo)
{
    case TipoMenu.Vegano:
        TotaleVegano++;
        break;
    case TipoMenu.Carne:
        TotaleCarne++;
        break;
    case TipoMenu.Pesce:
        TotalePesce++;
        break;
}
```

Come si legge, passo per passo:
1. `switch (tipo)` → prende il valore della variabile `tipo` e lo confronta con ogni `case` scritto sotto, in ordine
2. Se `tipo` corrisponde a `case TipoMenu.Vegano:`, si esegue tutto il codice scritto subito dopo quei due punti (`TotaleVegano++;`)
3. `break;` → **interrompe** lo `switch` a quel punto, e il programma "esce" saltando a dopo la parentesi graffa di chiusura

**Perché `break` è fondamentale**: senza di esso, il codice C# continuerebbe ad eseguire anche le istruzioni dei `case` successivi (comportamento chiamato *fall-through*, che in C# in realtà è addirittura vietato dal compilatore su un `case` non vuoto — devi mettere sempre un `break`, un `return`, o un altro modo esplicito di uscire, altrimenti hai un errore di compilazione). `break` dice esplicitamente "il lavoro per questo caso è finito, non toccare gli altri `case`".

Un modo utile di pensarci: `switch` è come chiedere *"che valore hai?"* e ogni `case` è una risposta possibile con la sua azione dedicata; `break` è il punto in cui dici *"ok, ho risposto, chiudo la domanda qui"*.

Nella versione con `enum`, non serve più un `default` per intercettare valori sbagliati: essendo `TipoMenu` un enum con solo 3 valori possibili, e avendo già validato l'input con `Enum.TryParse` prima di arrivare allo switch, ogni possibile valore di `tipo` è già garantito essere uno dei tre `case` previsti.

---

## Perché `const` (e quando invece no)

`const` si usa per un valore che:
1. È **fissato in anticipo**, prima ancora di eseguire il programma (a tempo di compilazione)
2. **Non cambierà mai** durante l'esecuzione

Esempi usati:
```csharp
private const decimal TariffaOraria = 40.00m;   // tariffa fissa dell'officina
private const decimal CostoDiagnosi = 30m;      // costo fisso di diagnosi
private const decimal Iva = 0.22m;              // aliquota IVA
private const int GiorniFerieMinime = 2;        // minimo deciso dall'azienda
```

Questi sono tutti valori che **la classe stessa conosce già** e che rappresentano regole fisse (tariffe, aliquote, minimi di legge/aziendali). Non hanno senso come parametri del costruttore, perché non cambiano da cliente a cliente o da dipendente a dipendente: sono regole **della classe**, non dati **dell'istanza**.

**Quando invece non si userebbe `const`?** Se il valore dovesse poter cambiare durante l'esecuzione del programma (es. una tariffa oraria che l'officina può decidere di aggiornare senza ricompilare il codice), si userebbe `readonly` (se assegnato una volta, es. nel costruttore, e poi mai più modificato) oppure un normale campo/proprietà se deve poter cambiare liberamente. Questa distinzione era proprio quella delle slide: `const` = fissato a compilazione, `readonly` = fissato a runtime ma poi immutabile.

---

## Perché `static` per i totali

Un campo `static` **non appartiene alla singola istanza, ma alla classe intera** — è condiviso da tutti gli oggetti creati.

Questo è esattamente il caso dei "totali" richiesti da tutti e tre gli esercizi:
- Ore di manodopera totali di **tutta** l'officina (non del singolo cliente)
- Menu totali venduti **da tutto** il ristorante (non della singola ordinazione)
- Giorni ferie/ore permesso presi **da tutti** i dipendenti (non del singolo dipendente)

```csharp
private static decimal oreManodoperaTotali = 0;
```

Ogni volta che un costruttore viene eseguito (cioè ogni volta che nasce un nuovo oggetto), si incrementa il campo statico:
```csharp
oreManodoperaTotali += oreManodopera;
```

Il punto fondamentale: **anche se creo 100 clienti, `oreManodoperaTotali` è uno solo**, condiviso da tutti — esattamente come `ContaPersonaggi` nell'esercizio della prof, che contava quanti `Personaggio` erano stati creati in totale, indipendentemente da quanti oggetti esistessero.

Per leggerlo dall'esterno si usa una proprietà **anch'essa statica**, richiamata sul nome della classe e non su un'istanza:
```csharp
Console.WriteLine(Cliente.OreManodoperaTotali);   // ✅ sulla classe
// mario.OreManodoperaTotali;                      // ❌ errore: non è un membro di istanza
```

---

## Perché una proprietà e non un campo pubblico

Oltre al controllo di validità (già spiegato sopra per `private`/`public`), c'è un secondo motivo per usare una proprietà invece di un campo: **calcolare un valore al volo invece di doverlo salvare e tenere aggiornato a mano**.

`ContoTotale` in `Cliente` è l'esempio perfetto:
```csharp
public decimal ContoTotale
{
    get { return (_oreManodopera * TariffaOraria) + CostoDiagnosi; }
}
```

Non esiste un campo `contoTotale` da qualche parte che tengo aggiornato manualmente ogni volta che cambiano le ore. La proprietà **ricalcola il valore ogni volta che viene letta**, quindi è sempre corretta e aggiornata, senza rischio che io mi dimentichi di aggiornarla da qualche parte nel codice. Questo è anche più sicuro: se cambiassi `_oreManodopera` dopo aver creato l'oggetto, `ContoTotale` rifletterebbe subito il nuovo valore, senza bisogno di richiamare nessun metodo di aggiornamento.

---

## 🧠 Concetti trasversali usati in tutti e tre gli esercizi

| Concetto | Dove si vede | Perché |
|---|---|---|
| Campo `private` + proprietà `public` | ovunque | incapsulamento: validare/proteggere il dato reale |
| Campo `static` | totali in tutti e 3 | dato condiviso dalla classe, non dalla singola istanza |
| `const` | tariffe, minimi aziendali | regole fisse note a compilazione, mai modificate |
| Proprietà get-only (`{ get; }`) | `IdTavolo`, `Nome` | dato assegnabile solo alla creazione, poi immutabile |
| Overload dei costruttori con `: this(...)` | `Ordinazione` (prima versione) | riusare logica comune tra costruttori diversi |
| `Random` come campo statico | `Ordinazione` | evitare seed ripetuti creando tante istanze |
| Proprietà calcolata al volo (senza campo di supporto) | `ContoTotale` | valore sempre coerente con i dati attuali, senza doverlo aggiornare a mano |
| `enum` invece di `string` | `TipoMenu` | limita i valori possibili, errori scoperti a compilazione invece che a runtime |
| `switch` + `break` | `Ordinazione`, ciclo `Main` | confronto leggibile su più casi; `break` esce dal blocco (switch o ciclo) più vicino |
| `Enum.TryParse` | `Main` del ristorante | converte in sicurezza l'input testuale dell'utente in un valore enum, senza eccezioni se fallisce |
| `using static` | `Main` del ristorante | usa un tipo annidato (`TipoMenu`) senza scrivere il prefisso della classe che lo contiene |
