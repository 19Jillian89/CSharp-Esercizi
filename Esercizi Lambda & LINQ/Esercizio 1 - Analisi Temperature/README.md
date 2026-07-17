# Esercizio 1 — Il Clima (Analisi Temperature)

## Obiettivo
Analizzare i dati meteo di diverse città per individuare situazioni di allerta caldo e per ordinare le città in base alla temperatura.

## Struttura

### Classe `Citta`
```csharp
public class Citta
{
    public string Nome { get; set; }
    public double Temperature { get; set; }
    public double Umidita { get; set; } // es. 70 => "70%"
}
```
Tre proprietà semplici: nome, temperatura e umidità (espressa come numero, poi formattata con `%` in stampa).

## Passo dopo passo

### 1. Creazione della lista di città
```csharp
List<Citta> meteo = new List<Citta>()
{
    new Citta{ Nome = "Roma", Temperature = 35.0, Umidita = 70},
    new Citta{ Nome = "Bologna", Temperature = 31.5, Umidita = 55},
    new Citta{ Nome = "Perugia", Temperature = 37.0, Umidita = 27},
    new Citta{ Nome = "Lucca", Temperature = 29, Umidita = 46},
    new Citta{ Nome = "Bressanone", Temperature = 28.5, Umidita = 36}
};
```
5 città con temperature volutamente miste: 3 sopra i 30°C (Roma, Bologna, Perugia) e 2 sotto (Lucca, Bressanone), per avere dati sensati da filtrare.

### 2. Filtro allerta caldo — `Where`
```csharp
var allertaCaldo = meteo.Where(c => c.Temperature > 30);
```
`Where` scorre la lista e tiene solo le città la cui `Temperature` supera i 30°C. La lambda `c => c.Temperature > 30` è la condizione di filtro: per ogni città `c`, viene valutata l'espressione booleana e solo se è `true` la città resta nel risultato.

### 3. Ordinamento crescente — `OrderBy`
```csharp
var cittaPiuFredde = meteo.OrderBy(c => c.Temperature);
```
Ordina l'intera lista originale (non quella filtrata) dalla temperatura più bassa alla più alta.

### 4. Ordinamento decrescente — `OrderByDescending`
```csharp
var cittaPiuCalde = meteo.OrderByDescending(c => c.Temperature);
```
Stessa lista, ma ordinata dalla più calda alla più fredda — utile per confrontare i due ordinamenti.

### 5. Stampa dei risultati
Ogni collezione (`allertaCaldo`, `cittaPiuFredde`, `cittaPiuCalde`) viene scorsa con un `foreach` e stampata a schermo con nome, temperatura e umidità.

## Concetti chiave usati
- **`Where`**: filtro basato su una condizione booleana (lambda che restituisce `bool`)
- **`OrderBy` / `OrderByDescending`**: ordinamento crescente/decrescente in base a una proprietà
- **Lambda di espressione**: `c => c.Temperature > 30` — una condizione secca, senza bisogno di blocchi `{ }` o `return`
