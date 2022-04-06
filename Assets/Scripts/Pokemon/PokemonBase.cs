using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create New Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // base stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    //learnset
    [SerializeField] List<LearnableMove> learnset;

    //props
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite FrontSprite { get => frontSprite; }
    public Sprite BackSprite { get => backSprite; }
    public PokemonType Type1 { get => type1; }
    public PokemonType Type2 { get => type2; }
    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int SpAttack { get => spAttack; }
    public int SpDefense { get => spDefense; }
    public int Speed { get => speed; }
    public List<LearnableMove> Learnset { get => learnset; }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base { get => moveBase; }
    public int Level { get => level; }
}


public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}

public enum Stat
{
    Attack,
    Defense,
    SpAttack,
    SpDefense,
    Speed,
    Accuracy,
    Evasion
}

public class TypeChart
{
    static float[][] chart =
    {
        //                         NOR  FIR  WAT  ELE  GRA  ICE  FIG  POI
        /* NOR */ new float[]    { 1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f},
        /* FIR */ new float[]    { 1f, .5f, .5f,  1f,  2f,  2f,  1f,  1f},
        /* WAT */ new float[]    { 1f,  2f, .5f,  2f, .5f,  1f,  1f,  1f},
        /* ELE */ new float[]    { 1f,  1f,  2f, .5f, .5f,  2f,  1f,  1f},
        /* GRS */ new float[]    { 1f, .5f,  2f,  1f, .5f,  1f,  1f, .5f},
        /* POI */ new float[]    { 1f,  1f,  1f,  1f,  2f,  1f,  1f,  1f},
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1;

        // -1 because there is a None type at index 0 in the enum (array is 1 off)
        int row = (int) attackType - 1;
        int col = (int) defenseType - 1;

        return chart[row][col];
    }
}
