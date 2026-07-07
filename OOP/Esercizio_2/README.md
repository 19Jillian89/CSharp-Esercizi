# Esercizio 2 — Ordinazioni Ristorante
 
## Cosa chiedeva l'esercizio
1. Ogni ordinazione ha un `IdTavolo` (`int`) e un tipo di menu (`"Vegano"`, `"Carne"` o `"Pesce"`)
2. A fine serata servono **4 contatori**: menu totali venduti, quanti vegani, quanti carne, quanti pesce
---
 
## Concetti teorici usati
 
### Perché `enum` (e perché è meglio di `string` in certi casi)
Un `enum` (enumerazione) è un tipo che può assumere **solo un numero fisso e predefinito di valori**, che tu stesso elenchi in fase di scrittura del codice:
 
```csharp
public enum TipoMenu
{
    Vegano,
    Carne,
    Pesce
}
```
 
Perché è un miglioramento rispetto a `string` (usata nella prima versione dell'esercizio):
 
| Con `string` | Con `enum` |
|---|---|
| `"vegano"`, `"Vegano "` (spazio), `"Vegetariano"` sono tutte stringhe diverse, e il compilatore le accetta tutte senza lamentarsi | `TipoMenu.Vegano` è **l'unico** modo corretto di scrivere quel valore: se sbagli a digitarlo, **non compila proprio**, non lo scopri solo a runtime |
| Serve un controllo a mano (`default` nello switch) per intercettare valori scritti male | Il controllo di validità lo fa il compilatore stesso, prima ancora di eseguire il programma |
| Il "significato" del valore è nella tua testa, il computer vede solo testo | Il tipo `TipoMenu` comunica da solo, leggendo il codice, quali sono TUTTI i valori possibili |
 
Nella versione con input da tastiera (`Console.ReadLine()`), l'utente scrive comunque una stringa (perché digita da tastiera), ma questa stringa viene **subito convertita** in un valore dell'enum tramite:
 
```csharp
if (Enum.TryParse(inputMenu, true, out TipoMenu menuScelto))
```
 
- `Enum.TryParse(...)` prova a convertire la stringa digitata nel valore corrispondente dell'enum `TipoMenu`
- Il secondo parametro `true` dice di **ignorare maiuscole/minuscole** (quindi `"carne"`, `"Carne"`, `"CARNE"` vengono tutte accettate e convertite correttamente)
- Se la conversione riesce, il risultato viene salvato nella variabile `menuScelto` (dichiarata al volo con `out`) e il blocco `if` restituisce `true`
- Se la stringa non corrisponde a nessun valore dell'enum (es. `"pizza"`), `TryParse` restituisce `false` e si entra nell'`else`
Da quel momento in poi, dentro il programma, non si maneggiano più stringhe ma **valori dell'enum**: tutto il resto del codice (switch, confronti, salvataggio nella proprietà `Tipo`) lavora su `TipoMenu`, un tipo sicuro, invece che su testo libero.
 
### Come funziona lo `switch` e cos'è `break`
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
**Perché `break` è fondamentale**: senza di esso, il codice C# continuerebbe ad eseguire anche le istruzioni dei `case` successivi (comportamento chiamato *fall-through*, che in C# è addirittura vietato dal compilatore su un `case` non vuoto — devi mettere sempre un `break`, un `return`, o un altro modo esplicito di uscire, altrimenti hai un errore di compilazione). `break` dice esplicitamente "il lavoro per questo caso è finito, non toccare gli altri `case`".
 
Un modo utile di pensarci: `switch` è come chiedere *"che valore hai?"* e ogni `case` è una risposta possibile con la sua azione dedicata; `break` è il punto in cui dici *"ok, ho risposto, chiudo la domanda qui"*.
 
Nella versione con `enum`, non serve più un `default`: essendo `TipoMenu` un enum con solo 3 valori possibili, e avendo già validato l'input con `Enum.TryParse` prima di arrivare allo switch, ogni possibile valore di `tipo` è già garantito essere uno dei tre `case` previsti.
 
### `break` non è solo per lo switch
Nel `Main`, `break` viene usato anche per uscire da un **ciclo** (`while`), non da uno switch:
```csharp
while (true)
{
    // ...
    if (inputMenu == "ADIOS")
    {
        Console.WriteLine("Adios!");
        break;   // esce dal WHILE, non da uno switch
    }
    // ...
}
```
`break` funziona sempre allo stesso identico modo concettuale: **"esci immediatamente dal blocco che stai eseguendo"**. Che sia un ciclo o uno switch, interrompe sempre la struttura di controllo più vicina in cui si trova.
 
### Perché `using static`
```csharp
using static Gestione_Ristorante.Ordinazione;
```
Questa direttiva permette di scrivere `TipoMenu` direttamente nel `Main` (es. `out TipoMenu menuScelto`) senza dover scrivere per esteso `Ordinazione.TipoMenu`, perché `TipoMenu` è un tipo *annidato* dentro la classe `Ordinazione`. È lo stesso spirito del classico `using System;` che evita di scrivere `System.Console.WriteLine`, solo applicato a un tipo proprio invece che a un namespace della libreria standard.
 
### Perché `static` per i contatori e per `Random`
I 4 contatori (`TotaleMenu`, `TotaleVegano`, ecc.) sono `static` perché rappresentano un dato di **tutto il ristorante**, non della singola ordinazione — stesso principio del totale ore dell'officina nell'Esercizio 1.
 
`Random` deve essere una **singola istanza `static`**, condivisa da tutta la classe/programma:
```csharp
private static Random randTavolo = new Random();
```
Altrimenti, creando molti oggetti `Random` in rapida successione, si rischia di ottenere lo stesso seed (basato sull'orologio di sistema) e quindi numeri ripetuti.
 
### `IdTavolo` e `Tipo` in sola lettura
```csharp
public int IdTavolo { get; }
public TipoMenu Tipo { get; }
```
Proprietà auto-implementate get-only: una volta che un'ordinazione è registrata a un tavolo con un certo menu, non ha senso poterla modificare da fuori la classe. Il compilatore genera da solo il campo nascosto e il `get`, e l'unico modo per assegnare un valore è dentro il costruttore.
 
---
 
## Codice completo
 
> 📄 Codice completo nei file `Ordinazione.cs` e `Program.cs` del repo.
 
**Classe `Ordinazione`:**
```csharp
using System;
 
namespace Gestione_Ristorante
{
    internal class Ordinazione
    {
        // enum: solo questi 3 valori sono ammessi per il tipo di menu
        public enum TipoMenu
        {
            Vegano,
            Carne,
            Pesce
        }
 
        // i 4 contatori richiesti dalla consegna: static, dati dell'intero ristorante
        public static int TotaleMenu = 0;
        public static int TotaleVegano = 0;
        public static int TotaleCarne = 0;
        public static int TotalePesce = 0;
 
        // proprietà get-only: assegnabili solo nel costruttore
        public int IdTavolo { get; }
        public TipoMenu Tipo { get; }
 
        public Ordinazione(int idTavolo, TipoMenu tipo)
        {
            IdTavolo = idTavolo;
            Tipo = tipo;
            TotaleMenu++;
 
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
                // non serve un "default": Tipo è un enum, quindi può essere
                // SOLO uno di questi 3 valori, non serve gestire altri casi
            }
        }
    }
}
```
 
**`Program` / `Main`:**
```csharp
using static Gestione_Ristorante.Ordinazione;
 
namespace Gestione_Ristorante
{
    internal class Program
    {
        // UNA SOLA istanza di Random condivisa da tutto il programma,
        // per evitare seed ripetuti
        private static Random randTavolo = new Random();
 
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuti al Ristorante Daje Goju!! Pronti ad ordinare?\n");
 
            while (true)
            {
                // genera un ID tavolo casuale tra 1 e 15
                int nuovoTavolo = randTavolo.Next(1, 16);
                Console.WriteLine($"\nIl tavolo assegnato è il numero: {nuovoTavolo}!");
                Console.WriteLine("Inserisci il menù (Carne, Pesce, Vegano) o ADIOS per uscire: ");
                string inputMenu = Console.ReadLine();
 
                if (inputMenu == "ADIOS")
                {
                    Console.WriteLine("Adios!");
                    break;   // esce dal while
                }
 
                // prova a convertire la stringa digitata in un valore dell'enum TipoMenu
                // 'true' = ignora maiuscole/minuscole
                if (Enum.TryParse(inputMenu, true, out TipoMenu menuScelto))
                {
                    new Ordinazione(nuovoTavolo, menuScelto);
                    Console.WriteLine($"Ordinazione registrata con successo per il Tavolo {nuovoTavolo}!\n");
                }
                else
                {
                    Console.WriteLine("menù non valido!\n");
                }
            }
 
            Console.WriteLine("Ore 23: CHIUSO! Riepilogo: \n");
            Console.WriteLine($"Menù totali venduti: {Ordinazione.TotaleMenu}");
            Console.WriteLine($"Carne: {Ordinazione.TotaleCarne}");
            Console.WriteLine($"Pesce: {Ordinazione.TotalePesce}");
            Console.WriteLine($"Vegano: {Ordinazione.TotaleVegano}");
        }
    }
}
```
 
---
 
## Perché niente più `default` nello switch
Nella prima versione (con `string`), il `default` nello switch era necessario perché una stringa può contenere **qualsiasi cosa** — anche testo senza senso — quindi serviva un modo per intercettare input non previsti proprio dentro lo switch. Con `TipoMenu` come `enum`, il controllo di validità è già stato fatto **prima**, con `Enum.TryParse`: se l'esecuzione arriva dentro il costruttore di `Ordinazione`, `tipo` è **garantito** essere uno dei 3 valori dell'enum, quindi tutti i casi possibili sono già coperti dai tre `case` — un `default` sarebbe codice morto, mai raggiungibile.
 
---
 
## `Main` di esempio (sessione simulata)
```
Benvenuti al Ristorante Daje Goju!! Pronti ad ordinare?
 
Il tavolo assegnato è il numero: 7!
Inserisci il menù (Carne, Pesce, Vegano) o ADIOS per uscire:
> carne
Ordinazione registrata con successo per il Tavolo 7!
 
Il tavolo assegnato è il numero: 3!
Inserisci il menù (Carne, Pesce, Vegano) o ADIOS per uscire:
> pizza
menù non valido!
 
Il tavolo assegnato è il numero: 12!
Inserisci il menù (Carne, Pesce, Vegano) o ADIOS per uscire:
> ADIOS
Adios!
 
Ore 23: CHIUSO! Riepilogo:
 
Menù totali venduti: 1
Carne: 1
Pesce: 0
Vegano: 0
```
(nota come `"pizza"` non venga registrato come ordinazione: `Enum.TryParse` fallisce e il ciclo prosegue senza incrementare nessun contatore)
 
