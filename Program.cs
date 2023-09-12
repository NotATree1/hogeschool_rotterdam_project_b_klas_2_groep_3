// this is the code where we should start

using System.Collections;

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
        Play_game(game_world, current_player);
        Console.WriteLine("thank you so much for playing our game!");
    }

    public static void Play_game(World game_world, Player current_player)
    {
        while (true)
        {

            Console.WriteLine("Where do you want to go? N/E/S/W/nothing");
            string direction_input = Console.ReadLine();
            Console.Clear();
            Location current_location = game_world.MoveLocation(direction_input);
            game_world.DrawMap();
            Console.WriteLine($"You are currently at {game_world.current_location.Location_Name}");
            Console.WriteLine(game_world.current_location.Location_Description);
            if (game_world.current_location.QuestAvailableHere is not null & current_player.current_quests.Contains(game_world.current_location.QuestAvailableHere) is false & current_player.completed_quests.Contains(game_world.current_location.QuestAvailableHere) is false)
            {
                Console.WriteLine("you encountered a quest!");
                Console.WriteLine(game_world.current_location.QuestAvailableHere.Quest_Name);
                Console.WriteLine(game_world.current_location.QuestAvailableHere.Quest_Goal);
                current_player.current_quests.Add(game_world.current_location.QuestAvailableHere);
            }
            if (game_world.current_location.MonsterLivingHere is not null)
            {
                bool monster_result = Fight_monster(game_world.current_location.MonsterLivingHere, current_player);
                switch(monster_result)
                {
                    case true:
                    {
                        Console.WriteLine("you have defeated the monster!");
                        foreach (Quest quest in current_player.current_quests)
                        {
                            if (quest.monster_to_kill == game_world.current_location.MonsterLivingHere)
                            {
                                quest.completion_amount += 1;
                                if (quest.completion_amount == quest.completion_requirement)
                                {
                                    Console.WriteLine("You have completed a quest!");
                                    current_player.quest_completed(quest);

                                    switch (quest.ID)
                                    {
                                        case 1:
                                        {
                                            Console.WriteLine("After defeating the rats you decide to go find the alchemist who told you to do so."); 
                                            game_world.MoveLocation("S");
                                            Console.WriteLine("He gives you leather armor to block blows from future foes. Defense + 5!");
                                            current_player.defense += 5;
                                            break;
                                        }
                                        case 2:
                                        {
                                            Console.WriteLine("After defeating the snakes you decide to go find the farmer who told you to do so."); 
                                            game_world.MoveLocation("E");
                                            Console.WriteLine("He gives you a club to deal more damage to future foes. attack + 5!");
                                            current_player.Attack += 5;
                                            break;
                                        }
                                        case 3:
                                        {
                                            Console.WriteLine("After defeating the giant spiders you have defeated the main threat around your home village.");
                                            Console.WriteLine("these were the last enemies to fight.");
                                            Console.WriteLine("you have beaten the game!");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"you have advanced on the quest {quest.Quest_Name}");
                                    Console.WriteLine($"current completion: {quest.completion_amount}/{quest.completion_requirement}");
                                }
                                break;
                            }
                        }
                        Console.WriteLine("You take a rest before continuing your journey.");
                        Console.WriteLine("You restore back to full health!");
                        break;
                    }
                    case false:
                    {
                        game_world.DrawMap();
                        Console.WriteLine("you returned to the village!");
                        game_world.current_location = game_world.LocationByID(2);
                        game_world.playerY = 3;
                        game_world.playerX = 3;
                        break;
                    }
                }
            }            
        }
    }

    public static bool Fight_monster(Monster enemy, Player player)
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
            if (current_result == "ran") return false;
            else if (current_result == "lost") return false;
            else if (current_result == "won") return true;
            else if (current_result == "continue") continue;
        }
    }
}    

