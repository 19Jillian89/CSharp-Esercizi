# Esercizio 3 — Ferie e Permessi Dipendenti

## Cosa chiedeva l'esercizio
1. Ogni dipendente ha giorni di ferie e ore di permesso presi ad agosto
2. Esistono dei **minimi aziendali** che nessun dipendente può avere sotto
3. Serve un totale, sommando i valori di **tutti** i dipendenti (con l'esempio: Gianni 3 giorni, Luisa 4 giorni, Marco 16 ore permesso → totale 9 giorni ferie)

---

## Concetti teorici usati

### Perché `private` e `public` con validazione nel `set`
Questo esercizio è quello che sfrutta di più **la validazione nel `set` della proprietà**, cuore dell'incapsulamento. Il vincolo "non è possibile che i giorni di ferie/ore di permesso siano inferiori al minimo generale" si traduce direttamente in un controllo dentro il `set`:

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

Questo è lo stesso schema della `Potenza` di `Personaggio` visto a lezione: campo privato, proprietà pubblica con validazione (`if (value < 0) potenza = 0;`).

Questo controllo è ciò che fa tornare i conti dell'esempio della consegna: Marco ha messo `0` giorni ferie nel costruttore, ma la proprietà lo **forza automaticamente** a `GiorniFerieMinime = 2`, che è esattamente il valore mancante per arrivare a 9 (3 + 4 + 2 = 9).

### Perché `const` per i minimi aziendali
```csharp
private const int GiorniFerieMinime = 2;
private const int OrePermessiMinime = 8;
```
Questi sono valori **fissati in anticipo** (a tempo di compilazione) che rappresentano regole aziendali fisse per il mese di agosto, note a priori e comuni a tutti i dipendenti — non cambiano da persona a persona, quindi non hanno senso come parametro del costruttore: sono regole **della classe**, non dati **dell'istanza**.

### Perché `static` per i totali generali
```csharp
private static int totaleFerie = 0;
private static int totalePermessi = 0;
```
Un campo `static` **non appartiene alla singola istanza, ma alla classe intera**: qui serve per accumulare i giorni/ore di **tutti** i dipendenti, non del singolo. Ogni volta che un costruttore viene eseguito (nasce un nuovo `Dipendenti`), si incrementano questi campi statici — stesso principio del totale ore dell'officina (Esercizio 1) e dei contatori del ristorante (Esercizio 2).

---

## Codice completo commentato

```csharp
using System;
namespace Azienda
{
    internal class Dipendenti
    {
        // regole fisse decise dall'azienda per il mese di agosto
        private const int GiorniFerieMinime = 2;
        private const int OrePermessiMinime = 8;

        // totali di TUTTI i dipendenti: static, non di istanza
        private static int totaleFerie = 0;
        private static int totalePermessi = 0;

        public string Nome { get; }

        private int giorniFerie;
        public int GiorniFerie
        {
            get { return giorniFerie; }
            set
            {
                if (value < GiorniFerieMinime)
                    giorniFerie = GiorniFerieMinime;
                else
                    giorniFerie = value;
            }
        }

        private int orePermessi;
        public int OrePermessi
        {
            get { return orePermessi; }
            set
            {
                if (value < OrePermessiMinime)
                    orePermessi = OrePermessiMinime;
                else
                    orePermessi = value;
            }
        }

        public Dipendenti(string nome, int giorniFerie, int orePermessi)
        {
            Nome = nome;

            // passando dalle PROPRIETA' (non dai campi diretti), il set valida subito
            GiorniFerie = giorniFerie;
            OrePermessi = orePermessi;

            // accumulo i totali DOPO la validazione, cosi' il minimo forzato viene conteggiato
            totaleFerie += GiorniFerie;
            totalePermessi += OrePermessi;
        }

        public static int TotaleFerie
        {
            get { return totaleFerie; }
        }

        public static int TotalePermessi
        {
            get { return totalePermessi; }
        }
    }
}
```

---

## Punto sottile da notare
Nel costruttore, la riga
```csharp
GiorniFerie = giorniFerie;
```
scrive nella **proprietà** (lettera maiuscola), non nel campo privato direttamente. Questo è voluto: assegnando alla proprietà si passa per forza dal `set`, quindi anche i valori passati al costruttore vengono validati. Se avessi scritto `giorniFerie = giorniFerie;` (campo minuscolo), avrei bypassato del tutto il controllo, e un dipendente creato con `0` giorni sarebbe rimasto a `0` invece di essere forzato al minimo — vanificando tutta la logica di validazione.

---

## `Main` di test e output atteso

```csharp
Dipendenti gianni = new Dipendenti("Gianni", 3, 0);
Dipendenti luisa  = new Dipendenti("Luisa", 4, 0);
Dipendenti marco  = new Dipendenti("Marco", 0, 16);

Console.WriteLine(Dipendenti.TotaleFerie);      // 9  → 3 + 4 + 2(forzato)
Console.WriteLine(Dipendenti.TotalePermessi);   // 32 → 8(forzato) + 8(forzato) + 16
```
