using UnityEngine;

[System.Serializable]
public class Effect
{

    public enum Type
    {
        DOT,
        HOT,
        SpellPower
    }
    public Type type;
    [Space(10)]
    public Card effectCard;

    [Header("Stats")]
    public int amount;
    public int duration;

    [Header("Targets")]
    //public Character effectGiver;
    public Character effectReceiver;
}
