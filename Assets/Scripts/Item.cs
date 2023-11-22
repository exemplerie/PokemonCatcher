using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite image;
    public bool spendable = true;
    public bool forQuest = false;
}

public enum ItemType
{
    PokeballBasic,
    PokeballPro,
    Potion,
    Food,
    Apple,
    Cola,
    IceCream,
    Cupcake,
    Key
}