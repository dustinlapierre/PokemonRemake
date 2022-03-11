using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pokemon> wildPokemon;

    public Pokemon GetRandomWildPokemon()
    {
        var encounter = wildPokemon[Random.Range(0, wildPokemon.Count)];
        encounter.Init();
        return encounter;

    }
}
