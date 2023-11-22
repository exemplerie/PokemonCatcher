using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherController : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject pokeballBasicPrefab;
    public GameObject pokeballProPrefab;
    private GameObject pokeballPrefab;

    public float throwForce = 100.0f;
    public float throwUpwardForce = 0.0f;
    public float throwCooldown = 0.1f;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    public void ThrowPokeball(ItemType pokeballType)
    {
        if (!readyToThrow)
        {
            return;
        }

        readyToThrow = false;

        if (pokeballType == ItemType.PokeballBasic)
        {
            pokeballPrefab = pokeballBasicPrefab;
        } else
        {
            pokeballPrefab = pokeballProPrefab;
        }

        GameObject pokeball = Instantiate(pokeballPrefab, attackPoint.position, cam.rotation);

        Pokeball usingPokeball = pokeball.GetComponent<Pokeball>();

        usingPokeball.used = true;

        Rigidbody pokeballRigidbody = pokeball.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        pokeballRigidbody.AddForce(forceToAdd, ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwCooldown);

        Destroy(pokeball.gameObject, 3.0f);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}

