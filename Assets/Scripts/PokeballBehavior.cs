using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehavior : MonoBehaviour
{
    public Item itemPokeball;

    private void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Pokemon pokemon = collision.gameObject.GetComponent<Pokemon>();
        Pokeball usingPokeball = gameObject.GetComponent<Pokeball>();

        if (pokemon != null && usingPokeball.used)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            CaptureManager captureManager = player.GetComponent<CaptureManager>();

            Pokeball pokeball = GetComponent<Pokeball>();

            captureManager.Capture(pokemon, pokeball);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            if (!usingPokeball.used)
            {
                InventoryManager.instance.AddItem(itemPokeball);
                Destroy(gameObject);
            }
        }

    }
}
