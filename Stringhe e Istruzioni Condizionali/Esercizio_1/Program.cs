namespace Studente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] voti = { 9, 6, 9, 6, 5 };
            Studente studente = new Studente("Ilaria Nassi", voti);
            Console.WriteLine(studente.strOutput());
            Console.WriteLine("Giudizio finale: " + studente.determinareGiudizio());
        }
    }
}
