using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnderwaterController : MonoBehaviour
{
    public int maxAirCount = 8;
    public float airDecreaseInterval = 4f;
    public int airDecreaseAmount = 1;
    public float healthDecreaseInterval = 2.25f;
    public int healthDecreaseAmount = 1;

    public int currentAirCount;
    private float airDecreaseTimer;
    private float healthDecreaseTimer;

    public bool inAirZone;

    PlayerCharacter player;

    void Start()
    {
        currentAirCount = maxAirCount;
        airDecreaseTimer = airDecreaseInterval;
        healthDecreaseTimer = healthDecreaseInterval;
        player = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        airDecreaseTimer -= Time.deltaTime;
        if (airDecreaseTimer <= 0f)
        {
            airDecreaseTimer = airDecreaseInterval;
            if (!inAirZone && airDecreaseAmount > 0)
            {
                DecreaseAirCount(airDecreaseAmount);
            }
        }

        if (currentAirCount <= 0)
        {
            healthDecreaseTimer -= Time.deltaTime;
            if (healthDecreaseTimer <= 0f)
            {
                healthDecreaseTimer = healthDecreaseInterval;
                player.Hurt(1);
            }
        }
    }

    public void IncreaseAirCount(int amount)
    {
        if (currentAirCount < maxAirCount)
        {
            currentAirCount++;
        }
    }

    public void DecreaseAirCount(int amount)
    {
        currentAirCount--;

        if (currentAirCount == 0)
        {
            healthDecreaseTimer = healthDecreaseInterval;
        }
    }
}