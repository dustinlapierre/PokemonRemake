using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType type;
    [SerializeField] MoveCategory category;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] bool alwaysHits;
    [SerializeField] int pp;
    [SerializeField] MoveEffects effects;
    [SerializeField] List<SecondaryEffects> secondaries;
    [SerializeField] MoveTarget target;

    //props
    public string Description { get => description; }
    public string Name { get => name; }
    public PokemonType Type { get => type; }
    public MoveCategory Category { get => category; }
    public int Power { get => power; }
    public int Accuracy { get => accuracy; }
    public bool AlwaysHits { get => alwaysHits; }
    public int PP { get => pp; }
    public MoveEffects Effects { get => effects; }
    public List<SecondaryEffects> Secondaries { get => secondaries; }
    public MoveTarget Target { get => target; }
}
[System.Serializable]
public class MoveEffects
{
    [SerializeField] List<StatBoost> boosts;
    [SerializeField] ConditionID status;
    [SerializeField] ConditionID volatileStatus;

    public List<StatBoost> Boosts { get { return boosts; } }
    public ConditionID Status { get { return status; } }
    public ConditionID VolatileStatus { get { return volatileStatus; } }
}
[System.Serializable]
public class SecondaryEffects : MoveEffects
{
    [SerializeField] int chance;
    [SerializeField] MoveTarget target;

    public int Chance { get { return chance; } }
    public MoveTarget Target { get { return target; } }
}

[System.Serializable]
public class StatBoost
{
    public Stat stat;
    public int boost;
}

public enum MoveCategory
{
    Physical, Special, Status
}

public enum MoveTarget
{
    Foe, Self
}