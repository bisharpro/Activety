using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project21
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your ID: ");
            string id = Console.ReadLine();

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

            Random rand = new Random();
            int correct = 0;
            int wrong = 0;
            string operationName = "";

            switch (chosenOperation)
            {
                case 1:
                    operationName = "Addition";
                    break;
                case 2:
                    operationName = "Multiplication";
                    break;
                case 3:
                    operationName = "Subtraction";
                    break;
                case 4:
                    operationName = "Division";
                    break;
            }

            for (int i = 1; i <= 10; i++)
            {
                int a = rand.Next(1, 21);
                int b = rand.Next(1, 21);
                int answer = 0;
                string question = "";

                // Create question based on chosen operation
                switch (chosenOperation)
                {
                    case 1: // Addition
                        answer = a + b;
                        question = $"{a} + {b}";
                        break;
                    case 2: // Multiplication
                        answer = a * b;
                        question = $"{a} * {b}";
                        break;
                    case 3: // Subtraction
                        if (a < b) (a, b) = (b, a);
                        answer = a - b;
                        question = $"{a} - {b}";
                        break;
                    case 4: // Division
                        while (a % b != 0)
                        {
                            a = rand.Next(1, 21);
                            b = rand.Next(1, 20) + 1;
                        }
                        answer = a / b;
                        question = $"{a} / {b}";
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
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Correct Answers: {correct}");
            Console.WriteLine($"Incorrect Answers: {wrong}");
            Console.WriteLine($"Score Percentage: {percentage}%");
            Console.WriteLine("===================================");


        }
    }
}