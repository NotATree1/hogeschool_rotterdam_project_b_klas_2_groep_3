
class Battle
{
    public Monster Monster;
    public Player  Player;

    public Battle(Monster monster, Player player)
    {
        this.Monster = monster;
        this.Player = player;
    }

    public bool turn(string move)
    {
        Console.WriteLine(@"what do you want to do?
        {attack/a}
        {use potion/p}
        {run!}");
        string command = Console.ReadLine().ToLower();
        if (command == "a" ^ command == "attack")
        {
            this.Monster.Monster_HP -= Player.Attack - Monster.Monster_Defense;
        }
        if (command == "p" ^ command == "use potion")
        {
            this.Player.HP = this.Player.max_HP;
        }
        if (command == "run" ^ command == "r")
        {
            Console.WriteLine("You ran away from the enemy!!!");
            return true;
        }
        return true;
    }
}