public  class World
{

    public  readonly List<Weapon> Weapons = new List<Weapon>();
    public  readonly List<Monster> Monsters = new List<Monster>();
    public  readonly List<Quest> Quests = new List<Quest>();
    public  readonly List<Location> Locations = new List<Location>();
    public  readonly Random RandomGenerator = new Random();

    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;

    public const int MONSTER_ID_RAT = 1;
    public const int MONSTER_ID_SNAKE = 2;
    public const int MONSTER_ID_GIANT_SPIDER = 3;

    public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
    public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
    public const int QUEST_ID_COLLECT_SPIDER_SILK = 3;

    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_SQUARE = 2;
    public const int LOCATION_ID_GUARD_POST = 3;
    public const int LOCATION_ID_ALCHEMIST_HUT = 4;
    public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
    public const int LOCATION_ID_FARMHOUSE = 6;
    public const int LOCATION_ID_FARM_FIELD = 7;
    public const int LOCATION_ID_BRIDGE = 8;
    public const int LOCATION_ID_SPIDER_FIELD = 9;

    public char[,] map = {
        {' ', ' ', ' ', '#', ' ', ' ', ' ',' '},
        {' ', ' ', '#', 'p', '#', ' ', ' ',' '},
        {' ', '#', '#', 'a', '#', '#', '#',' '},
        {'#', 'v', 'f', 't', 'g', 'b', 's','#'},
        {' ', '#', '#', 'h', '#', '#', '#',' '},
        {' ', ' ', ' ', '#', ' ', ' ', ' ',' '},
    };

    public int playerX = 3; // breedte
    public int playerY = 4; // lengte
    public  Location current_location;

    public World()
    {
        PopulateWeapons();
        PopulateMonsters();
        PopulateQuests();
        PopulateLocations();

        current_location = Locations[0];
    }


    public void PopulateWeapons()
    {
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 5));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Club", 10));
    }

    public void PopulateMonsters()
    {
        Monster rat = new Monster(MONSTER_ID_RAT, "rat", 1, 3, 3);


        Monster snake = new Monster(MONSTER_ID_SNAKE, "snake", 3, 7, 7);


        Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "giant spider", 5, 10, 10);


        Monsters.Add(rat);
        Monsters.Add(snake);
        Monsters.Add(giantSpider);
    }

    public  void PopulateQuests()
    {
        Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden",
                MonsterByID(MONSTER_ID_RAT));



        Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's field",
                "Kill snakes in the farmer's field",
                MonsterByID(MONSTER_ID_SNAKE));


        Quest clearSpidersForest =
            new Quest(
                QUEST_ID_COLLECT_SPIDER_SILK,
                "Collect spider silk",
                "Kill spiders in the spider forest",
                MonsterByID(MONSTER_ID_GIANT_SPIDER));


        Quests.Add(clearAlchemistGarden);
        Quests.Add(clearFarmersField);
        Quests.Add(clearSpidersForest);
    }

    public  void PopulateLocations()
    {
        // Create each location
        Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.", null, null);

        Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.", null, null);

        Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.", null, null);
        alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

        Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.", null, null);
        alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

        Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.", null, null);
        farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

        Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.", null, null);
        farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

        Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", null, null);

        Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.", null, null);
        bridge.QuestAvailableHere = QuestByID(QUEST_ID_COLLECT_SPIDER_SILK);

        Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.", null, null);
        spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

        // Link the locations together
        home.LocationToNorth = townSquare;

        townSquare.LocationToNorth = alchemistHut;
        townSquare.LocationToSouth = home;
        townSquare.LocationToEast = guardPost;
        townSquare.LocationToWest = farmhouse;

        farmhouse.LocationToEast = townSquare;
        farmhouse.LocationToWest = farmersField;

        farmersField.LocationToEast = farmhouse;

        alchemistHut.LocationToSouth = townSquare;
        alchemistHut.LocationToNorth = alchemistsGarden;

        alchemistsGarden.LocationToSouth = alchemistHut;

        guardPost.LocationToEast = bridge;
        guardPost.LocationToWest = townSquare;

        bridge.LocationToWest = guardPost;
        bridge.LocationToEast = spiderField;

        spiderField.LocationToWest = bridge;

        // Add the locations to the  list
        Locations.Add(home);
        Locations.Add(townSquare);
        Locations.Add(guardPost);
        Locations.Add(alchemistHut);
        Locations.Add(alchemistsGarden);
        Locations.Add(farmhouse);
        Locations.Add(farmersField);
        Locations.Add(bridge);
        Locations.Add(spiderField);
    }

    public  Location LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public  Weapon WeaponByID(int id)
    {
        foreach (Weapon item in Weapons)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }



    public  Monster MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    public  Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }

    public  Location MoveLocation(string direction)
    {

        string current_direction = direction.ToUpper();
        if (current_direction == "N")
        {
            if (current_location.LocationToNorth is not null)
            {
                playerY -= 1;
                current_location = current_location.LocationToNorth;
            }
            else Console.WriteLine("This is an invalid direction.");
        }
        else if (current_direction == "E")
        {
            if (current_location.LocationToEast is not null)
            {
                playerX += 1;
                current_location = current_location.LocationToEast;
            }
            else Console.WriteLine("This is an invalid direction.");
        }
        else if (current_direction == "S")
        {
            if (current_location.LocationToSouth is not null)
            {
                playerY += 1;
                current_location = current_location.LocationToSouth;
            }
            else Console.WriteLine("This is an invalid direction.");
        }
        else if (current_direction == "W")
        {
            if (current_location.LocationToWest is not null)
            {
                playerX -= 1;
                current_location = current_location.LocationToWest;
            }
            else Console.WriteLine("This is an invalid direction.");
        }
        return current_location;
    }

    public Location FindLocationByID(int ID)
    {
        foreach (Location place in Locations)
        {
            if (place.ID == ID) return place;
        }
        return null;
    }

    public void DrawMap()
    {
        // wist de terminal (refresht de terminal)
        // de .GetLength(0)  
        // word gebruikt om de totale number van elementen te vinden in de specifieke dimensie van de array
        for (int y = 0; y < map.GetLength(0); y++)
        {
            // hiet word het zelfde gedaan
            for (int x = 0; x < map.GetLength(1); x++)
            {
                // als x en player x en ook bij y en playery gelijk zijn word er een 1 op de map geplaatst
                if (x == playerX && y == playerY)
                    Console.Write(Convert.ToString(map[y, x]).ToUpper());
                // map word gevuld met de array
                else
                    Console.Write(map[y, x]);
            }
            Console.WriteLine();
        }
    }
}
