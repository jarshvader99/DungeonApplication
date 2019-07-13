using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //fields
        //private int _life;
        /*
         * Automatics properties were introduced with .Net 3.5. They are a shortcut
         * syntax that allows you to quickly build a property without a field.
         * Instead, the field gets built by the compiler at runtime and automatically
         * gets tied to the property. You cannot use automatic properties for any property
         * with a business rule, so we have to have a field for Life, as it is going
         * to have a rule that it cannot be more than MaxLife.
         */
        //properties
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife;
        //    }//end set
        //}//end Life
         //ctors
         //MINI-LAB! Build a fully qualified FQCTOR
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {
                case Race.SwanPeople:
                    break;
                case Race.FrogPeople:
                    break;
                case Race.TigerPeople:
                    break;
                case Race.SentientBadger:
                    break;
                case Race.HyperEvolvedPenguins:
                    break;
                case Race.Elf:
                    break;
                case Race.Dwarf:
                    break;
                case Race.HalfElf:
                    break;
                case Race.Humans:
                    MaxLife = 85;
                    Life = 80;
                    EquippedWeapon.BonusHitChance += 2;
                    break;
                case Race.WhiteWalker:
                    break;
                case Race.DragonBorn:
                    break;
                case Race.ElatedGhouls:
                    Block += 7;
                    break;
                case Race.PygmyFaun:
                    HitChance += 10;
                    
                    break;
                default:
                    break;
            }
        }//end FQCTOR
        public override string ToString()
        {
            string description = "";

            switch (CharacterRace) //Hitting enter after filling in the race was especially helpful here
            {
                
                case Race.PygmyFaun:
                    description = "They have tails. They are very wise. They have an affinity for great deserts. They lack inventiveness all\ntheir technology and knowledge is ages old. Their government is ethical in its own way. A great destiny awaits them, \nand they wait for it patiently.";
                    break;
                case Race.FrogPeople:
                    description = "They are noted for their scholars and wandering entertainers. They are in general, atheists. Their government is functional. A great doom awaits them, and they know it not.";
                    break;
                case Race.TigerPeople:
                    description = "They are silver-skinned and have three arms. The species has 'subspecies' that specialize in different tasks. Only their females are sentient. They practice ritual cannibalism of the deceased. They manage to control a plains-covered country that is actually a living being they exist in harmony with.";
                    break;
                case Race.SentientBadger:
                    description = "They are noted for their popular beers. They are very superstitious. They came from another world.";
                    break;
                case Race.HyperEvolvedPenguins:
                    description = "They have spines instead of hair. The color of their integument changes with mood. They can teleport. They are noted for their opera houses and fast-food shops. They barely control an impoverished peninsula.";
                    break;
                default:
                    description = "You're something weird.";
                    break;
            }//end switch
            return string.Format("{0}\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon: {4}\n" +
                "Block: {5}\nRace: {6}\nDescription: {7}\n",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                CharacterRace,
                description);
        }//end ToString()


        public override int CalcHitChance()
        {
            //return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
            return HitChance + EquippedWeapon.BonusHitChance;
        }// end CalcHitChance

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;

           // return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1); refactored version
        }// end CalcDamage


    }//end Player
}//end namespace
