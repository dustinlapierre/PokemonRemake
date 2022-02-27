using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base;
    int level;
    public int HP { get; set; }

    public List<Move> Moves { get; set; }


    public Pokemon(PokemonBase pBase, int plevel)
    {
        _base = pBase;
        level = plevel;
        HP = _base.MaxHP;

        //generate a level appropriate moveset
        Moves = new List<Move>();
        foreach(var move in _base.Learnset)
        {
            if (move.Level <= level)
                Moves.Add(new Move(move.Base));

            if (Moves.Count >= 4)
                break;
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((_base.SpDefense * level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10; }
    }
}