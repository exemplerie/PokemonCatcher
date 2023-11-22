using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    [SerializeField] AudioClip pickingUpSound;
    [SerializeField] AudioSource soundSource;

    public int selectedSlot = 0;

    private void Awake()
    {
        ChangeSelectedSlot(selectedSlot);
        instance = this;
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            int newValue = selectedSlot + (int)(scroll / Mathf.Abs(scroll));
            if (newValue < 0)
            {
                newValue = inventorySlots.Length - 1;
            }
            else if (newValue >= inventorySlots.Length)
            {
                newValue = 0;
            }
            ChangeSelectedSlot(newValue);
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public void AddItem(Item item) {

        soundSource.PlayOneShot(pickingUpSound);

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return;
            }
        }


        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (!itemInSlot) {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem (Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (itemInSlot.item.spendable) {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                } else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }
}
