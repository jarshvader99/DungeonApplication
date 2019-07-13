using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Wendigo : Monster
    {
        public bool IsHungry { get; set; }

        public Wendigo(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description, bool isHungry)
            :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsHungry = isHungry;
        }
        public override string ToString()
        {
            return base.ToString() + (IsHungry ? "Unchained and ready to feast!" : "Chained and ready to feast!");
        }

        public override int CalcBlock()
        {
            return IsHungry ? HitChance * 2 : HitChance;
        }



    }//end class
}//end namespace
