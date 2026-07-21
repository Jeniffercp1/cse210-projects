using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: I added a small list of scriptures and the
        // program chooses one at random. Each time the user presses Enter, the
        // program chooses from the words that are still visible.
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths"),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God")
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];
        string userInput = "";

        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine() ?? "quit";

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
