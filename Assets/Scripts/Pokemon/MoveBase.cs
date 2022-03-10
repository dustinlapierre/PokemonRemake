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
    [SerializeField] bool isSpecial;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    //props
    public string Description { get => description; }
    public string Name { get => name; }
    public PokemonType Type { get => type; }
    public bool IsSpecial { get => isSpecial; }
    public int Power { get => power; }
    public int Accuracy { get => accuracy; }
    public int PP { get => pp; }
}