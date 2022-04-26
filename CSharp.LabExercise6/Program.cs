using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    class Scrabble
    {
        private string word;
        private int point;
        static Dictionary<char, int> letterPoints = new Dictionary<char, int>
        {
            { 'a', 1 }, { 'e', 1 }, { 'i', 1 }, { 'o', 1 }, { 'u', 1 }, { 'l', 1 }, { 'n', 1 }, { 'r', 1 }, { 's', 1 }, { 't', 1 },
            { 'd', 2 }, { 'g', 2 },
            { 'b', 3 }, { 'c', 3 }, { 'm', 3 }, { 'p', 3 },
            { 'f', 4 }, { 'h', 4 }, { 'v', 4 }, { 'w', 4 }, { 'y', 4 },
            { 'k', 5 },
            { 'j', 8 }, { 'x', 8 },
            { 'q', 10 }, { 'z', 10 }
        };
        public Scrabble(string word)
        {
            this.word = word;
        }
        public int CalculateScore(string word)
        {
            int totalScore = 0;
            foreach (char letter in word)
            {
                letterPoints.TryGetValue(letter, out point);
                totalScore += point;
            }
            return totalScore;
        }
        public int GetScore()
        {
            return CalculateScore(this.word);
        }
    }
    class InputValidator 
    {
        public string ValidCharacter { get => "abcdefghijklmnopqrstuvwxyz"; }

        public bool ValidateInputs(string word)
        {
            if (word.Equals(""))
            {
                Console.WriteLine("\nPlease Input a Valid Word");
                Console.WriteLine("Input should not be empty\n");
                return false;
            }
            else
            {
                foreach (char letter in word)
                {
                    if (!(ValidCharacter.Contains(letter)))
                    {
                        Console.WriteLine("\nPlease Input a Valid Word");
                        Console.WriteLine("Input should not contain spaces, numbers or any special characters.\n");
                        return false;
                    }
                }
            }
            return true;
        }
    }
    class Program
    {
        static void Main()
        {
            string choice = "y";
            var inputValidator = new InputValidator();

            while (choice.Trim().ToLower().Equals("y"))
            {
                Console.WriteLine("===== SCRABBLE GAME =====");
                Console.Write("Enter a word: ");
                string word = Console.ReadLine().ToLower();

                if (inputValidator.ValidateInputs(word))
                {
                    var scrabble = new Scrabble(word);
                    Console.WriteLine($"Word Score: {scrabble.GetScore()}\n");
                }

                Console.Write("Do you want to continue(y to continue/any key to exit)? ");
                choice = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Thank you!");
        }
    }
}