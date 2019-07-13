using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;

            }//end set
        }//end MinDamage
        public Monster(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description)
        {
            MaxDamage = maxDamage;
            MaxLife = maxLife;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }//end Monster()

        public override string ToString()
        {
            return string.Format($"\n*******MONSTER STATS*******\n{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaxDamage}\n",
                $"Block: {Block}\nDescription:\n{Description}");
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(MinDamage, MaxDamage + 1);
            return damage;
        }//end CalcDamage()
    }//end class
}//end namespace
