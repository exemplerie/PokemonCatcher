using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokeballType
{
    Basic,
    Pro
}


public class Pokeball: MonoBehaviour
{
    public PokeballType type;
    public bool used = false;
}
