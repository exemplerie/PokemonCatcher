using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Item food;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InventoryManager.instance.AddItem(food);
            Destroy(gameObject);
        }
    }
}
