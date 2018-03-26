using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior[] warriors = { new Warrior(), new Warrior() };
            GetWarriorsStats(warriors);
            Battle.StartFight(warriors[0], warriors[1]);
        }

        static void GetWarriorsStats(Warrior[] warriors)
        {
            for (int i = 0; i < warriors.Length; i++)
            {
                Console.WriteLine("=> Fill in Warrior[{0}] Name and Stats: ", i + 1);
                warriors[i].Name = GetWarriorName();
                warriors[i].MaxHp = GetWarriorMaxHp();
                warriors[i].MaxAtk = GetWarriorMaxAtk();
                warriors[i].MaxBlock = GetWarriorMaxBlock();
                warriors[i].CurrHp = warriors[i].MaxHp;
            }
        }

        static string GetWarriorName()
        {
            bool isValidInput = false;
            string name = "";
            do
            {
                Console.Write("Warrior Name:\t");
                name = Console.ReadLine();
                if(name.Length > 0)
                {
                    isValidInput = true;
                } else
                {
                    Console.WriteLine("Invalid Name.");
                }
            } while (!isValidInput);

            return name;
        }

        static int GetWarriorMaxHp()
        {
            bool isValidInput = false;
            int maxHp = 0;
            do
            {
                Console.Write("Warrior Maximum Health value:\t");
                string input = Console.ReadLine();
                if (int.TryParse(input, out maxHp))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!isValidInput);

            return maxHp;
        }

        static int GetWarriorMaxAtk()
        {
            bool isValidInput = false;
            int maxAtk = 0;
            do
            {
                Console.Write("Warrior Maximum Attack value:\t");
                string input = Console.ReadLine();
                if (int.TryParse(input, out maxAtk))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!isValidInput);

            return maxAtk;
        }

        static int GetWarriorMaxBlock()
        {
            bool isValidInput = false;
            int maxBlock = 0;
            do
            {
                Console.Write("Warrior Maximum Block value:\t");
                string input = Console.ReadLine();
                if (int.TryParse(input, out maxBlock))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!isValidInput);

            return maxBlock;
        }
    }
}
