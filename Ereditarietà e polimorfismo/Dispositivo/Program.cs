namespace Dispositivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispositivo phone = new Smartphone();   // variabile Dispositivo, oggetto reale Smartphone
            Dispositivo tv = new Televisore();   // variabile Dispositivo, oggetto reale Televisore

            Console.WriteLine("Accendiamo: Smartphone");
            phone.Accendi();

            Console.WriteLine("Accendiamo: ");
            tv.Accendi();
        }
    }
}
