using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private string _name;
        private int _minDamage;//business rule
        private int _maxDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//End IsTwoHanded

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }//end MinDamge


        //constructors
        //Only FQCTOR
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            //The order that the parameters are placed in does not matter at all. The order
            //they are assigned in is critical if we have properties whose business rules rely
            //on the value of other properties. In that case it's best to set the dependant values first. 

            MaxDamage = maxDamage;
            Name = name;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end fqctor



        //methods
        public override string ToString()
        {
            //return base.ToString();
            //default base.ToString() for objects is namespace.ClassName. We do not want this.
            return string.Format("{0} {1} to {2} damage\nBonus Hit Chance: {3}%\t{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded ? "Two-Handed" : "One-handed");

            
        }//end ToString()
    }
}
