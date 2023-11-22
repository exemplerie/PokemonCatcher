using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PokemonWater : MonoBehaviour
{
    private Vector3 currentPosition;

    public float floatDuration = 200.0f;
    public float floatHeight = 300.0f;

    void OnCollisionEnter(Collision collision)
    {
        currentPosition = transform.position;

        Pokeball pokeball = collision.gameObject.GetComponent<Pokeball>();
        if ((pokeball != null && pokeball.used) || collision.gameObject.tag == "Player")
        {
            PokemonBehavior pokemonBehavior = GetComponent<PokemonBehavior>();
            pokemonBehavior.speed = 0;
            StartCoroutine(FloatOut());
        }
    }

    private IEnumerator FloatOut()
    {
        float startTime = Time.time;
        Vector3 targetPosition = currentPosition + new Vector3(0, floatHeight, 0);

        while (Time.time - startTime < floatDuration)
        {
            float progress = (Time.time - startTime) / floatDuration;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, progress);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
