using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PokemonGhost : MonoBehaviour
{
    public LayerMask whatIsPlayer;

    private Transform player;
    public float sightRange = 15;
    private float lastCollisionTime;
    private float collisionCooldown = 1f;
    PokemonBehavior pokemonBehavior;
    PlayerCharacter playerCharacter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCharacter = player.GetComponent<PlayerCharacter>();
        pokemonBehavior = GetComponent<PokemonBehavior>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= sightRange) {
            ChasePlayer();
        } else {
            pokemonBehavior.isChasing = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time - lastCollisionTime >= collisionCooldown)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerCharacter.Hurt(1);
                lastCollisionTime = Time.time;
            }
        }
    }

    private void ChasePlayer()
    {
        pokemonBehavior.isChasing = true;
        transform.LookAt(player);
    }

}


