using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IceShoot : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip iceballSound;

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

        if (distance <= sightRange)
        {
            ChasePlayer();
        }
        else
        {
            pokemonBehavior.isChasing = false;
        }

        if (distance <= attackRange)
        {
            if (Time.time - lastFireballTime >= fireballCooldown)
            {
                soundSource.PlayOneShot(iceballSound);
                ShootFireballsInMultipleDirections();
                lastFireballTime = Time.time;
            }
        }
    }

    private void ChasePlayer()
    {
        pokemonBehavior.isChasing = true;
        transform.LookAt(player);
    }

    void ShootFireballsInMultipleDirections()
    {
        for (int i = 0; i < 6; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, i * 60, 0);
            Vector3 direction = rotation * transform.forward;

            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            fireball.GetComponent<Rigidbody>().velocity = direction * fireballSpeed;

            Destroy(fireball, 2f);
        }
    }
}
