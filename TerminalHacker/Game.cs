﻿using System;
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
            GameTitle();

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
                        GameTitle();
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

        public void CallSmallListAndKey(int numberOfPotentialWords, int numberOfGuesses)
        {
            // Creating list of 20 random numbers, from 1 - the amount of words in our text file (100)
            Console.Clear();
            GameTitle();
            Random rand = new Random();
            List<int> smallRands = new List<int>();
            //int listLength = smallRands.Count;
            while (smallRands.Count < numberOfPotentialWords)
            {
                int nextRand = rand.Next(TestList.Count);
                if (!smallRands.Contains(nextRand))
                {
                    smallRands.Add(nextRand);
                }
            }
            foreach (int num in smallRands)
            {
                Console.WriteLine(TestList[num].ToUpper());
            }
            Console.WriteLine(new string('=', 62));
            // Selecting one of those numbers to be the key
            int keyNum = rand.Next(numberOfPotentialWords);
            int key = smallRands[keyNum];
            //Console.WriteLine(TestList[key]);
            CompareWords(TestList[key], numberOfGuesses);
            Console.Clear();
            GameTitle();

            //for (int i = 0; i < smallRands.Count; i++)

        }

        public void SeedWords(int difficulty)
        {
            List<string> words;
            if (difficulty == 1)
            {
                words = System.IO.File.ReadLines(@"C:\ElevenFiftyProjects\Assignments\TerminalHacker\TerminalHacker\EasyWords.txt").ToList();
            }
            else if (difficulty == 2)
            {
                words = System.IO.File.ReadLines(@"C:\ElevenFiftyProjects\Assignments\TerminalHacker\TerminalHacker\MediumWords.txt").ToList();
            }
            else
            {
                words = System.IO.File.ReadLines(@"C:\ElevenFiftyProjects\Assignments\TerminalHacker\TerminalHacker\HardWords.txt").ToList();
            }

            foreach (string word in words)
            {
                TestList.Add(word);
            }
        }

        public void CompareWords(string key, int numberOfTries)
        {
            // Make two static words and compare them.
            string keyword = key.ToUpper();
            Console.WriteLine("Guess the Keyword.");
            int tries = numberOfTries;
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
                        Console.WriteLine($"The keyword is {keyword}. You should really try harder next time.");
                    }
                    else
                    {
                        int differences = WordDifference(keyword, response);
                        if (differences == 100)
                        {
                            Console.Write($"Enter a word with {keyword.Count()} characters. ");
                        }
                        else
                        {
                            Console.Write($"{differences} correct letter(s). ");
                        }
                        Console.WriteLine($"You have {tries} {(tries > 1 ? "tries" : "try")} remaining.");
                    }
                }
            }
            Console.ReadLine();
        }

        public void LoadLevel(int difficulty)
        {
            SeedWords(difficulty);
            CallSmallListAndKey(14, 5);
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
                    }
                }
            }
            return correctChars;
        }

        public void GameTitle()
        {
            Console.WriteLine
               (" _____               _         _    _____         _           \n" +
                "|_   _|___ ___ _____|_|___ ___| |  |  |  |___ ___| |_ ___ ___ \n" +
                "  | | | -_|  _|     | |   | .'| |  |     | .'|  _| '_| -_|  _|\n" +
                "  |_| |___|_| |_|_|_|_|_|_|__,|_|  |__|__|__,|___|_,_|___|_|  \n");

            Console.WriteLine(new string('=', 62));
        }
    }
}
