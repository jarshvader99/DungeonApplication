using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Cyclops : Monster
    {

        public bool IsBloodShot { get; set; }

        public Cyclops(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description, bool isBloodShot)
            :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsBloodShot = isBloodShot;
        }
        public override string ToString()
        {
            return base.ToString() + (IsBloodShot ? "It is blood shot and rabid!" : "It's only an eye sore.");
        }

        public override int CalcBlock()
        {
            return IsBloodShot ? Block * 2 : Block;
        }
    }
}
