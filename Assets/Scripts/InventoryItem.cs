using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour
{

    [HideInInspector] public Item item;
    [HideInInspector] public int count;

    [Header("UI")]
    public Image image;
    public Text countText;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        count = 1;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
}
