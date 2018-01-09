
public class Effect
{

    public enum Type
    {
        Damage,
        Heal
    }
    public Type effectType;

    public int amount;
    public int duration;

    public Card effectGiver;
}
