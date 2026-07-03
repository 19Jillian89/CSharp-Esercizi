
//ESERCIZIO 1

/* ------Prima parte ------ */

double xDouble = 123.78;
int yInt = (int)xDouble; // Conversione esplicita tramite cast, int non contiene decimali quindi il valore viene troncato 

Console.WriteLine($"Il valore di x è: {xDouble}"); // Stampa il valore di xDouble
Console.WriteLine($"Il valore di y è: {yInt}"); // Stampa il valore di yInt, versione convertita

Console.WriteLine(xDouble.GetType()); //vede a runtime il tipo di xDouble
Console.WriteLine(yInt.GetType()); //vede a runtime il tipo di yInt

/* ------ Seconda parte ------ */

int numInt = 150;
double numDouble = numInt; // Conversione implicita, il tipo double può contenere tutti i valori di int

Console.WriteLine($"Il valore di numInt è: {numInt}");
Console.WriteLine($"Il valore di numDouble è: {numDouble}");

Console.WriteLine(numInt.GetType());  //vede a runtime il tipo di numInt
Console.WriteLine(numDouble.GetType()); //vede a runtime il tipo di numDouble

/* ------ Terza parte ------*/

//char -> int
char lettera = 'I';
int isAscii = lettera; // Conversione implicita, il tipo int può contenere tutti i valori di char

Console.WriteLine($"Char 'I' diventa: {isAscii}"); // Stampa il valore ASCII del carattere 'I', ovvero 73

//int → double
int number = 42;
double nowDouble = number; //Conversione implicita, il tipo double può contenere tutti i valori di int

Console.WriteLine($"Int 42 diventa: {nowDouble}"); // Stampa il valore double equivalente a 42, ovvero 42.0

//double → int
double aDouble = 42.56;
int isInt = (int)aDouble; // Conversione esplicita tramite cast, come prima parte dell'esercizio

Console.WriteLine($"Double 42.56 diventa: {isInt}"); // Stampa il valore int equivalente a 42.56, ovvero 42

//int → char
int asciiNum = 82;
char isChar = (char)asciiNum; // Conversione esplicita tramite cast

Console.WriteLine($"Int 82 diventa: {isChar}"); // Stampa il carattere equivalente al valore ASCII 82, ovvero 'R'

//ESERCIZIO 2

int eta = 37;  //int va bene perché l'età è un numero intero
double altezza = 1.69; //uso il double per l'altezza perché serve più precisione, il float non è abbastanza preciso
float voto = 7.5f; //per il float si mette la f alla fine del numero, lo uso per i voti perché non serve tanta precisione
decimal prezzo = 44.99m; //per i soldi si usa il decimal, più preciso

char iniziale = 'I'; //char va bene perché è un solo carattere
bool isMaggiorenne = true; //bool è vero o falso, va bene per sapere se sono maggiorenne o no
string nome = "Ilaria"; //string va bene per il nome, perché è una sequenza di caratteri

Console.WriteLine($"La mia eta è: {eta}"); // Stampa l'età
Console.WriteLine($"La mia altezza è: {altezza}"); // Stampa l'altezza
Console.WriteLine($"Il mio voto è: {voto}"); // Stampa il voto
Console.WriteLine($"Il prezzo è: {prezzo}"); // Stampa il prezzo
Console.WriteLine($"La mia iniziale è: {iniziale}"); // Stampa l'iniziale
Console.WriteLine($"Sono maggiorenne? {isMaggiorenne}"); // Stampa se è maggiorenne o no
Console.WriteLine($"Mi chiamo: {nome}"); // Stampa il nome

//ESERCIZIO 3

string Nome = "Ilaria";
string Cognome = "Nassi";
string NomeCompleto = Nome + " " + Cognome; // Concatenazione delle stringhe e metto lo spazio tra Nome e Cognome

Console.WriteLine($"Il mio nome e cognome sono: {NomeCompleto}"); //Ilaria Nassi :)

//ESERCIZIO 4

var x; //deve essere inizializzato altrimenti il compilatore non sa che tipo di variabile è

var y = null; //come sopra, null non è un tipo, quindi non può essere assegnato a una variabile di tipo var

int numero = null; //int è un value type, non può contenere null, servirebbe int? numero = null; per renderlo nullable

char c = "A"; //è sbagliato perché il char deve essere tra apici singoli

float f = 3.14; //è sbagliato perché il float deve avere la f alla fine del numero

decimal prezzo = 15.5; //è sbagliato perché il decimal deve avere la m alla fine del numero

//ESERCIZIO 5
public class Cinema
{
    private const int postiSala = 130;
    public string Nome { get; set; }
    public int NumeroSale { get; set; }
    public int PostiDisponibili { get; set; }

    public Cinema(string Nome, int NumeroSale, int PostiDisponibili)
    {
        this.Nome = Nome;
        this.NumeroSale = NumeroSale;
        this.PostiDisponibili = PostiDisponibili;
    }

    public void MostraInformazioni()
    {
        Console.WriteLine($"Cinema: {Nome}, Sale: {NumeroSale}");
    }

    public int PostiTotali()
    {
        return NumeroSale * postiSala;
    }

    public int PostiLiberi()
    {
        return PostiTotali() - PostiDisponibili;
    }
    //creo istanza (new) cinema con nome, numero di sale e posti disponibili, 5 sale, 45 posti occupati
    Cinema romaCinema = new Cinema("Multisala Colosseo", 10, 45);
    romaCinema.MostraInformazioni(); //richiamo il metodo per mostrare le informazioni del cinema
    Console.WriteLine($"Posti totali: {romaCinema.PostiTotali()}"); //richiamo il metodo per mostrare i posti totali
    Console.WriteLine($"Posti liberi: {romaCinema.PostiLiberi()}"); //richiamo il metodo per mostrare i posti liberi

}


