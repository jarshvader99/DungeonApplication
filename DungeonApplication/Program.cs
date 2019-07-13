using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            short killCount = 0;
            Console.Title = $"Kills: {killCount}";

            // Create a Player
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Race playerRace = Race.Humans;
            Console.WriteLine("Choose your race:\nH) Human\nP) Pygmy Faun\nE) Elated Ghoul");
            ConsoleKey raceChoice = Console.ReadKey(true).Key;

            switch (raceChoice)
            {
                case ConsoleKey.H:
                    playerRace = Race.Humans;
                    break;
                case ConsoleKey.P:
                    playerRace = Race.PygmyFaun;
                    break;
                case ConsoleKey.E:
                    playerRace = Race.ElatedGhouls;
                    break;
                default:
                    Console.WriteLine("That was not a valid choice! You will be a human!");
                    playerRace = Race.Humans;
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Welcome, {name} the {playerRace}! Your journey begins...\n");
            Weapon EveningStar = new Weapon("Eveningstar", 5, 15, 5, false);
            Player player = new Player(name, 30, 15, 50, 50, playerRace, EveningStar);
            Console.WriteLine(player);
            bool exit = false;
            do
            {
                
                // Get a room description
                Console.WriteLine(GetRoom());
                // Create a monster
                Dragon d1 = new Dragon("Young Red Dragon", 20, 20, 50, 10, 3, 8, "Puff the magic dragon!", false);
                Dragon d2 = new Dragon("Ancient Red Dragon", 40, 40, 70, 10, 2, 15, "You better hide!", true);
                Cyclops cy1 = new Cyclops("One Eyed Willy", 10, 10, 10, 10, 05, 15, "The Eye sees all!", false);
                Cyclops cy2 = new Cyclops("Blood Shot Arges", 20, 20, 10, 10, 05, 17, "The one eyed freak brings lightning!", true);
                Wendigo w1 = new Wendigo("Chained Wendigo", 30, 30, 2, 10, 10, 10, "A horrific creature formed by necessity driven hunger gone mad.", false);
                Wendigo w2 = new Wendigo("Unchained Wendigo", 30, 30, 5, 15, 10, 20, "There is a curse that dwells in these mountains… Should any resort to cannibalism in this realm, the spirit of the Wendigo shall be loosed unto them…", true);
                Mummies m1 = new Mummies("Web Mummy Tomb Spider", 10, 10, 30, 5, 5, 8, "These mummies are wrapped up tight!", false);
                Mummies m2 = new Mummies("Egyptian God Set", 25, 25, 10, 9, 10, 15, "You have awaken the powerful Egyptian God, Set!", true);
                //becuase all of our creatures will be of type monster, they can be put into a collection of Monsters.
                List<Monster> monsters = new List<Monster>() { d1, cy1, cy1, cy1, cy1, cy1, cy2, w1, w2, d2, m1, m1, m1, m1, m2 };
                Monster monster = monsters[new Random().Next(monsters.Count)];

                Console.WriteLine("In this room: " + monster.Name);
                
                bool reload = false;
                do
                {
                    Console.Title = $"Kills: {killCount}               Life: {player.Life}";
                    Console.WriteLine("\nPlease choose an action:\n" +
                       "A) ATTACK\n" +
                       "R) RUN AWAY\n" +
                        "P) Player stats\n" +
                        "M) Monster stats\n" +
                        "X) Exit");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Console.WriteLine("You attack the monster!");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                killCount++;
                                //future xp leveling logic goes here
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You killed {monster.Name}!");
                                Console.ResetColor();
                                reload = true;

                            }//end if

                            //TODO HANDLE IF PLAYER KILLS MONSTER & VICE VERSA
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You attempt to run away!");
                            Combat.DoAttack(monster, player);
                           
                            //TODO MONSTER GETS A FREE ATTACK
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine(player);
                           
                            break;
                        
                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;
                        
                        case ConsoleKey.X:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Press one of the available menu options");
                            break;
                    }//end switch
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have perished!");
                        exit = true;
                    }//end if


                } while (!exit && !reload);
            } while (!exit);
            Console.Clear();
            Console.WriteLine($"GAME OVER\nYou killed {killCount} monsters");
            //Reverse logic, while Exit == false, or while exit != true;
        }//end Main()
        private static string GetRoom()
        {//Using the Console
            string[] rooms =
            {
               //"Need a little inspiration for your players' next bout of dungeon delving? Find yourself with a dungeon map\nwith many featureless rooms? You can solve those problems by consulting the Dungeon Room Description Generator.\nThis generator contains 100 brief descriptions of dungeon rooms that you can place in your adventures as is or use as a starting point for encounters you design. Simply click on the button below to get a random room description in the form of read-aloud text for your players.",
"A crack in the ceiling above the middle of the north wall allows a trickle of water to flow down to the floor. The water\npools near the base of the wall, and a rivulet runs along the wall an out into the hall. The water smells fresh.",
"Thick cobwebs fill the corners of the room, and wisps of webbing hang from the ceiling and waver in a wind you can\nbarely feel. One corner of the ceiling has a particularly large clot of webbing within which a goblin's bones are tangled.",
"Tapestries decorate the walls of this room. Although they may once have been brilliant in hue, they now hang in graying\ntatters. Despite the damage of time and neglect, you can perceive once-grand images of wizards' towers, magical\nbeasts, and symbols of spellcasting. The tapestry that is in the best condition bulges out weirdly, as though someone stands behind it (an armless statue of a female human spellcaster).",
"Rats inside the room shriek when they hear the door open, then they run in all directions from a putrid corpse lying in\nthe center of the floor. As these creatures crowd around the edges of the room, seeking to crawl through a hole in\none corner, they fight one another. The stinking corpse in the middle of the room looks human, but the damage both time and the rats have wrought are enough to make determining its race by appearance an extremely difficult task at best.",
"Neither light nor darkvision can penetrate the gloom in this chamber. An unnatural shade fills it, and the room's\nfarthest reaches are barely visible. Near the room's center, you can just barely perceive a lump about the size of a human\nlying on the floor. (It might be a dead body, a pile of rags, or a sleeping monster that can take advantage of the room's darkness.)",
"Burning torches in iron sconces line the walls of this room, lighting it brilliantly. At the room's center lies a squat\nstone altar, its top covered in recently spilled blood. A channel in the altar funnels the blood down its side to the\nfloor where it fills grooves in the floor that trace some kind of pattern or symbol around the altar. Unfortunately, you can't tell what it is from your vantage point.",
"A liquid-filled pit extends to every wall of this chamber. The liquid lies about 10 feet below your feet and is so murky\nthat you can't see its bottom. The room smells sour. A rope bridge extends from your door to the room's other exit.",
"Fire crackles and pops in a small cooking fire set in the center of the room. The smoke from a burning rat on a spit\ncurls up through a hole in the ceiling. Around the fire lie several fur blankets and a bag. It looks like someone camped\nhere until not long ago, but then left in a hurry.",
"A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads.\nThey flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
"Rusting spikes line the walls and ceiling of this chamber. The dusty floor shows no sign that the walls move over it,\nbut you can see the skeleton of some humanoid impaled on some wall spikes nearby.",
        };
            // Random rand = new Random();
            //int indexNbr = rand.Next(rooms.Length);
            //string roomDescription = rooms[indexNbr];
            return rooms[new Random().Next(rooms.Length)];
            //return roomDescription;
            //vvvv THIS LINE OF CODE DOES THE ABOVE 4 IN ONE LINE
            //return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()
    }//end class
}//end namespace
