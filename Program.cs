using PlayerAndTeamRequirements;
using System.Collections.Generic;
using System;

Player and Team Requirements project code
-----------------------------------------


Player.cs
----------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerAndTeamRequirements
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

ITTeam.cs
----------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerAndTeamRequirements
{
    public interface ITeam
    {
        void AddPlayer(Player player);
        void RemovePlayer(int playerId);
        Player GetPlayerById(int playerId);
        List<Player> GetPlayersByName(string playerName);
        List<Player> GetAllPlayers();
    }
}

CricketTeam.cs
-------------- -

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerAndTeamRequirements
{
    public class CricketTeam : ITeam
    {
        private List<Player> players;

        public CricketTeam()
        {
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (players.Count < 11)
            {
                players.Add(player);
                Console.WriteLine($"Player {player.Name} is added succesfully to the team.");
            }
            else
            {
                Console.WriteLine("The team cannot have more than 11 players.");
            }
        }

        public void RemovePlayer(int playerId)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine($"Player {playerToRemove.Name} is removed successfully from the team.");
            }
            else
            {
                Console.WriteLine($"Player with Id {playerId} not found in the team.");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return players.FirstOrDefault(p => p.Id == playerId);
        }

        public List<Player> GetPlayersByName(string playerName)
        {
            return players.Where(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return players.ToList();
        }
    }
}

Program.cs
----------

using PlayerAndTeamRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndTeamRequirementsP1
{
    class Program
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();
            string yon;

            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("Press 1 for  Add Player");
                Console.WriteLine("Press 2 Remove Player");
                Console.WriteLine("Press 3 Get Player by Id");
                Console.WriteLine("Press 4 Get Players by Name");
                Console.WriteLine("Press 5. Get All Players");
                Console.WriteLine("6. Exit");
                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please Enter Player Id:");
                        int playerId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please Enter Player Name:");
                        string playerName = Console.ReadLine();

                        Console.WriteLine("Please Enter Player Age:");
                        int playerAge = int.Parse(Console.ReadLine());

                        team.AddPlayer(new Player { Id = playerId, Name = playerName, Age = playerAge });
                        break;

                    case 2:
                        Console.WriteLine("Please Enter Player Id to remove:");
                        int playerIdToRemove = int.Parse(Console.ReadLine());

                        team.RemovePlayer(playerIdToRemove);
                        break;

                    case 3:
                        Console.WriteLine("Please Enter Player Id to get details:");
                        int playerIdToGet = int.Parse(Console.ReadLine());

                        Player playerById = team.GetPlayerById(playerIdToGet);
                        if (playerById != null)
                        {
                            Console.WriteLine($"Player Found: Id: {playerById.Id}, Name: {playerById.Name}, Age: {playerById.Age}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Please Enter Player Name to get details:");
                        string playerNameToGet = Console.ReadLine();

                        List<Player> playersByName = team.GetPlayersByName(playerNameToGet);
                        if (playersByName.Count > 0)
                        {
                            Console.WriteLine($"Players Found with name '{playerNameToGet}':");
                            foreach (Player player in playersByName)
                            {
                                Console.WriteLine($"Id: {player.Id}, Name: {player.Name}, Age: {player.Age}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No players found with name '{playerNameToGet}'.");
                        }
                        break;

                    case 5:
                        List<Player> allPlayers = team.GetAllPlayers();
                        Console.WriteLine("All Players:");
                        foreach (Player player in allPlayers)
                        {
                            Console.WriteLine($"Id: {player.Id}, Name: {player.Name}, Age: {player.Age}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Exiting the program.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


                Console.WriteLine();
                Console.Write("Do you want to continue( yes / no ) : ");
                yon = Console.ReadLine();


            } while (yon.Equals("yes"));

            Console.ReadLine();
        }
    }
}


