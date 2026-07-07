

Esercizio1 clienteautofficina · MD
# Esercizio 1 — Cliente Autofficina
 
## Cosa chiedeva l'esercizio
1. Classe `Cliente` con campi privati `targa`, `nome`
2. Un campo `OreManodopera` che rappresenta il totale ore lavorate dal meccanico su **tutte** le auto dei clienti (→ è un dato dell'**officina**, non del singolo cliente)
3. Ogni cliente ha invece le **proprie** ore di manodopera (quante ore il meccanico ha lavorato sulla **sua** macchina)
4. Una proprietà pubblica **in sola lettura** `ContoTotale` (`decimal`) che calcola: `ore del cliente × tariffa oraria fissa (40€) + costo fisso di diagnosi (30€)`, **ricalcolata ogni volta che viene letta**
5. Un metodo che calcola quanto il singolo cliente deve pagare comprensivo di IVA
---
 
## Concetti teorici usati
 
### Perché `private` e `public`
Questa è la domanda più importante, perché è il cuore dell'**incapsulamento**.
 
Una classe deve decidere cosa il mondo esterno può vedere/toccare e cosa deve restare un dettaglio interno. La regola pratica:
 
> **Un campo che rappresenta un dato "grezzo" e che potrebbe aver bisogno di essere validato o protetto → `private`.**
> **Un modo controllato di leggere (o scrivere) quel dato dall'esterno → proprietà `public`.**
 
Se `_oreManodopera` fosse stato `public` direttamente (senza passare da nessuna logica), chiunque avrebbe potuto assegnargli valori assurdi (es. negativi) senza controllo. Rendendolo `private` e passando eventualmente da proprietà pubbliche, la classe **si difende da sola**.
 
Nomi come `Nome`/`Targa` restano `private` anche se non hanno validazioni particolari, perché sono identificativi che una volta assegnati non ha senso lasciar modificare a piacimento dall'esterno.
 
### Perché `string` per `Nome`/`Targa`
`string` si usa quando il dato è **testo**, non un numero su cui si fanno calcoli. Un nome o una targa non si "sommano" o si "moltiplicano": sono etichette testuali. Le ore di manodopera, invece, sono un numero su cui **serve** fare calcoli (moltiplicazioni per la tariffa) → `decimal`, non `string`.
 
La domanda da farsi sempre è: *"Ha senso fare aritmetica su questo dato?"* Se no, ed è fatto di caratteri, è `string`.
 
### Perché `const`
`const` si usa per un valore che:
1. È **fissato in anticipo**, prima ancora di eseguire il programma (a tempo di compilazione)
2. **Non cambierà mai** durante l'esecuzione
```csharp
private const decimal TariffaOraria = 40.00m;   // tariffa fissa dell'officina
private const decimal CostoDiagnosi = 30m;      // costo fisso di diagnosi
private const decimal Iva = 0.22m;              // aliquota IVA
```
 
Questi sono valori che **la classe stessa conosce già** e rappresentano regole fisse. Non hanno senso come parametri del costruttore, perché non cambiano da cliente a cliente: sono regole **della classe**, non dati **dell'istanza**.
 
**Quando invece non si userebbe `const`?** Se il valore dovesse poter cambiare durante l'esecuzione (es. una tariffa che l'officina aggiorna senza ricompilare), si userebbe `readonly` (assegnato una volta, es. nel costruttore, poi mai più modificato).
 
### Perché `static` per il totale ore dell'officina
Un campo `static` **non appartiene alla singola istanza, ma alla classe intera** — è condiviso da tutti gli oggetti creati.
 
```csharp
private static decimal oreManodoperaTotali = 0;
```
 
Ogni volta che un costruttore viene eseguito (nasce un nuovo `Cliente`), si incrementa il campo statico:
```csharp
oreManodoperaTotali += oreManodopera;
```
 
Anche se creo 100 clienti, `oreManodoperaTotali` è **uno solo**, condiviso da tutti — esattamente come `ContaPersonaggi` nell'esercizio `Personaggio` visto a lezione. Per leggerlo dall'esterno serve una proprietà **anch'essa statica**, richiamata sul nome della classe:
```csharp
Console.WriteLine(Cliente.OreManodoperaTotali);   // ✅ sulla classe
// mario.OreManodoperaTotali;                      // ❌ errore: non è un membro di istanza
```
 
### Perché una proprietà (`ContoTotale`) e non un campo pubblico
Oltre al controllo di validità, c'è un secondo motivo per usare una proprietà: **calcolare un valore al volo invece di doverlo salvare e tenere aggiornato a mano**.
 
```csharp
public decimal ContoTotale
{
    get { return (_oreManodopera * TariffaOraria) + CostoDiagnosi; }
}
```
 
Non esiste un campo `contoTotale` salvato da qualche parte: la proprietà **ricalcola il valore ogni volta che viene letta**, quindi è sempre corretta e aggiornata. Il `get` senza `set` corrisponde esattamente alla richiesta "in sola lettura": si può leggere il conto ma non impostarlo direttamente dall'esterno, perché è sempre una conseguenza delle ore lavorate, non un dato indipendente.
 
---
 
## Codice completo commentato
 
```csharp
using System;
namespace Autofficina
{
    internal class Cliente
    {
        // regole fisse dell'officina: const perché non cambiano mai durante l'esecuzione
        private const decimal TariffaOraria = 40.00m;
        private const decimal CostoDiagnosi = 30m;
        private const decimal Iva = 0.22m;
 
        // dato dell'ISTANZA: ore lavorate sulla macchina di QUESTO cliente
        private decimal _oreManodopera;
 
        // dato della CLASSE: ore totali lavorate su TUTTE le macchine dell'officina
        private static decimal oreManodoperaTotali = 0;
 
        private string _targa;
        private string _nome;
 
        public Cliente(string nome, string targa, decimal oreManodopera)
        {
            _nome = nome;
            _targa = targa;
            _oreManodopera = oreManodopera;
 
            // ogni nuovo cliente contribuisce al totale generale dell'officina
            oreManodoperaTotali += oreManodopera;
        }
 
        // proprietà PUBBLICA in SOLA LETTURA (solo get)
        // ricalcolata ogni volta che viene invocata, come richiesto dalla consegna
        public decimal ContoTotale
        {
            get { return (_oreManodopera * TariffaOraria) + CostoDiagnosi; }
        }
 
        // proprietà statica per leggere il totale ore dell'officina dall'esterno
        public static decimal OreManodoperaTotali
        {
            get { return oreManodoperaTotali; }
        }
 
        // metodo richiesto dal punto 2: quanto il singolo cliente deve pagare, con IVA
        public decimal CalcoloIva()
        {
            return _oreManodopera * TariffaOraria * (1 + Iva);
        }
    }
}
```
 
---
 
## 🔢 Il calcolo di `CalcoloIva()`, spiegato passo passo
 
```csharp
return _oreManodopera * TariffaOraria * (1 + Iva);
```
 
Scomponiamo il calcolo con Mario come esempio: `_oreManodopera = 5`, `TariffaOraria = 40`, `Iva = 0.22`.
 
**Passo 1 — il costo "puro" della manodopera, senza IVA:**
```
_oreManodopera * TariffaOraria
= 5 * 40
= 200
```
Questo è semplicemente: ore lavorate × quanto costa un'ora di lavoro. È il prezzo prima delle tasse.
 
**Passo 2 — trasformare l'aliquota IVA in un moltiplicatore:**
 
L'IVA è il 22%, cioè il 22 su 100, cioè `0.22`. Se applichi solo `× 0.22` ottieni **quanto vale l'IVA da sola** (200 × 0.22 = 44€), non il totale da pagare — sarebbe solo la tassa, senza il prezzo base.
 
Per ottenere **prezzo base + IVA in un colpo solo**, si usa il trucco:
```
(1 + Iva) = (1 + 0.22) = 1.22
```
Il `1` rappresenta "il 100% del prezzo originale" (il prezzo intero, non toccato), e sommandoci `0.22` (il 22% aggiuntivo dell'IVA) ottieni **1.22, che rappresenta il 122% del prezzo di partenza** — cioè prezzo intero + 22% di tasse, tutto insieme.
 
**Passo 3 — moltiplicare tutto insieme:**
```
200 * 1.22 = 244
```
 
Verifica per contro-prova, sommando i pezzi separatamente:
```
prezzo base:      200
IVA (22% di 200):  44   (200 * 0.22)
totale:           244   (200 + 44)  ✅ stesso risultato
```
 
Quindi `x * (1 + aliquota)` è una scorciatoia matematica per **"prezzo base + la sua percentuale di tassa"**, in un'unica moltiplicazione. È lo stesso principio di uno sconto ma al contrario: uno sconto del 20% sarebbe `x * (1 - 0.20)`, un aumento/tassa del 22% è `x * (1 + 0.22)`.

---
 
## `Main` di test e output atteso
 
```csharp
Cliente mario = new Cliente("Mario Rossi", "AB123CD", 5);
Cliente luca  = new Cliente("Luca Bianchi", "EF456GH", 3);
 
Console.WriteLine($"Conto totale Mario: {mario.ContoTotale}€");     // 230,00€  → (5*40)+30
Console.WriteLine($"Conto totale Luca: {luca.ContoTotale}€");       // 150,00€  → (3*40)+30
Console.WriteLine($"Mario con IVA: {mario.CalcoloIva()}€");         // 244,0000€ → 5*40*1.22
Console.WriteLine($"Luca con IVA: {luca.CalcoloIva()}€");           // 146,4000€ → 3*40*1.22
Console.WriteLine(Cliente.OreManodoperaTotali);                     // 8 → 5+3
```
