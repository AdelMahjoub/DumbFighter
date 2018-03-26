using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz
{
    class Battle
    {
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            
            do
            {
                Fight(warrior1, warrior2);
                Fight(warrior2, warrior1);

            } while (!warrior1.IsDead() && !warrior2.IsDead());

            FightResults(warrior1, warrior2);
        }

        private static void FightersStats(Warrior warrior1, Warrior warrior2)
        {
            Console.Clear();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("[{0} => HP: {1}/{2}; Atk: {3}; Block: {4}]", warrior1.Name, warrior1.CurrHp, warrior1.MaxHp, warrior1.MaxAtk, warrior1.MaxBlock);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("[{0} => HP: {1}/{2}; Atk: {3}; Block: {4}]", warrior2.Name, warrior2.CurrHp, warrior2.MaxHp, warrior2.MaxAtk, warrior2.MaxBlock);
            Console.WriteLine("*******************************************************");
        }

        private static void DisplayRound(Warrior attacker, Warrior defender, int baseDmg, int block, int hit)
        {
            Console.WriteLine("*******************************************************");
            AttackerDetails(attacker, baseDmg);
            DefenderDetails(defender, block);
            RoundDetails(attacker, defender, hit);
            Console.WriteLine("*******************************************************");
        }

        private static void AttackerDetails(Warrior attacker, int baseDmg)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Attacker: {0} => ", attacker.Name);

            Console.ForegroundColor = previousColor;
            Console.Write("Try to land an attack of ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} dmg\n", baseDmg);

            Console.ForegroundColor = previousColor;
        }

        private static void DefenderDetails(Warrior defender, int block)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Defender: {0} => ", defender.Name);

            Console.ForegroundColor = previousColor;
            Console.Write("Blocks ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} dmg\n", block);

            Console.ForegroundColor = previousColor;
        }

        private static void RoundDetails(Warrior attacker, Warrior defender, int hit)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("{0} ", attacker.Name);

            Console.ForegroundColor = previousColor;
            Console.Write("attacks ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", defender.Name);

            Console.ForegroundColor = previousColor;
            Console.Write("and deals ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} dmg.\n", hit);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", defender.Name);

            Console.ForegroundColor = previousColor;
            Console.Write("has ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0} ", defender.CurrHp);

            Console.ForegroundColor = previousColor;
            Console.WriteLine("Left.\n");
        }

        private static void Calculate(Warrior attacker, Warrior defender, ref int baseDmg, ref int block, ref int hit)
        {
            baseDmg = attacker.Strike();
            block = defender.Block();
            hit = Math.Max(0, baseDmg - block);
        }

        private static void Fight(Warrior attacker, Warrior defender)
        {
            int baseDmg = 0, block = 0, hit = 0;

            FightersStats(attacker, defender);

            if (!attacker.IsDead())
            {
                Calculate(attacker, defender, ref baseDmg, ref block, ref hit);
                defender.CurrHp = Math.Max(0, defender.CurrHp - hit);
                DisplayRound(attacker, defender, baseDmg, block, hit);
            }

            Console.ReadLine();
        }

        private static void FightResults(Warrior warrior1, Warrior warrior2)
        {
            string deadWarrior = warrior1.IsDead() ? warrior1.Name : warrior2.Name;
            string victoriusWarrior = warrior1.IsDead() ? warrior2.Name : warrior1.Name;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("{0} ", deadWarrior);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Has Died ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("and ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", victoriusWarrior);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Is victorious.");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
