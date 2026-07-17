# Esercizio 3 — Negozio di Abbigliamento (Sconti)

## Obiettivo
Filtrare i capi di un determinato reparto, ordinarli per prezzo e applicare uno sconto del 20%, restituendo il risultato come stringa formattata.

## Struttura

### Classe `Abbigliamento`
```csharp
public class Abbigliamento
{
    public string Modello { get; set; }
    public string Reparto { get; set; }
    public int Disponibilita { get; set; }
    public decimal PrezzoOriginale { get; set; }
}
```
Anche qui `PrezzoOriginale` è `decimal` per lo stesso motivo dell'esercizio 2 (denaro = niente `double`). `Disponibilita` è stata aggiunta come proprietà extra rispetto alla traccia base, per tenere traccia delle quantità in magazzino.

## Passo dopo passo

### 1. Creazione dell'inventario
```csharp
List<Abbigliamento> inventario = new List<Abbigliamento>
{
    new Abbigliamento { Modello = "Jeans", Reparto = "Donna", Disponibilita = 5, PrezzoOriginale = 39.99m},
    new Abbigliamento { Modello = "Minigonna", Reparto = "Donna", Disponibilita = 7, PrezzoOriginale = 19.99m},
    new Abbigliamento { Modello = "Reggiseno", Reparto = "Donna", Disponibilita = 2, PrezzoOriginale = 9.99m},
    new Abbigliamento { Modello = "T-Shirt", Reparto = "Donna", Disponibilita = 3, PrezzoOriginale = 5.00m},
    new Abbigliamento { Modello = "Cappotto", Reparto = "Donna", Disponibilita = 2, PrezzoOriginale = 109.99m},
    new Abbigliamento { Modello = "Calzini", Reparto = "Donna", Disponibilita = 6, PrezzoOriginale = 2.99m}
};
```
6 capi, tutti nel reparto "Donna" con prezzi diversi, per avere qualcosa di sensato da ordinare.

### 2. Filtro + ordinamento + trasformazione in un'unica catena
```csharp
var articoloScontato = inventario
    .Where(capo => capo.Reparto == "Donna")
    .OrderBy(capo => capo.PrezzoOriginale)
    .Select(capo => $"Modello: {capo.Modello} - Prezzo Scontato: {capo.PrezzoOriginale * 0.80m:F2}€");
```
Tre operazioni concatenate, eseguite **in ordine**:
1. `Where(capo => capo.Reparto == "Donna")` → tiene solo i capi del reparto "Donna" (confronto tra stringhe con `==`, non basta scrivere `capo.Reparto` da solo perché non è un `bool`)
2. `OrderBy(capo => capo.PrezzoOriginale)` → ordina il risultato filtrato dal più economico al più costoso
3. `Select(capo => $"...")` → trasforma ogni capo in una stringa formattata già pronta per la stampa, calcolando lo sconto del 20% al volo: `capo.PrezzoOriginale * 0.80m` (pagare l'80% = sconto del 20%), formattato con `:F2` per avere sempre 2 decimali (es. `31,99` invece di `31.992`)

### 3. Stampa del risultato
```csharp
foreach (var sconto in articoloScontato)
{
    Console.WriteLine(sconto);
}
```
Dato che `Select` ha già prodotto direttamente delle stringhe pronte, il `foreach` si limita a stamparle una per una, senza bisogno di ricostruire il formato in questo punto.

## Concetti chiave usati
- **Method chaining**: `Where` → `OrderBy` → `Select` in sequenza, ognuno lavora sul risultato del precedente
- **`Where` su stringhe**: confronto con `==`, non basta il valore della proprietà da solo
- **`:F2`** nella stringa interpolata per forzare 2 cifre decimali (utile per i prezzi)
- **`Select` che produce stringhe già formattate**, non solo dati grezzi — utile quando il risultato deve essere "pronto per la stampa"
