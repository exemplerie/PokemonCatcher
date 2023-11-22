using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AirUI : MonoBehaviour
{
    public PlayerUnderwaterController player;
    public int air = 8;
    public int numOfBubbles = 8;

    public Image[] bubbles;
    public Sprite fullBubble;
    public Sprite emptyBubble;

    void Start()
    {

    }

    void Update()
    {
        air = player.currentAirCount;

        for (int i = 0; i < bubbles.Length; i++)
        {
            if (i < air)
            {
                bubbles[i].sprite = fullBubble;
            }
            else
            {
                bubbles[i].sprite = emptyBubble;
            }

            if (i < numOfBubbles)
            {
                bubbles[i].enabled = true;
            }
            else
            {
                bubbles[i].enabled = false;
            }
        }
    }
}
