// this is the code where we should start

class Program
{

    public static void Main()
    {
        World game_world = new World();
        string player;
        Console.Clear();
        while (true)
        {
            Console.WriteLine("please input your name");
            player = Console.ReadLine();
            if (player is not null & player.Length > 0)
            {
                break;
            }
        }
        Player current_player = new Player(player);
        game_world.DrawMap();
        Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location.Location_Name}");
        Console.WriteLine(game_world.current_location.Location_Description);
        play_game(game_world, current_player);
    }

    public static void play_game(World game_world, Player current_player)
    {
        while (true)
        {

            Console.WriteLine("Where do you want to go? E/N/W/S");
            string direction_input = Console.ReadLine();
            Console.Clear();
            Location current_location = game_world.MoveLocation(direction_input);
            game_world.DrawMap();
            Console.WriteLine($"You are currently at {game_world.current_location.Location_Name}");
            Console.WriteLine(game_world.current_location.Location_Description);
            if (game_world.Locations[8].ID == game_world.current_location.ID) break;
            if (game_world.current_location.QuestAvailableHere is not null & current_player.current_quests.Contains(game_world.current_location.QuestAvailableHere) is false & current_player.completed_quests.Contains(game_world.current_location.QuestAvailableHere) is false)
            {
                Console.WriteLine("you encountered a quest!");
                Console.WriteLine(game_world.current_location.QuestAvailableHere.Quest_Name);
                Console.WriteLine(game_world.current_location.QuestAvailableHere.Quest_Goal);
                current_player.current_quests.Add(game_world.current_location.QuestAvailableHere);
            }
            if (game_world.current_location.MonsterLivingHere is not null)
            {
                fight_monster(game_world.current_location.MonsterLivingHere, current_player);
            }            
        }
    }

    public static bool fight_monster(Monster enemy, Player player)
    {
        Console.WriteLine("you encountered a monster!");
        Console.WriteLine($"It is a {enemy.Monster_Name}");
        while (true)
        {
            Console.WriteLine("do you want to run {run/r} or do you want to stand and fight{fight/f}?");
            string current_command = Console.ReadLine().ToLower();
            if (current_command == "r" ^ current_command == "run") return false;
            else if (current_command == "f" ^ current_command == "fight") break;
            else Console.WriteLine("that is an invalid command.");
        }
        
        Battle current_battle = new Battle(enemy, player);
        while (true)
        {
            string current_result = current_battle.Turn();
            
            break;
        }

        return true;
    }
}    
