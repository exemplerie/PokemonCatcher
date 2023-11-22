using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PokemonAggressive : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip fireballSound;

    public GameObject fireballPrefab;
    public float fireballSpeed = 15f;
    public float fireballCooldown = 3f;

    public LayerMask whatIsPlayer;

    private Transform player;
    public float sightRange = 15, attackRange = 12;
    private float lastFireballTime;
    PokemonBehavior pokemonBehavior;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

        if (distance <= attackRange)
        {
            if (Time.time - lastFireballTime >= fireballCooldown)
            {
                soundSource.PlayOneShot(fireballSound);
                ShootFireball();
                lastFireballTime = Time.time;
            }
        }
    }

    private void ChasePlayer()
    {
        pokemonBehavior.isChasing = true;
        transform.LookAt(player);
    }

    void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        Vector3 direction = (player.position - transform.position).normalized;

        fireball.GetComponent<Rigidbody>().velocity = direction * fireballSpeed;

        Destroy(fireball, 2f);
    }
}


