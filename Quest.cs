public class Quest
{
    public int ID;
    public string Quest_Name;
    public string Quest_Goal;
    public int completion_amount = 0;
    public int completion_requirement = 3;
    public Monster monster_to_kill;

    public Quest(int Quest_ID, string Quest_Name, string Quest_Goal, Monster enemy_monster)
    {
        this.ID = Quest_ID;
        this.Quest_Name = Quest_Name;
        this.Quest_Goal = Quest_Goal;
        this.monster_to_kill = enemy_monster;
    }
}