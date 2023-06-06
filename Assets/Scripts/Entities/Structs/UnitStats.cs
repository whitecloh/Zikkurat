using UnityEngine;

[System.Serializable]
public struct UnitStats
{
    public int MaxHealth;

    [Range(0, 1)]
    public float Accuracy;
    [Range(0, 1)]
    public float CritChance;

    [Range(0, 1)]
    public float HeavyAttackChance;
    public float AttackDistance;

    public int LightAttackDamage;
    public int HeavyAttackDamage;
}
