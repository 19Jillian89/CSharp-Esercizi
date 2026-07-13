namespace Ortaggi
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Pomodoro VarietaPomodoro= new Pomodoro("San Marzano");

            Console.WriteLine($"Stato iniziale della pianta: {VarietaPomodoro.VerificaCrescita()}\n");

            VarietaPomodoro.Irriga();
            VarietaPomodoro.Irriga();
            VarietaPomodoro.Irriga();

            Console.WriteLine($"Stato finale della pianta: {VarietaPomodoro.VerificaCrescita()}\n");
        }
    }
}
