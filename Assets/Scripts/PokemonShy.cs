using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonShy : MonoBehaviour
{
    public float runSpeed = 3f;
    public float detectionRadius = 5f;

    private Transform player;
    private bool isRunning = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            isRunning = true;
            Vector3 direction = transform.position - player.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * runSpeed);
        }
        else
        {
            isRunning = false;
        }

        if (isRunning)
        {
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        }
    }
}
