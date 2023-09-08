// this is the code where we should start

class Program
{
    public static void Main()
    {
        World game_world = new World();
        
        Console.WriteLine("please input your name");
        string player = Console.ReadLine();
        
        Console.WriteLine($"you are {player}. \nYou are currently at {game_world.current_location}");
    }
}