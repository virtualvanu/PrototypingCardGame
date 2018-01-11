using UnityEngine;

[System.Serializable]
public class Effect
{

    public Card effectGiver;
    [Space(10)]
    public int amount;
    public int duration;
    [Space(10)]
    public Character damageTarget;
    public Transform damageTextTarget;
}
