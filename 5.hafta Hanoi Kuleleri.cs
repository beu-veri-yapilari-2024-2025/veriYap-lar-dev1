class Program
{
    static void Hanoi(int n, char kaynak, char hedef, char ara)
    {
        if (n == 1)
        {
            Console.WriteLine($"{kaynak} -> {hedef}");
            return;
        }

        Hanoi(n - 1, kaynak, ara, hedef);
        Console.WriteLine($"{kaynak} -> {hedef}");
        Hanoi(n - 1, ara, hedef, kaynak);
    }

    static void Main()
    {
        Console.Write("Disk sayısını giriniz: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("\nAdım adım hareketler:\n");
        Hanoi(n, 'A', 'C', 'B');
    }
}