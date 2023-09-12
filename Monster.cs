public class Monster
{
    public int ID;
    public string Monster_Name;
    public int Monster_HP;
    public int monster_max_hp;
    public int Monster_Attack;
    public int Monster_Defense;
    public Monster(int Monster_ID, string Monster_Name, int Monster_Defense, int Monster_Attack, int Monster_HP)
    {
        this.ID = Monster_ID;
        this.Monster_Name = Monster_Name;
        this.Monster_HP = Monster_HP;
        this.monster_max_hp = Monster_HP;
        this.Monster_Attack = Monster_Attack;
        this.Monster_Defense = Monster_Defense;
    }
}