# Esercizio 1 — Sistema Caffetteria (Ereditarietà, Polimorfismo, Interfacce)

## Obiettivo dell'esercizio

Modellare un piccolo catalogo di prodotti da torrefazione (caffè in grani, caffè in capsule, bevande solubili) usando ereditarietà, override e un'interfaccia comune, in modo da poter gestire prodotti anche molto diversi tra loro all'interno di un'unica collezione.
(Breve citazione ad Animal Crossing :P)

## Struttura delle classi

- **`IPreparazione`** — interfaccia pubblica con la sola firma `void Prepara()`. Non contiene implementazione: è un "contratto" che chiunque la implementi deve rispettare.
- **`Caffe`** — classe base. Contiene le proprietà comuni (`Miscela`, `PrezzoAlChilo`, `GrammiConfezione`) e implementa `IPreparazione`.
- **`CaffeInCapsule : Caffe`** — classe derivata. Eredita tutto da `Caffe` e aggiunge i dettagli specifici delle capsule (`MaterialeCapsula`, `Compatibilita`, `PesoCapsula`, `PezzoConfezione`).
- **`Bevande`** — classe indipendente (non deriva da `Caffe`), ma implementa anch'essa `IPreparazione`. Rappresenta bevande solubili come cioccolata e orzo.
- **`Program`** — contiene il `Main`, crea il catalogo e lo stampa a schermo.

## Cosa è stato usato, e perché

| Elemento | Perché è stato usato |
|---|---|
| **Ereditarietà** (`CaffeInCapsule : Caffe`) | `CaffeInCapsule` *è un* `Caffe` più specializzato (relazione Is-a): condivide `Miscela` e `PrezzoAlChilo`, quindi ha senso ereditarli invece di riscriverli. |
| **Costruttore con `: base(...)`** | Il costruttore di `CaffeInCapsule` passa `miscela` e `prezzoAlChilo` al costruttore di `Caffe`, che è l'unico responsabile di inizializzare quei dati. |
| **`virtual` su `Prepara()`** | Permette alle classi figlie di ridefinire il comportamento di preparazione mantenendo la stessa firma del metodo. |
| **`override` su `Prepara()` e `ToString()`** | Sostituisce realmente il comportamento del metodo del padre (o di `Object`, per `ToString()`), non lo affianca. Grazie a questo, chiamare `Prepara()` o stampare l'oggetto esegue sempre la versione più specializzata disponibile (polimorfismo a runtime / late binding). |
| **Interfaccia `IPreparazione`** | Serve a mettere insieme, nella stessa collezione, prodotti che *non hanno nessuna parentela* (es. `Caffe` e `Bevande`), ma condividono la capacità di "prepararsi". Un'interfaccia si può implementare in numero illimitato, a differenza dell'ereditarietà che in C# è sempre singola. |
| **`List<IPreparazione>`** | Lista di dimensione dinamica (a differenza dell'array) che può contenere qualunque oggetto implementi `IPreparazione`, indipendentemente dalla sua classe reale. |
| **Pattern matching con `is` (`prodotto is CaffeInCapsule capsula`)** | Dentro il `foreach`, permette di controllare se l'oggetto corrente è di un tipo più specifico rispetto a `IPreparazione`, per poter accedere a proprietà/metodi che non fanno parte del contratto generale (es. `CostoCapsulaSingola()`). L'ordine dei controlli (`CaffeInCapsule` prima di `Caffe`) è fondamentale: essendo `CaffeInCapsule` anche un `Caffe`, se il controllo generico venisse prima, intercetterebbe già ogni capsula, impedendo di raggiungere il ramo specifico. |
| **`Console.ForegroundColor` / `Console.ResetColor()`** | Cambia il colore del testo stampato in console (qui `Cyan`); `ResetColor()` riporta il colore di default, per non "contaminare" le stampe successive. |
| **Stringa verbatim `@"..."`** | Il simbolo `@` prima delle virgolette dice al compilatore di trattare il testo così com'è, incluse le andate a capo, senza dover usare `\n` esplicitamente — comodo per blocchi di testo multilinea come l'ASCII art del piccione. |

## Metodi di calcolo

- `CostoConfezioneMoka()` — converte il prezzo al chilo in prezzo per la confezione, dividendo i grammi per 1000 e moltiplicando per il prezzo al kg.
- `CostoCapsulaSingola()` / `CostoConfezione()` — stesso principio, applicato al peso di una singola capsula e poi moltiplicato per il numero di pezzi nella confezione.
- `CostoConfezioneBevanda()` — identico principio applicato alle bevande solubili.

## Cosa dimostra, in sintesi

L'esercizio mette insieme **ereditarietà** (per modellare una vera parentela tra `Caffe` e `CaffeInCapsule`) e **interfacce** (per mettere in relazione classi che non sono parenti, come `Caffe` e `Bevande`, ma condividono un comportamento). Il `foreach` sulla lista dimostra il polimorfismo puro: la stessa riga `prodotto.Prepara()` esegue codice diverso a seconda dell'oggetto reale contenuto, decisione che C# prende solo a runtime (late binding).
