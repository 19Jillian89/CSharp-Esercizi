using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

/********ESERCIZIO SLIDE 1*********/

//dichiarato una variabile intera e poi ho usato typeof per verificare che il tipo int
//corrisponde internamente a Int32, cioè un intero a 32 bit.
int numero = 15;
Console.WriteLine($"Il numero è: {numero} ");

Type type = typeof(int);
Console.WriteLine(type.Name);
Console.WriteLine();

/**********ESERCIZIO SLIDE 2*********/

//richiesta dati all'utente
//Console.ReadLine() è un metodo statico della classe Console che sospende l'esecuzione del programma
//in attesa che l'utente digiti del testo e prema Invio.
//Restituisce sempre un valore di tipo string — anche se l'utente digita solo numer
Console.WriteLine("Inserisci il nome: ");
string nome = Console.ReadLine();

Console.WriteLine("Inserisci il cognome: ");
string cognome = Console.ReadLine();

Console.WriteLine("Inserisci la data di nascita nel formato mm/gg/aaaa: ");
string inputData = Console.ReadLine();

//DateTime è una struct (un tipo valore, non una classe) del namespace System, che rappresenta un istante preciso nel tempo — data e ora insieme,
//con precisione fino al centesimo di millisecondo.
//Espone diverse proprietà per leggere singole componenti (.Year, .Month, .Day, .Hour...)
//e diversi metodi statici per crearne istanze in modi diversi.
//Parse = trasforma il testo grezzo della data in un oggetto strutturato su cui puoi fare calcoli

//ALTERNATIVS SEMPLICE (senza gestioni degli errori)
/*DateTime dataNascita = DateTime.Parse(inputData);*/


//VERSIONE CON GESTIONE ERRORI: faccio conversione stringa (inputData) con try. Salvo risultato in dataNascita
//se fallisce catturo l'eccezione! Ed esco dal programma
DateTime dataNascita;

try
{
    dataNascita = DateTime.Parse(inputData);
}
catch (FormatException) //Nome che C# dà a un errore specifico, si verifica quando converti una stringa in un altro dato
{
    Console.WriteLine("Errore! La data inserita non è valida!");
    return;
}

DateTime today = DateTime.Now; //Prendo la data odierna dal sistema

int eta = today.Year - dataNascita.Year; //Calcolo l'età in anni

//today.Month < dataNascita.Month → "il mese attuale è prima del mese di nascita"
// || → "oppure"
// (today.Month == dataNascita.Month && today.Day < dataNascita.Day) → "siamo nello stesso mese,
// e il giorno attuale è prima del giorno di nascita"
// (nota: dentro le parentesi ho un &&, quindi entrambe queste due condizioni devono essere vere insieme)
//eta-- → "tolgo 1 all'età"
//in entrambi i casi, tolgo un anno all'età con eta-- (nati a dicembre, oggi è luglio, il mio compleanno non è ancora arrivè)
if (today.Month < dataNascita.Month || 
    (today.Month == dataNascita.Month && today.Day < dataNascita.Day))
    eta--;

Console.WriteLine(today);

int seiMaggiorenne = dataNascita.Year + 18;

if (eta >= 18)
{
    Console.WriteLine("Puoi prendere la patente");
}
else if (today.Year == seiMaggiorenne)
{
    Console.WriteLine("Riprova fra qualche giorno o mese");
}
else 
{
    int anniMancanti = 18 - eta;
    Console.WriteLine($"Non puoi prendere la patente, ti mancano {anniMancanti} anni");
}
Console.WriteLine();

/**********ESERCIZIO 2 PDF*********/


/*-----HO SPOSTATO LA CLASSE IN FONDO ALTRIMENTI MI DAVA ERRORE QUANDO COMPILAVO-------*/
//La lascio commentata per far vedere l'esercizio tutto insieme

//Classe Alieno + scelta attributi
/*public class Alieno
{
    public string Name { get; set; }
    public string Pianeta { get; set; }
    public string Telefono { get; set; }
    public bool Ostile { get; set; }
    public int? Energia { get; set; } //siccome il terzo alieno non deve fornirla, è nullable

    //costruttore
    public Alieno(string name, string pianeta, bool ostile, int? energia, string telefono) 
    {
        Name = name;
        Pianeta = pianeta;
        Ostile = ostile;
        Energia = energia;
        Telefono = telefono ?? "Sconosciuto"; //gestisce caso in cui non venga fornito numero di telefono con un valore di default
    }
    
    public void DataAlien() 
    {
        Console.WriteLine($"Name: {Name}, Energia: {Energia}, Ostile: {Ostile}, Pianeta: {Pianeta}, Telefono: {Telefono}");
    }

    public bool EnergiaOstile()
    {
        return Energia > 150 && Ostile; // La condizione unisce due controlli con && (AND logico): entrambi devono essere veri (energia sopra 150 e ostile) perché il metodo dia true.
    }*/

//creo i primi due alieni e gli passo i 5 parametri
Alieno a1 = new Alieno("Olaf", "Marte", true, 200, "065633333");
        Alieno a2 = new Alieno("Pingu", "Saturno", false, 85, null); //non metto il telefono

        a1.DataAlien();
        a2.DataAlien();

        //1) stampare se si tratta di un alieno ostile o amico
        //operatore ternario per controllare la proprietà Ostile dell'alieno:
        //se è true, stampo che l'alieno è ostile; se è false, stampo che è amico
        Console.WriteLine(a1.Ostile ? $"{a1.Name} è ostile" : $"{a1.Name} è amico");
        Console.WriteLine(a2.Ostile ? $"{a2.Name} è ostile" : $"{a2.Name} è amico");

        //2) Controllare la loro energia e dire quale dei due ha più energia vitale
        if (a1.Energia > a2.Energia)
            Console.WriteLine($"{a1.Name} ha molta energia.");
        else
            Console.WriteLine($"{a2.Name} ha molta energia.");

        //3) Incrementare l’energia vitale dell’alieno con energia più bassa della metà dell’energia dell’alieno che ha energia più alta.
        // Prendo l'energia attuale di a2, ci aggiungo sopra metà dell'energia di a1, e salva il risultato come nuova energia di a2".
        // Il += è quello che fa fisicamente il trasferimento: prende il valore calcolato dalla divisione e lo somma a quello che alieno2 aveva già.
        // diviso 2 perchè così prende la metà
        if (a1.Energia > a2.Energia)
            a2.Energia += a1.Energia / 2;
        else
            a1.Energia += a2.Energia / 2;

        Console.WriteLine($"L'energia adesso è: {a1.Name}: {a1.Energia}, {a2.Name}: {a2.Energia}");

        //4) Creare un terzo alieno senza inserire l’energia e stampare l’energia in intero senza creare eccezioni
        //a3.Energia è di tipo int? (nullable), non un int puro. Se provo a mettere direttamente un int? dove serve un int
        //senza gestire il caso null, si creano problemi.
        //Con ?? 0 dico: "se è null, usa 0 come valore intero di riserva" — così ottengo un vero int 
        Alieno a3 = new Alieno("Bob", "Venere", false, null, null);
        int energiaA3 = a3.Energia ?? 0;
        Console.WriteLine($"L'energia di {a3.Name} (int): {energiaA3}");

        //5) Controllare se il tipo del 3 alieno è un Alieno
        //Costrutto (IS + Pattern Matching) in cui, se TUTTE le condizioni risultano verificate (vere), il codice viene eseguito
        object obj = a3;
        if (obj is Alieno)
            Console.WriteLine($"{a3.Name} è proprio un Alieno!");

        //6) Confrontare il nome dei 3 alieni e verificare se sono uguali o meno.
        // se string è un reference type, == su stringhe confronta il contenuto (lettera per lettera), non l'indirizzo in memoria
        Console.WriteLine(a1.Name == a2.Name ? "Sono nomi uguali" : $"{a1.Name} e {a2.Name}: nomi diversi");//Confronto il nome di a1 con il nome di a2
        Console.WriteLine(a1.Name == a3.Name ? "Sono nomi uguali" : $"{a1.Name} e {a3.Name}: nomi diversi");
        Console.WriteLine(a2.Name == a3.Name ? "Sono nomi uguali" : $"{a2.Name} e {a3.Name}: nomi diversi");

        //7) Metodo: energia > 150 (ostile)
        Console.WriteLine($"{a1.Name} questo Alieno è ostile? {a1.EnergiaOstile()}");

        //8) operatore ternario per verificare se viene da Marte
        //Confronto il pianeta di a1 con la stringa 'Marte': se sono uguali, stampo che a1 viene da Marte;
        //altrimenti, stampo che non ne viene."
        Console.WriteLine(a1.Pianeta == "Marte" ? $"{a1.Name} viene da Marte" : $"{a1.Name} non viene da Marte");

/***********ESERCIZIO 3 PDF***********/

string Nome = "Leila";
Nome.ToUpper(); // Converte la stringa in maiuscolo
Console.WriteLine(Nome); //Stampa "Leila" :) perché ToUpper() non modifica la stringa originale, ma restituisce una nuova stringa in maiuscolo

/*avremmo potuto fare così: 
 * string Nome = "Leila";
 * string nomeMaiuscolo = Nome.ToUpper();
 * Console.WriteLine("Prima della conversione: " + Nome); 
 * Console.WriteLine("Dopo la conversione: " + nomeMaiuscolo); //Stampa "LEILA"
 */
Console.WriteLine();

/***********ESERCIZIO 4 PDF***********/

string[] parole = { "gatto", "baffi", "tiragraffi", "meow", "fusa", "tiragraffi", "croccantini", 
    "pappa", "ciambella", "zampette", "miagolio", "coccolosi", "scatola", "cuccia", "morbidosi" };

//stampare le ultime 10 parole
string[] ultime10 = parole[5..];
Console.WriteLine("Ultime 10 parole: " + string.Join(", ",ultime10)); //uso metodo string.Join per unire le parole in un'unica stringa separata da virgole

//stampare le prime5 parole
string[] prime5 = parole[..5];
Console.WriteLine("Prime 5 parole: " + string.Join(", ", prime5)); //uso metodo string.Join per unire le parole in un'unica stringa separata da virgole

//stampare solo le parole che vanno dalla 4arta alla 8ava
string[] dalla4Alla8 = parole[3..8];
Console.WriteLine("Dalla quarta alla ottava: " + string.Join(", ", dalla4Alla8)); //uso metodo string.Join per unire le parole in un'unica stringa separata da virgole

Console.WriteLine(); //ho creato una riga per creare uno spazio, tutto attaccato

//SUB ARRAY - FOR
Console.WriteLine("SUB ARRAY - FOR");
//Uso un ciclo for per stampare le parole degli array.
//Cicli usando "i" finchè i è minore della lunghezza del sub-array.
// i < ultime10.Length; -> "Parti da zero (i = 0) e continua a stampare le parole
// finché non arrivi alla fine dell'array"
for (int i = 0; i < ultime10.Length; i++)
    Console.WriteLine(ultime10[i]);

for (int i = 0; i < prime5.Length; i++)
    Console.WriteLine(prime5[i]);

for (int i = 0; i < dalla4Alla8.Length; i++)
    Console.WriteLine(dalla4Alla8[i]);

Console.WriteLine(); //come sopra

//SUB ARRAY - FOREACH
Console.WriteLine("SUB ARRAY - FOREACH");
//Foreach non utilizza indici, scorre direttamente l'array
foreach (string parola in ultime10) //Per ogni stringa parola dentro l'array ultime10, stampo parola
    Console.WriteLine(parola);

foreach (string parola in prime5)
    Console.WriteLine(parola);

foreach (string parola in dalla4Alla8)
    Console.WriteLine(parola);
Console.WriteLine();

/***********ESERCIZIO 5 PDF***********/


int x = 16; //Binario: 00010000
int risultatoDx = x >> 1;  //Shift a destra di 1 bit: 00001000 = 8
Console.WriteLine($"16 >> 1 = {risultatoDx}"); // 8 -> 16/2 = 8

int y = 20; // binario: 00010100
int risultatoSx = y << 1; //Shift a sinistra di 1 bit: 00101000 = 40
Console.WriteLine($"20 << 1 = {risultatoSx}"); // 40 -> 20*2 = 40


/*------------------------------------------------*/

//Classe Alieno + scelta attributi
public class Alieno
{
    public string Name { get; set; }
    public string Pianeta { get; set; }
    public string Telefono { get; set; }
    public bool Ostile { get; set; }
    public int? Energia { get; set; } //siccome il terzo alieno non deve fornirla, è nullable

    //costruttore
    public Alieno(string name, string pianeta, bool ostile, int? energia, string telefono)
    {
        Name = name;
        Pianeta = pianeta;
        Ostile = ostile;
        Energia = energia;
        Telefono = telefono ?? "Sconosciuto"; //gestisce caso in cui non venga fornito numero di telefono con un valore di default
    }

    public void DataAlien()
    {
        Console.WriteLine($"Name: {Name}, Energia: {Energia}, Ostile: {Ostile}, Pianeta: {Pianeta}, Telefono: {Telefono}");
    }

    public bool EnergiaOstile()
    {
        return Energia > 150 && Ostile; // La condizione unisce due controlli con && (AND logico): entrambi devono essere veri (energia sopra 150 e ostile) perché il metodo dia true.
    }
}
