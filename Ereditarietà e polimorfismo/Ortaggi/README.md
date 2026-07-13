# Esercizio 3 — Ortaggio/Pomodoro (Incapsulamento e `protected`)

## Obiettivo dell'esercizio

Dimostrare la differenza tra **ereditarietà** e **visibilità**: una classe figlia eredita un dato protetto dalla classe base, ma non può modificarlo liberamente dall'esterno (es. dal `Main`) — può farlo solo passando per un metodo pubblico pensato apposta.

## Struttura delle classi

- **`Ortaggio`** — classe base. Contiene la variabile `protected string statoCrescita`, inizializzata a `"Seminato"`, la proprietà pubblica `Nome`, e il metodo pubblico `VerificaCrescita()` che restituisce lo stato attuale in sola lettura.
- **`Pomodoro : Ortaggio`** — classe derivata. Espone il metodo pubblico `Irriga()`, l'unico modo per far avanzare `statoCrescita` da `"Seminato"` a `"In Fioritura"` fino a `"Maturo"`.
- **`Program`** — contiene il `Main`, crea un `Pomodoro` e ne innaffia la crescita chiamando `Irriga()` più volte.

## Cosa è stato usato, e perché

| Elemento | Perché è stato usato |
|---|---|
| **`protected string statoCrescita`** | Rende la variabile visibile a `Ortaggio` stesso e a tutte le classi che ne derivano (come `Pomodoro`), ma **non** dall'esterno (né dal `Main`, né da altre classi non imparentate). È il modificatore corretto per l'ereditarietà: più aperto di `private` (che bloccherebbe anche `Pomodoro`), più chiuso di `public` (che lo esporrebbe a chiunque). |
| **Ereditarietà (`Pomodoro : Ortaggio`)** | `Pomodoro` *è un* `Ortaggio` (relazione Is-a): eredita `statoCrescita` e `Nome` senza doverli ridefinire. |
| **Costruttore con `: base(nome)`** | Il costruttore di `Pomodoro` riceve il nome e lo gira al costruttore di `Ortaggio`, che è quello responsabile di inizializzare `Nome`. Senza questo passaggio, il compilatore darebbe errore, perché `Ortaggio` non ha un costruttore vuoto disponibile. |
| **Metodo pubblico `Irriga()`** | È l'unica "porta d'accesso" che permette di modificare `statoCrescita` dall'esterno della gerarchia. Dentro il metodo, essendo `Pomodoro` una classe figlia, l'accesso a `statoCrescita` è invece diretto e legittimo, perché il campo è `protected`. |
| **`if / else if / else` su stringhe** | Gestisce la progressione a stati (`"Seminato"` → `"In Fioritura"` → `"Maturo"`), confrontando il valore corrente di `statoCrescita` e aggiornandolo di conseguenza a ogni chiamata di `Irriga()`. |
| **Metodo pubblico `VerificaCrescita()`** | Espone lo stato in sola lettura dall'esterno, senza dare la possibilità di modificarlo direttamente — un dato protetto rimane sempre "difeso", anche quando serve solo leggerlo. |

## Cosa NON è possibile fare (e perché è corretto così)

```csharp
// pomodoro.statoCrescita = "Maturo";
```

Questa riga, se scritta nel `Main`, **non compila**: il compilatore restituisce un errore di violazione del livello di protezione (`statoCrescita is inaccessible due to its protection level`). Questo è esattamente il comportamento voluto dall'esercizio: dimostra che l'ereditarietà (avere il dato "dentro" l'oggetto) è un concetto diverso dalla visibilità (poterlo toccare direttamente). L'unico modo legittimo di farlo avanzare è passare da `Irriga()`.

## Cosa dimostra, in sintesi

L'esercizio isola un concetto puntuale ma centrale dell'incapsulamento: un campo `protected` permette la condivisione dei dati lungo la gerarchia di ereditarietà, ma continua a proteggerli da manipolazioni dirette provenienti dall'esterno, obbligando chi usa l'oggetto a passare attraverso un'interfaccia pubblica controllata (in questo caso, il metodo `Irriga()`).
