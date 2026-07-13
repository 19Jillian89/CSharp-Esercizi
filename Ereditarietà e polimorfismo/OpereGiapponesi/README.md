# Esercizio 2 — Catalogo Manga/Anime (Polimorfismo con lista unica)

## Obiettivo dell'esercizio

Dimostrare il polimorfismo a runtime creando una gerarchia di due classi diverse (`Manga` e `Anime`) che condividono una classe base comune (`OperaGiapponese`), e gestendole insieme in un'unica collezione tramite un ciclo `foreach`.

## Struttura delle classi

- **`OperaGiapponese`** — classe base. Contiene le proprietà comuni a qualsiasi opera (`Titolo`, `Autore`) e il metodo `virtual MostraInfo()`.
- **`Manga : OperaGiapponese`** — classe derivata. Aggiunge `VolumiRilasciati` e fa l'override di `MostraInfo()`.
- **`Anime : OperaGiapponese`** — classe derivata. Aggiunge `NumeroEpisodi` e `StudioAnimazione`, e fa anch'essa l'override di `MostraInfo()`.
- **`Program`** — contiene il `Main`, crea una lista mista di `Manga` e `Anime` e la cicla, dimostrando il polimorfismo.

## Cosa è stato usato, e perché

| Elemento | Perché è stato usato |
|---|---|
| **Ereditarietà singola da `OperaGiapponese`** | Sia `Manga` che `Anime` *sono* opere giapponesi (relazione Is-a): condividono `Titolo` e `Autore`, quindi questi dati vengono generalizzati nella classe base invece di essere duplicati in entrambe le classi figlie (principio DRY — Don't Repeat Yourself). |
| **Costruttori con `: base(titolo, autore)`** | Ogni costruttore di `Manga` e `Anime` inizializza prima la parte comune passandola al costruttore del padre, poi imposta le proprietà specifiche della propria classe. |
| **`virtual` su `MostraInfo()`** | Abilita il late binding: senza questa keyword, ridefinire `MostraInfo()` nelle classi figlie non produrrebbe un vero override, ma solo un metodo "nascosto" (hiding), rompendo il polimorfismo. |
| **`override` in `Manga.MostraInfo()` e `Anime.MostraInfo()`** | Sostituisce realmente il comportamento generico della classe base con uno specifico per ogni tipo di opera, mantenendo identica la firma del metodo. |
| **`List<OperaGiapponese>`** | Lista unica che può contenere sia oggetti `Manga` che `Anime`, perché entrambi sono, a tutti gli effetti, anche degli `OperaGiapponese` grazie all'ereditarietà. |
| **`foreach (OperaGiapponese opera in Lista)`** | Anche se la variabile del ciclo è dichiarata `OperaGiapponese` (tipo generico), a ogni iterazione C# esegue la versione di `MostraInfo()` corrispondente al tipo *reale* dell'oggetto — questo è il cuore del polimorfismo a runtime (late binding): la decisione su quale metodo eseguire viene presa durante l'esecuzione, non durante la compilazione. |
| **`new string('-', 60)`** | Crea una stringa ripetendo il carattere `'-'` per 60 volte, usata come separatore visivo tra un'opera e l'altra nell'output. |

## Cosa dimostra, in sintesi

Questo è l'esempio più "puro" di polimorfismo tra i quattro esercizi: un'unica variabile di ciclo, dichiarata con il tipo più generico (`OperaGiapponese`), che si comporta in modo diverso a ogni iterazione a seconda che contenga realmente un `Manga` o un `Anime`. Il codice del `foreach` non ha bisogno di sapere in anticipo "che cos'è" ogni elemento: è il meccanismo di `virtual`/`override` a occuparsene automaticamente a runtime.
