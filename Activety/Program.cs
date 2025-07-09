using System;
using System.Text.RegularExpressions;

namespace project21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Regex namePattern = new Regex("^[a-zA-Z\\s]+$");

            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("❌ Name cannot be empty. Please try again.");
                }
                else if (!namePattern.IsMatch(name))
                {
                    Console.WriteLine("❌ Please enter your name using letters only (A–Z).");
                    name = null;
                }

            } while (string.IsNullOrWhiteSpace(name));

            Console.WriteLine("\nChoose the operation for all 10 questions:");
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Multiplication");
            Console.WriteLine("3: Subtraction");
            Console.WriteLine("4: Division");
            Console.Write("Enter choice (1-4): ");

            string choiceInput = Console.ReadLine();
            bool validChoice = int.TryParse(choiceInput, out int chosenOperation);

            if (!validChoice || chosenOperation < 1 || chosenOperation > 4)
            {
                Console.WriteLine("❌ Invalid operation choice.");
                return;
            }

            string operationName = chosenOperation switch
            {
                1 => "Addition",
                2 => "Multiplication",
                3 => "Subtraction",
                4 => "Division",
                _ => ""
            };

            int correct = 0, wrong = 0;

            for (int i = 1; i <= 10; i++)
            {
                int a = 0, b = 0, answer = 0;
                string question = "";

                switch (chosenOperation)
                {
                    case 1:
                        (a, b, answer, question) = GenerateAddition();
                        break;
                    case 2:
                        (a, b, answer, question) = GenerateMultiplication();
                        break;
                    case 3:
                        (a, b, answer, question) = GenerateSubtraction();
                        break;
                    case 4:
                        (a, b, answer, question) = GenerateDivision();
                        break;
                }

                Console.Write($"\nQ{i} ({operationName}): {question} = ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int userAnswer);

                if (isNumber && userAnswer == answer)
                {
                    Console.WriteLine("✔ Correct!");
                    correct++;
                }
                else
                {
                    Console.WriteLine($"✘ Incorrect! Correct answer: {answer}");
                    wrong++;
                }
            }

            double percentage = (correct / 10.0) * 100;
            Console.WriteLine("\n========== FINAL RESULT ==========");
            Console.WriteLine($"Name: {name}\tCorrect Answers: {correct}\tIncorrect Answers: {wrong}\tScore Percentage: {percentage}%");
        }

        // 🧮 Method for Addition
        static (int, int, int, string) GenerateAddition()
        {
            Random rand = new Random();
            int a = rand.Next(5, 12);
            int b = rand.Next(6, 21);
            int answer = a + b;
            string question = $"{a} + {b}";
            return (a, b, answer, question);
        }

        // 🧮 Method for Multiplication
        static (int, int, int, string) GenerateMultiplication()
        {
            Random rand = new Random();
            int a = rand.Next(5, 12);
            int b = rand.Next(6, 21);
            int answer = a * b;
            string question = $"{a} * {b}";
            return (a, b, answer, question);
        }

        // 🧮 Method for Subtraction
        static (int, int, int, string) GenerateSubtraction()
        {
            Random rand = new Random();
            int a = rand.Next(5, 12);
            int b = rand.Next(6, 21);
            if (a < b) (a, b) = (b, a);
            int answer = a - b;
            string question = $"{a} - {b}";
            return (a, b, answer, question);
        }

        // 🧮 Method for Division
        static (int, int, int, string) GenerateDivision()
        {
            Random rand = new Random();
            int a, b;
            do
            {
                a = rand.Next(4, 28);
                b = rand.Next(1, 20) + 1;
            } while (a % b != 0);

            int answer = a / b;
            string question = $"{a} / {b}";
            return (a, b, answer, question);
        }
    }
}
