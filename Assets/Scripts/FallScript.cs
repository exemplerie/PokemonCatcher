using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    void Start()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if (transform.position.y < 95.0f)
        {
            playerCharacter.Hurt(5);
        }
    }
}
