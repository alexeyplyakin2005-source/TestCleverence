namespace Server;

public class Program
{
    static void Main(string[] args)
    {
        var tasks = new Task[10];

        // читатели
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"{StaticServer.GetCount()}");
                    Thread.Sleep(50);
                }
            });
        }

        // писатели
        for (int i = 5; i < 10; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    StaticServer.AddToCount(1);
                    Console.WriteLine("Write +1");
                    Thread.Sleep(100);
                }
            });
        }

        Task.WaitAll(tasks);
        Console.WriteLine($"{StaticServer.GetCount()}");
    }
}
