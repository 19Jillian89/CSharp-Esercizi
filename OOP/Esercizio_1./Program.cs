namespace Autofficina
{
    class Program
    {
        static void Main(string[] args)
        {
            // creo due clienti con ore di manodopera diverse
            Cliente kratos = new Cliente("Kratos", "GO000DW", 5);
            Cliente pacman = new Cliente("Pacman", "PC81MAN", 3);

            // stampo il conto totale di ciascuno (proprietà in sola lettura, ricalcolata ogni volta)
            Console.WriteLine($"Conto totale Kratos: {kratos.ContoTotale}€");
            Console.WriteLine($"Conto totale Pacman: {pacman.ContoTotale}€");

            // stampo quanto deve dare ciascun cliente comprensivo di IVA
            Console.WriteLine($"Kratos deve pagare (con IVA): {kratos.CalcoloIva()}€");
            Console.WriteLine($"Pacman deve pagare (con IVA): {pacman.CalcoloIva()}€");

            // verifico il totale ore lavorate dal meccanico su TUTTE le auto
            // (campo statico, condiviso da tutte le istanze di Cliente)
            Console.WriteLine($"\nOre manodopera totali officina: {Cliente.OreManodoperaTotali}");

            // aggiungo un terzo cliente e verifico che il totale statico si aggiorni
            Cliente ezio = new Cliente("Ezio Auditore", "EZ110OA", 2);
            Console.WriteLine($"Ore manodopera totali dopo il terzo cliente: {Cliente.OreManodoperaTotali}");
        }
    }
}