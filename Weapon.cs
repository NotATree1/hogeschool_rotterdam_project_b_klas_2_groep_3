public class Weapon
{
    public int ID;
    public string Weapon_Name;
    public int Weapon_Power;
    public Weapon(int weapon_id, string weapon_name, int weapon_power)
    {
        this.ID = weapon_id;
        this.Weapon_Name = weapon_name;
        this.Weapon_Power = weapon_power;
    }
}
