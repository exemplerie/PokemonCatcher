using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int health;
    CatcherController catcherController;
    List<ItemType> healthItems;
    public GameObject deathScreen;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip throwPokeballSound;
    [SerializeField] AudioClip eatSound;
    [SerializeField] AudioClip hurtSound;

    void Start()
    {
        health = 5;
        healthItems = new List<ItemType> { ItemType.Food, ItemType.Apple, ItemType.Cola, ItemType.Cupcake };
        catcherController = GetComponent<CatcherController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Item item = InventoryManager.instance.GetSelectedItem();
            if (item)
            {
                if (healthItems.Contains(item.type))
                {
                    soundSource.PlayOneShot(eatSound);
                    Heal();
                }
                if (item.type == ItemType.PokeballBasic || item.type == ItemType.PokeballPro)
                {
                    soundSource.PlayOneShot(throwPokeballSound);
                    catcherController.ThrowPokeball(item.type);
                }
                if (item.forQuest)
                {
                    SelectionManager selectionManager = gameObject.GetComponent<SelectionManager>();
                    selectionManager.UseInteractableItem(item);
                }
            }
        }

    }

    public void Hurt(int damage)
    {
        if (health > 0)
        {
            soundSource.PlayOneShot(hurtSound);
            health -= damage;
        }

        if (health <= 0)
        {
            PauseControl pauseControl = gameObject.GetComponent<PauseControl>();
            pauseControl.PauseGame();

            deathScreen.SetActive(true);

        }
    }

    public void Heal()
    {
        if (health < 5)
        {
            health++;
        }
    }
}