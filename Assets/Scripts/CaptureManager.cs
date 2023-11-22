using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureManager : MonoBehaviour
{
    private List<Pokemon> caughtPokemon = new List<Pokemon>();

    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failureSound;
    [SerializeField] AudioSource soundSource;

    public void Capture(Pokemon pokemon, Pokeball pokeball)
    {
        float captureChance = GetCaptureChance(pokemon, pokeball);
        float randomValue = Random.value;

        if (randomValue < captureChance)
        {
            soundSource.PlayOneShot(successSound);
            AddPokemon(pokemon);
            Destroy(pokemon);
        } else
        {
            soundSource.PlayOneShot(failureSound);
        }
    }

    private float GetCaptureChance(Pokemon pokemon, Pokeball pokeball)
    {

        float captureProbability = GetPokemonProbability(pokemon) * GetPokeballProbability(pokeball);
        return captureProbability;
    }

    public float GetPokemonProbability(Pokemon pokemon)
    {
        float typeModifier = 1.0f;

        switch (pokemon.type)
        {
            case PokemonType.Normal:
                typeModifier = 1.0f;
                break;
            case PokemonType.Viking:
                typeModifier = 0.75f;
                break;
            case PokemonType.Seaweed:
                typeModifier = 0.6f;
                break;
            case PokemonType.Ice:
                typeModifier = 100.0f;
                break;
            case PokemonType.Water:
                typeModifier = 0.6f;
                break;
            case PokemonType.Snow:
                typeModifier = 100.0f;
                break;
            case PokemonType.Bunny:
                typeModifier = 0.4f;
                break;
            case PokemonType.Ghost:
                typeModifier = 0.2f;
                break;
            case PokemonType.Gold:
                typeModifier = 100.0f;
                break;
        }

        return typeModifier;
    }

    public float GetPokeballProbability(Pokeball pokeball)
    {
        float typeModifier = 1.0f;

        switch (pokeball.type)
        {
            case PokeballType.Basic:
                typeModifier = 0.7f;
                break;
            case PokeballType.Pro:
                typeModifier = 1.5f;
                break;
        }

        return typeModifier;
    }


    public void AddPokemon(Pokemon pokemon)
    {
        caughtPokemon.Add(pokemon);
        QuestManager.instance.UpdateQuestProgress(pokemon.type);
        Destroy(pokemon.gameObject);
    }
}
