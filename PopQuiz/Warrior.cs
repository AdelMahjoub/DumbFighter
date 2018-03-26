using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopQuiz
{
    class Warrior
    {
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int MaxAtk { get; set; }
        public int MaxBlock { get; set; }
        public int CurrHp { get; set; }

        private Random rnd = new Random();

        public Warrior(string name = "", int hp = 0, int atk = 0, int block = 0)
        {
            Name = name;
            MaxHp = hp;
            MaxAtk = atk;
            MaxBlock = block;
        }

        public int Strike()
        {
            return rnd.Next(0, MaxAtk);
        }

        public int Block()
        {
            return rnd.Next(0, MaxBlock);
        }

        public bool IsDead()
        {
            return CurrHp <= 0;
        }
    }
}
