using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
   public enum Race
    {
        /*
         * There is no direct way to create an enum through VS interface. To make one:
         * Create a class
         * Make it public
         * Change the class keyword to enum
         * The values contain no spaces and separated by commas
         */

        SwanPeople,
        FrogPeople,
        TigerPeople,
        SentientBadger,
        HyperEvolvedPenguins,
        Elf,
        Dwarf,
        HalfElf,
        Humans,
        WhiteWalker,
        DragonBorn,
        ElatedGhouls,
        PygmyFaun

    }//end enum
}//end namespace
