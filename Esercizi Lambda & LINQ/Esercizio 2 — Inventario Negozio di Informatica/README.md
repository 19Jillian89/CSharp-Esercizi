# Esercizio 2 — Inventario Negozio di Informatica

## Obiettivo
Gestire l'inventario di un negozio, trovando i componenti che rientrano nel budget del cliente ed effettivamente disponibili, ed estraendo solo i nomi.

## Struttura

### Classe `ComponentePC`
```csharp
public class ComponentePC
{
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public decimal Prezzo { get; set; }
    public bool PresenzaMagazzino { get; set; }
}
```
`Prezzo` è `decimal` (non `double`) perché si tratta di denaro: `decimal` evita gli errori di arrotondamento tipici del binario in virgola mobile, fondamentale quando si maneggiano prezzi.

## Passo dopo passo

### 1. Creazione dell'inventario
```csharp
List<ComponentePC> inventario = new List<ComponentePC>()
{
    new ComponentePC { Nome = "RAM", Categoria = "GPU", Prezzo = 555.50m, PresenzaMagazzino = false },
    new ComponentePC { Nome = "Monitor curvo", Categoria = "Monitor", Prezzo = 999.99m, PresenzaMagazzino = true },
    new ComponentePC { Nome = "Dissipatore", Categoria = "Alimentatori", Prezzo = 105.00m, PresenzaMagazzino = false },
    new ComponentePC { Nome = "Scheda di rete XX-XXX", Categoria = "Schede di rete", Prezzo = 56.00m, PresenzaMagazzino = false },
    new ComponentePC { Nome = "Intel Core 5", Categoria = "CPU", Prezzo = 309.98m, PresenzaMagazzino = true },
    new ComponentePC { Nome = "Filtro antipolvere", Categoria = "Ventole", Prezzo = 3.79m, PresenzaMagazzino = true },
};
```
6 componenti con prezzi e disponibilità variegati, per avere combinazioni sensate da filtrare (alcuni disponibili e economici, altri no).

> Nota: il suffisso `m` dopo i numeri (es. `555.50m`) indica al compilatore che quel valore è un `decimal` e non un `double`.

### 2. Filtro combinato + proiezione — `Where` + `Select`
```csharp
List<string> prodottiDisponibili = inventario
    .Where(component => component.Prezzo < 300 && component.PresenzaMagazzino)
    .Select(Component => Component.Nome)
    .ToList();
```
Qui si concatenano tre operazioni in sequenza (**method chaining**):
1. `Where` filtra i componenti che costano meno di 300€ **E** sono disponibili in magazzino (`&&` combina le due condizioni)
2. `Select` prende ogni componente filtrato e lo trasforma, prendendo solo la proprietà `Nome` (proiezione: da oggetto completo a semplice stringa)
3. `ToList()` converte il risultato (che di base è una sequenza "pigra"/enumerabile) in una vera `List<string>`, così puoi scorrerla o riusarla più volte

### 3. Controllo esistenza — `Any`
```csharp
bool prodottiTop = inventario.Any(component => component.Prezzo > 500);
```
`Any` risponde a una domanda sì/no: "esiste almeno un componente che costa più di 500€?". Non serve scorrere manualmente la lista con un ciclo e un flag booleano — `Any` lo fa internamente e restituisce direttamente `true`/`false`.

### 4. Stampa dei risultati
- I nomi dei prodotti economici e disponibili vengono stampati con un `foreach`
- Il risultato di `Any` viene usato in un `if/else` per stampare un messaggio diverso a seconda che esista o meno un prodotto sopra i 500€

## Concetti chiave usati
- **`decimal`** per i valori monetari, non `double`
- **`Where` con condizione composta** (`&&`) per filtrare su più criteri contemporaneamente
- **`Select`** per proiettare un oggetto complesso in un singolo valore (qui: da `ComponentePC` a `string`)
- **`ToList()`** per "materializzare" il risultato di una query LINQ in una collezione concreta
- **`Any`** per verificare l'esistenza di almeno un elemento che rispetta una condizione, senza doverli contare o stamparli tutti
