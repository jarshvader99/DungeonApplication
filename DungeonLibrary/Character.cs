using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //the abstract keyword indicates that the thing being modified is incomplete implementation.
    //It is never intended to be instantiated on its own. WHen appled to a class, it indicates that
    //the class is only intended to be a parent class for child classes. Abstract gives us a compiler-
    //enforced rule that prevents instantiation of the class. 
    public abstract class Character
    {
        private int _life;
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end Life

        public virtual int CalcBlock()
        {
            //we made this virtual so we can override this in child classes.
            return Block;
        }//end CalcBlock()

        //MINI LAB build calcHitChance () and make it return hit chance and make it overrideable.
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end calcHitChance()

        public virtual int CalcDamage()
        {
            return 0;
            //player and monster calculate differently so we cant have default functionality like we do for hitchance and block
            //instead we just return 0 we will override functionality in the derived classes. 
        }//end CalcDamage()

        //public abstract int CalcDamage(); this syntax forces child classes to override this functionality
        //by providing a method body. This prevents the possible mistake of returning zero which could happen with
        //the above version. 



    }//end class
}//end namespace
