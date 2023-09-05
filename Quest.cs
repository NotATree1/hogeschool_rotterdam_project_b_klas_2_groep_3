public class Quest
{
    public int Quest_ID;
    public string Quest_Name;
    public string Quest_Goal;
    public Quest(int Quest_ID, string Quest_Name, string Quest_Goal)
    {
        this.Quest_ID = Quest_ID;
        this.Quest_Name = Quest_Name;
        this.Quest_Goal = Quest_Goal;
    }
}