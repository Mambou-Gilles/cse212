using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        Console.Write("What is your age? ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}, {1}", name, age);
    }
}