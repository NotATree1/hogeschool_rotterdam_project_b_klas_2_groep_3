
class Battle
{
    public Monster Monster;
    public Player  Player;

    public Battle(Monster monster, Player player)
    {
        this.Monster = monster;
        this.Monster.Monster_HP = monster.monster_max_hp;
        this.Player = player;
    }

    public string Turn()
    {
        while (true)
        {
            Console.WriteLine(@$"your current stats:
            attack: {this.Player.Attack}
            defense: {this.Player.defense}
            HP: {this.Player.HP}/{this.Player.max_HP}
            ");
            while (true)
            {
                Console.WriteLine(@"what do you want to do?
                {attack/a}
                {use potion/p}
                {run!/r}");
                string command = Console.ReadLine().ToLower();
                Console.Clear();

                if (command == "a" ^ command == "attack")
                {
                    if (Player.Attack - Monster.Monster_Defense > 0) 
                    {
                        this.Monster.Monster_HP -= Player.Attack - Monster.Monster_Defense;
                        Console.WriteLine($"You attacked the monster! you dealt {Player.Attack - Monster.Monster_Defense} damage");
                    }
                    else Console.WriteLine($"You attacked the monster! However you dealt no damage. You should run and return when you find a better weapon.");
                    break;
                }
                else if (command == "p" ^ command == "use potion")
                {
                    Console.WriteLine("you used a potion! your health returned to MAX!");
                    this.Player.HP = this.Player.max_HP;
                    break;
                }
                else if (command == "run" ^ command == "r")
                {
                    Console.WriteLine("You ran away from the enemy!!!");
                    Console.WriteLine("You ran all the way to town square");
                    this.Player.HP = this.Player.max_HP;
                    return "ran";
                }
                else Console.WriteLine("that is an invalid command!");
            }
            if (this.Monster.Monster_HP <= 0) 
                {
                    Console.WriteLine("you have defeated the enemy!");
                    this.Player.HP = this.Player.max_HP;
                    return "won";
                }
                Console.WriteLine("The monster is attacking you!");
                if (Monster.Monster_Attack - Player.defense > 0) 
                {
                    this.Player.HP -= Monster.Monster_Attack - Player.defense;
                }
                else Console.WriteLine($"However, the monster dealt no damage.");
                Console.WriteLine($" the monster attacked back! It dealt {Monster.Monster_Attack - Player.defense} damage");

                if (this.Player.HP <= 0)
                {
                    Console.WriteLine("Your HP has hit 0!");
                    Console.WriteLine("You fainted");
                    Console.WriteLine("You respawned in town square");
                    this.Player.HP = this.Player.max_HP;
                    return "lost";
                }
        }
    }
}