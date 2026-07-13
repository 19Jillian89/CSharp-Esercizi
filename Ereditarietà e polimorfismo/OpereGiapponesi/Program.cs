namespace OpereGiapponesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OperaGiapponese> Lista = new List<OperaGiapponese>
            {
                new Manga ("Sailor Moon", "Naoko Takeuchi", 18),
                new Manga("Berserk", "Kentaro Miura", 43),
                new Anime ("Neon Genesis Evangelion", "Hideaki Anno", 26, "Gainax"),
                new Anime ("Dragon Ball Z", "Akira Toriyama", 291, "Toei Animation"),
            };

            // Il ciclo foreach invoca MostraInfo(). Grazie al polimorfismo a runtime, 
            // il computer capisce da solo se l'oggetto è un Manga o un Anime ed esegue il metodo corretto.
            foreach (OperaGiapponese opera in Lista)
            {
                opera.MostraInfo();
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
