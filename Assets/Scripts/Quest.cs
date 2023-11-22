using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest
{
    public PokemonType pokemonType;
    public string questDescription;
    public int targetAmount;
    private int currentProgress;

    public Quest(PokemonType type, int amount)
    {
        pokemonType = type;
        targetAmount = amount;
        currentProgress = 0;
    }

    public void CreateDescription()
    {
        questDescription = pokemonType.ToString() + " " + "Pokemon" + " " + currentProgress.ToString() + "/" + targetAmount.ToString();
    }

    public void UpdateProgress()
    {
        currentProgress++;
        questDescription = pokemonType.ToString() + " " + currentProgress.ToString() + "/" + targetAmount.ToString();
    }

    public bool IsCompleted()
    {
        return currentProgress >= targetAmount;
    }
}
