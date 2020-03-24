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
                        LoadLevel(1);
                        break;
                    case "2":
                    case "medium":
                        // load medium list
                        LoadLevel(2);
                        break;
                    case "3":
                    case "hard":
                        // load hard list
                        LoadLevel(3);
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
            CompareWords(TestList[key]);
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

        public void CompareWords(string key)
        {
            // Make two static words and compare them.
            string keyword = key.ToUpper();
            Console.WriteLine("Guess the Keyword.");
            int tries = 6;
            while (tries > 0)
            {
                string response = Console.ReadLine().ToUpper();
                if (response == keyword)
                {
                    Console.WriteLine("Correct!");
                    break;
                }
                else
                {
                    --tries;
                    if (tries == 0)
                    {
                        Console.WriteLine("Too bad!");
                    }
                    else
                    {
                        int differences = WordDifference(keyword, response);
                        if (differences == 100)
                        {
                            Console.WriteLine($"Enter a word with {keyword.Count()} characters.");
                        } else
                        {
                            Console.WriteLine($"{differences} correct.");
                        }
                    }
                }
            }
            Console.ReadLine();
        }

        public void LoadLevel(int difficulty)
        {
            SeedWords(difficulty);
            CallSmallListAndKey();
        }

        public int WordDifference(string key, string response)
        {
            string stringKey = key.ToUpper();
            string stringResponse = response.ToUpper();
            char[] arrayKey = stringKey.ToCharArray();
            char[] arrayResponse = stringResponse.ToCharArray();

            int correctChars = 0;

            if (arrayKey.Length != arrayResponse.Length)
            {
                correctChars = 100;
            }
            else
            {
                for (int i = 0; i < arrayResponse.Length; i++)
                {
                    if (arrayKey[i] == arrayResponse[i])
                    {
                        correctChars++;
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
            }
            Console.WriteLine();
            return correctChars;
        }
    }
}
