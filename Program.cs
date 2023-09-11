// this is the code where we should start

class Program
{
    public void Main()
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
        game_world.DrawMap();
        Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location.Location_Name}");
        Console.WriteLine(game_world.current_location.Location_Description);
        while (true)
        {

            Console.WriteLine("Where do you want to go? E/N/W/S");
            string direction_input = Console.ReadLine();
            Console.Clear();
            Location current_location = game_world.MoveLocation(direction_input);
            game_world.DrawMap();
            Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location.Location_Name}");
            Console.WriteLine(game_world.current_location.Location_Description);
            if (game_world.Locations[4].ID == game_world.current_location.ID) break;
        }
    }
}    
