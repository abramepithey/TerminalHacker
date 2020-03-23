using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalHacker
{
    class Game
    {
        private readonly List<string> TestList = new List<string>();

        public void RunProgram()
        {
            TestList.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            bool keepRunning = true;
            while (keepRunning)
            {
                TestList.Clear();
                Console.WriteLine("Choose a difficulty level: \n" +
                    "1. Easy\n" +
                    "2. Medium\n" +
                    "3. Hard\n" +
                    "4. Exit Program");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "easy":
                        // load easy list
                        SeedWords(1);
                        CallSmallListAndKey();
                        break;
                    case "2":
                    case "medium":
                        // load medium list
                        SeedWords(2);
                        CallSmallListAndKey();
                        break;
                    case "3":
                    case "hard":
                        // load hard list
                        SeedWords(3);
                        CallSmallListAndKey();
                        break;
                    case "4":
                    case "exit":
                    case "exit program":
                        keepRunning = false;
                        Console.WriteLine("Exiting Program...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine($"{"|",-10}{"Please select a valid option.",-30}{"1",-15}|");
                        Console.WriteLine($"{"|",-10}{"Please.",-30}{"1",-15}|");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void ReturnFromList(List<int> index)
        {
            foreach (int entry in index)
            {
                Console.WriteLine(TestList[entry - 1]);
            }
        }

        public void CallSmallListAndKey()
        {
            // Creating list of 20 random numbers, 1-100
            Console.Clear();
            Random rand = new Random();
            List<int> smallRands = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                smallRands.Add(rand.Next(100));
            }
            foreach (int num in smallRands)
            {
                Console.WriteLine(TestList[num]);
            }
            Console.WriteLine(new string('-', 75));
            // Selecting one of those numbers to be the key
            int keyNum = rand.Next(20);
            int key = smallRands[keyNum];
            Console.WriteLine(TestList[key]);
            Console.ReadLine();
            Console.Clear();
        }

        public void SeedWords(int difficulty)
        {
            List<string> words;
            if (difficulty == 1)
            {
                words = System.IO.File.ReadLines(@"C:\Users\abram\source\repos\TerminalHacker\TerminalHacker\EasyWords.txt").ToList();
            }
            else if (difficulty == 2)
            {
                words = System.IO.File.ReadLines(@"C:\Users\abram\source\repos\TerminalHacker\TerminalHacker\MediumWords.txt").ToList();
            }
            else
            {
                words = System.IO.File.ReadLines(@"C:\Users\abram\source\repos\TerminalHacker\TerminalHacker\HardWords.txt").ToList();
            }

            foreach (string word in words)
            {
                TestList.Add(word);
            }
        }

        public void StylizeUI()
        {
            /* Lower Priority */
            // Take organization from drofsnar as a starting point and make a way of putting good stylization around the app
        }

        public void CompareWords()
        {
            // Make two static words and compare them.

            // Hamming method?


        }
    }
}
