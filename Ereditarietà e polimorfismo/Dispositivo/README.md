# Esercizio 4 — Dispositivo/Smartphone/Televisore (Override vs Method Hiding)

## Obiettivo dell'esercizio

Mettere a confronto diretto **override** (`override`) e **method hiding** (`new`), mostrando come, a parità di dichiarazione della variabile (`Dispositivo`), i due meccanismi producano risultati completamente diversi a runtime.

## Struttura delle classi

- **`Dispositivo`** — classe base. Contiene il metodo `virtual Accendi()`, con un messaggio generico.
- **`Smartphone : Dispositivo`** — classe derivata. Fa un **vero override** di `Accendi()`.
- **`Televisore : Dispositivo`** — classe derivata. Usa la keyword **`new`** su `Accendi()`, creando un metodo separato che nasconde (senza sostituire) quello del padre.
- **`Program`** — contiene il `Main`, istanzia entrambe le classi dentro variabili dichiarate `Dispositivo` (upcasting implicito) e ne confronta il comportamento.

## Cosa è stato usato, e perché

| Elemento | Perché è stato usato |
|---|---|
| **`virtual` su `Dispositivo.Accendi()`** | Abilita la possibilità di fare un vero override nelle classi derivate. Senza questa keyword, nessuna delle due classi figlie potrebbe realmente sostituire il comportamento del metodo — al massimo potrebbero solo "nasconderlo". |
| **`override` in `Smartphone.Accendi()`** | Sostituisce realmente l'implementazione del padre. Attiva il **late binding**: a runtime, C# esegue sempre la versione corrispondente al tipo **reale** dell'oggetto, indipendentemente dal tipo con cui è dichiarata la variabile. |
| **`new` in `Televisore.Accendi()`** | Crea un metodo *parallelo* a quello del padre, con lo stesso nome ma **senza nessuna relazione di sostituzione**. Attiva l'**early binding** per quel metodo: la scelta di quale versione eseguire viene fatta guardando il tipo **della variabile**, non quello dell'oggetto. |
| **`Dispositivo phone = new Smartphone();`** e **`Dispositivo tv = new Televisore();`** | Entrambe le variabili sono dichiarate con il tipo più generico (`Dispositivo`), pur contenendo oggetti reali più specifici. Questa distinzione — tipo della variabile vs tipo dell'oggetto — è il fulcro concettuale di tutto l'esercizio. |

## Perché `phone.Accendi()` e `tv.Accendi()` si comportano in modo diverso

- **`phone.Accendi()`** → `Smartphone.Accendi()` è un `override` reale di un metodo `virtual`. A runtime, C# guarda il tipo **reale** dell'oggetto contenuto in `phone` (cioè `Smartphone`) ed esegue quella versione, anche se la variabile è dichiarata `Dispositivo`. Risultato: *"Schermo sbloccato, smartphone acceso!"*

- **`tv.Accendi()`** → `Televisore.Accendi()` usa `new`, quindi non sostituisce nulla: esistono due metodi `Accendi()` distinti e scollegati, uno in `Dispositivo` e uno in `Televisore`. Poiché la variabile `tv` è dichiarata `Dispositivo`, C# esegue la versione di `Dispositivo`, **ignorando** completamente quella di `Televisore`, anche se l'oggetto reale è proprio un televisore. Risultato: *"Il dispositivo si sta accendendo"* (non "Televisore acceso!").

Se `tv` fosse stata dichiarata direttamente come `Televisore tv = new Televisore();` (tipo variabile e tipo oggetto coincidenti), allora sì che sarebbe stata eseguita la versione di `Televisore`, perché con l'hiding statico la scelta dipende esclusivamente dal tipo dichiarato della variabile usata per l'accesso.

## Cosa dimostra, in sintesi

| | Override | New (Hiding) |
|---|---|---|
| Cosa fa | Sostituisce realmente il metodo del padre | Crea un metodo separato, con lo stesso nome |
| Quando si decide quale eseguire | A runtime (late binding) | A compile-time (early binding) |
| Cosa conta per la scelta | Il tipo **reale** dell'oggetto | Il tipo **dichiarato** della variabile |
| Risultato in questo esercizio | `Smartphone` → messaggio specifico | `Televisore` → messaggio generico del padre |

L'esercizio isola perfettamente il concetto più delicato del capitolo: a parità di sintassi di chiamata (`variabile.Accendi()`), il comportamento a runtime dipende interamente da *come* è stato scritto il metodo nella classe derivata (`override` oppure `new`), non da come viene chiamato nel `Main`.
