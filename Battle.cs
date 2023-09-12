
class Battle
{
    public Monster Monster;
    public Player  Player;

    public Battle(Monster monster, Player player)
    {
        this.Monster = monster;
        this.Player = player;
    }

    public string Turn()
    {
        while (true)
        {
            Console.WriteLine(@"what do you want to do?
            {attack/a}
            {use potion/p}
            {run!}");
            string command = Console.ReadLine().ToLower();
            if (command == "a" ^ command == "attack")
            {
                this.Monster.Monster_HP -= Player.Attack - Monster.Monster_Defense;
                break;
            }
            else if (command == "p" ^ command == "use potion")
            {
                this.Player.HP = this.Player.max_HP;
                break;
            }
            else if (command == "run" ^ command == "r")
            {
                Console.WriteLine("You ran away from the enemy!!!");
                Console.WriteLine("You ran all the way to town square");
                return "ran";
            }
            else Console.WriteLine("that is an invalid command!");
        }
        if (this.Monster.Monster_HP <= 0) 
            {
                Console.WriteLine("you have defeated the enemy!");
                return "won";
            }
            Console.WriteLine("The monster is attacking you!");
            this.Player.HP -= Monster.Monster_Attack - Player.defense;
            if (this.Player.HP <= 0)
            {
                Console.WriteLine("Your HP has hit 0!");
                Console.WriteLine("You fainted");
                Console.WriteLine("You respawned in town square");
                return "lost";
            }
            return "continue";

    }
}