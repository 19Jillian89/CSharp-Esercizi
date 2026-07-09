# Esercizio 5 — VerificaFiltri (FiltriAcquario)

## 📋 Consegna

Scrivere un metodo `VerificaFiltri` che accetta un array di temperature (`double[]`) e:
- restituisce tramite parametro `out` il numero di anomalie (temperature fuori dal range 22.0–26.0)
- restituisce un `bool` (`true` se l'acquario è sicuro, `false` altrimenti)
- (facoltativo) restituisce tramite un altro `out` la matrice con le anomalie corrette a 22

## 🧠 Spiegazione concetti

### Perché servono i parametri `out`
Un metodo ha **un solo** valore di ritorno dichiarato con `return`. Qui però servono **3 informazioni in uscita**: il `bool` "è sicuro?", il conteggio delle anomalie (`int`) e l'array corretto (`double[]`). `out` permette di restituire dati aggiuntivi oltre al `return` principale, mantenendo tipi diversi per ciascun output.

```csharp
static bool VerificaFiltri(double[] temperature, out int anomalie, out double[] tempCorrette)
```

Regola fondamentale: un parametro `out` **deve** essere assegnato dentro il metodo prima che questo termini, altrimenti il codice non compila.

### Funzione locale vs metodo di classe
`VerificaFiltri` è dichiarata **dentro** `Main` (funzione locale, sintassi valida da C# 7 in poi), invece che come metodo separato della classe `Program`. Funziona correttamente, ma è uno stile meno comune: di solito si preferisce un metodo separato quando la logica rappresenta un concetto riutilizzabile a sé stante (più facile da richiamare da altri punti del programma).

### Ciclo di verifica e correzione
```csharp
for (int i = 0; i < temperature.Length; i++)
{
    double temp = temperature[i];

    if (temp < 22 || temp > 26)
    {
        anomalie++;
        tempCorrette[i] = 22.0;
        Console.WriteLine($"Anomalia riscontrata: la temperatura in posizione {i} è di {temp} gradi!");
    }
    else
    {
        tempCorrette[i] = temp;
    }
}
```
Per ogni temperatura fuori dal range `[22.0, 26.0]`: si incrementa il contatore, si "corregge" il valore nell'array di output a 22.0, e si stampa un messaggio che indica **quale** posizione specifica è anomala (aggiunta utile oltre al requisito minimo della consegna, che chiedeva solo il conteggio totale).

### Il valore di ritorno booleano
```csharp
bool sicuro = (anomalie == 0);
return sicuro;
```
L'acquario è considerato sicuro solo se **nessuna** temperatura è fuori range.

### Come si richiama nel Main
```csharp
bool acquarioSicuro = VerificaFiltri(tempIniziali, out int anomalie, out double[] tempCorrette);
```
Le variabili `anomalie` e `tempCorrette` vengono dichiarate **inline** al momento della chiamata (sintassi C# 7+), senza doverle dichiarare separatamente prima.

## 🔍 Esempio di esecuzione

Con `tempIniziali = { 23.0, 25.0, 24.0, 22.0, 30.0 }`:

| Temperatura | Fuori range? | Valore corretto |
|---|---|---|
| 23.0 | no | 23.0 |
| 25.0 | no | 25.0 |
| 24.0 | no | 24.0 |
| 22.0 | no | 22.0 |
| 30.0 | **sì** (> 26) | 22.0 |

**Output:**
```
Anomalia riscontrata: la temperatura in posizione 4 è di 30 gradi!
Acquario sicuro: False
Acquario con anomalie: 1
```

## ⚠️ Nota sulla logica di correzione "a 22"

La consegna, nell'esempio fornito, specifica che **ogni** anomalia (sia sopra 26 che sotto 22) viene riportata a **22.0** — non a 26.0 come ci si aspetterebbe logicamente per un valore troppo alto. Il codice segue questa indicazione alla lettera. Se si volesse invece una correzione "a specchio" (valore basso → alzato a 22, valore alto → abbassato a 26), si potrebbe usare:

```csharp
if (temp < 22)
    tempCorrette[i] = 22.0;
else if (temp > 26)
    tempCorrette[i] = 26.0;
else
    tempCorrette[i] = temp;
```

oppure, in modo più compatto, `Math.Clamp(temp, 22.0, 26.0)`.
