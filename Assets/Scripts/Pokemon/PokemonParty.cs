using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemon;

    public List<Pokemon> Pokemon
    {
        get { return pokemon; }
    }

    private void Start()
    {
        foreach(var pokemon in pokemon)
        {
            pokemon.Init();
        }
    }

    public Pokemon GetHealthyPokemon()
    {
        return pokemon.Where(x => x.HP > 0).FirstOrDefault();
    }
}
