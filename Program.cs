// this is the code where we should start

class Program
{
    public static void Main()
    {
        World game_world = new World();
        string player;
        while (true)
        {
            Console.WriteLine("please input your name");
            player = Console.ReadLine();
            if (player is not null & player.Length > 0)
            {
                break;
            }
        }
        Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location.Location_Name}");
        Console.WriteLine(game_world.current_location.Location_Description);
        while (true)
        {
            Console.WriteLine("Where do you want to go? E/N/W/S");
            string direction_input = Console.ReadLine();
            game_world.MoveLocation(direction_input);
            game_world.DrawMap();
            Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location.Location_Name}");
            Console.WriteLine(game_world.current_location.Location_Description);
            if (game_world.Locations[3].ID == game_world.current_location.ID) break;
        }
    }
}    
