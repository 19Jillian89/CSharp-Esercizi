# Esercizio 4 — Text Processing (Changes)

## 📋 Consegna

Dato un testo con un nome errato: rimuoverlo se presente. Sostituire la parola "prezzo" con "prz". Convertire un prezzo testuale (es. "€250") in intero ed effettuare un elevamento a potenza.

## 🧠 Spiegazione concetti

### `Contains()` — verifica prima di agire
```csharp
if (testo.Contains(nomeErrato))
```
Restituisce `bool`: verifica se una sottostringa è presente prima di procedere con la sostituzione. Evita di eseguire `Replace` "alla cieca" quando non serve.

### `Replace()` con parentesi graffe nell'`if`
```csharp
if (testo.Contains(nomeErrato))
{
    testo = testo.Replace("Osvalda", "").Trim();
    Console.WriteLine("Nome errato rimosso!\n");
}
```
⚠️ Punto chiave: le **graffe sono necessarie** quando si vuole eseguire più di un'istruzione dentro l'`if`. Senza `{ }`, solo la prima riga sotto l'`if` sarebbe condizionata — la `Console.WriteLine` verrebbe eseguita **sempre**, anche a condizione falsa.

### Perché serve riassegnare il risultato
```csharp
testo = testo.Replace("Osvalda", "").Trim();
```
Le stringhe sono **immutabili**: `Replace()` e `Trim()` non modificano `testo` "sul posto", restituiscono una **nuova stringa**. Se non si riassegna il risultato a `testo`, la variabile originale resta invariata.

### Conversione: `Replace()` sul simbolo giusto
```csharp
string nuovoPrezzo = valoreDaCambiare.Replace("€", "").Trim();
int numero = int.Parse(nuovoPrezzo);
```
Qui si rimuove il simbolo `€` (non il numero!) per ottenere una stringa puramente numerica (`"250"`), convertibile con `int.Parse()`. Attenzione a non confondere: `Replace("250", "")` cancellerebbe il numero stesso, lasciando una stringa vuota che `int.Parse()` non potrebbe convertire (`FormatException`).

### `Math.Pow()` — elevamento a potenza
```csharp
double result = Math.Pow(numero, 2); // numero al quadrato
```
Restituisce sempre un `double`, anche se gli argomenti sono interi.

## 🔍 Esempio di esecuzione

Con `testo` e `valoreDaCambiare` dell'esempio:
```
Prima: Ciao Osvalda! Se sei interessata a questo prodotto, il suo prezzo è di €250

Nome errato rimosso!
Parola sostituita!
Dopo: Ciao ! Se sei interessata a questo prodotto, il suo prz è di €250

Prezzo convertito: 250
250 con l'operazione di elevamento a potenza diventa: 62500
```
