using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonShaking : MonoBehaviour
{
    public float shakeDuration = 20.0f;
    public float sinkDuration = 3.0f;
    public float shakeIntensity = 0.04f;
    public float shakeDistance = 6.0f;
    public float sinkDepth = 15.0f;

    private Transform player;
    private Vector3 currentPosition;
    private bool isShaking = false;
    private bool isSinking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isSinking)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < shakeDistance && !isShaking && !isSinking)
            {
                transform.LookAt(player);
                currentPosition = transform.position;
                PokemonBehavior pokemonBehavior = GetComponent<PokemonBehavior>();
                pokemonBehavior.speed = 0;
                StartShaking();
            }
        }
    }

    private void StartShaking()
    {
        isShaking = true;
        StartCoroutine(ShakeAndSink());
    }

    private IEnumerator ShakeAndSink()
    {
        Vector3 randomOffset = Vector3.zero;

        while (shakeDuration > 0)
        {
            randomOffset = Random.insideUnitSphere * shakeIntensity;
            transform.position = currentPosition + randomOffset;
            shakeDuration -= Time.deltaTime;
            yield return null;
        }

        isShaking = false;
        StartCoroutine(Sink());
    }

    private void StartSinking()
    {
        isSinking = true;
        StartCoroutine(Sink());
    }

    private IEnumerator Sink()
    {
        float startTime = Time.time;
        Vector3 targetPosition = currentPosition - new Vector3(0, sinkDepth, 0);

        while (Time.time - startTime < sinkDuration)
        {
            float progress = (Time.time - startTime) / sinkDuration;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, progress);
            yield return null;
        }

        Destroy(gameObject);
    }
}