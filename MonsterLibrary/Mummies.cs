using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Mummies : Monster
    {
        public bool IsAwake { get; set; }

        public Mummies(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description, bool isAwake)
            :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsAwake = isAwake;
        }
        public override string ToString()
        {
            return base.ToString() + (IsAwake ? "You have awakened the powerful Egyptian God Set!" : "Its the web mummy tomb spider!");
        }

        public override int CalcBlock()
        {
            return IsAwake ? HitChance * 2 : HitChance;
        }
    }
}
