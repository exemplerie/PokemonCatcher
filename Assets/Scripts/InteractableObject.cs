using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemDescription;
    public Item requiredItem;

    public string GetItemDescription()
    {
        return ItemDescription;
    }

    public void Interact(Item item)
    {
        if (!requiredItem || (requiredItem && item == requiredItem))
        {
            PerformInteraction();
        }
    }

    protected virtual void PerformInteraction()
    {
        if (gameObject.tag == "Door")
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }
    }

}
