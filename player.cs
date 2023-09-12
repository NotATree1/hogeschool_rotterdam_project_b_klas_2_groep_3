class Player
{
    
    public string player_name;
    public int Attack = 5;
    public int defense = 2;
    public int HP = 10;
    public int max_HP = 10;
    public List<Quest> current_quests = new List<Quest>();
    public List<Quest> completed_quests = new List<Quest>();

    public Player(string player_name)
    {
        this.player_name = player_name;
    }

    public bool quest_completed(Quest completed)
    {
        int current_space = 0;
        foreach (Quest quest in current_quests)
        {
            if (quest.ID == completed.ID)
            {
                this.completed_quests.Add(quest);
                current_quests.RemoveAt(current_space);
                return true;
            }
            current_space += 1;
        }
        return false;
    }
}