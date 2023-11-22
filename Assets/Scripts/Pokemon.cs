using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType
{
    Normal,
    Viking,
    Seaweed,
    Ice,
    Snow,
    Water,
    Bunny,
    Ghost,
    Gold
}
 
public class Pokemon: MonoBehaviour
{
    public PokemonType type;
    public Sprite image;
}
