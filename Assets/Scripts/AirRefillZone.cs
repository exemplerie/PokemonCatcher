using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRefillZone : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;

    public int airRefillAmount = 1;
    public float refillInterval = 0.75f;

    private PlayerUnderwaterController playerController;
    private float refillTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            playerController = other.GetComponent<PlayerUnderwaterController>();
            playerController.inAirZone = true;
            if (playerController != null)
            {
                refillTimer = refillInterval;
                soundSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.inAirZone = false;
            playerController = null;
            soundSource.Stop();
        }
    }

    private void Update()
    {
        if (playerController != null)
        {
            refillTimer -= Time.deltaTime;
            if (refillTimer <= 0f)
            {
                playerController.IncreaseAirCount(airRefillAmount);
                refillTimer = refillInterval;
            }
        }
    }
}