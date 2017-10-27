using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqExample
{

    public class player
    {
        Guid _id;
        string _name;
        int _xp;

       

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return _id.ToString()+" " + _name +" " +_xp.ToString();
        }
    }

    
    class Program
    {
        static List<player> players = new List<player>()
            {
                new player {Id = Guid.NewGuid(), Name="Joe Bloggs", Xp = 10 },
                 new player {Id = Guid.NewGuid(), Name="Pete Townsend", Xp = 150 },
                  new player {Id = Guid.NewGuid(), Name="Mary Shelly", Xp = 500 },
                   new player {Id = Guid.NewGuid(), Name="Pete Volga", Xp = 100 }
            };

        static void Main(string[] args)
        {
            // returns first occurrence of a match or null
            player found = players.FirstOrDefault(p => p.Name == "Mary Shelly");
            if (found != null)
               Console.WriteLine("{0}", found.ToString()); 
            else Console.WriteLine("Not Found");

            player found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));
            if (found1 != null)
                Console.WriteLine("{0}", found1.ToString());
            else Console.WriteLine("Not Found");

            //return all with xp over 100

            List<player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}\n", item.ToString());
                }
            }
            else Console.WriteLine("No Match Found");

            // create and print scoreboard order by highest Xp

            var scoreBoard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });
            foreach (var item in scoreBoard)
            {
                Console.WriteLine("{0} {1}", item.Name,item.Xp);
            }

            Console.ReadKey();
        }
    }
}
