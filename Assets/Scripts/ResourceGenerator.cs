using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [Header("Spawn settings")]
    public GameObject resourcePrefab;
    public float spawnChance;

    [Header("Raycast setup")]
    public float distanceBetweenCheck;
    public float heightOfCheck = 400f, rangeOfCheck = 30f;
    public LayerMask layerMask;
    public Vector2 positivePosition, negativePosition;

    private void Start()
    {
        SpawnResources();
    }

    void SpawnResources()
    {
        for (float x = negativePosition.x; x < positivePosition.x; x += distanceBetweenCheck)
        {
            for (float z = negativePosition.y; z < positivePosition.y; z += distanceBetweenCheck)
            {
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(x, heightOfCheck, z), Vector3.down, out hit, rangeOfCheck, layerMask))
                {
                    if (Mathf.Abs(hit.point.x) < 0.01f || Mathf.Abs(hit.point.y) < 0.01f || Mathf.Abs(hit.point.x) < 0.01f)
                    {
                        continue;
                    }
                    if (spawnChance > Random.Range(0f, 101f))
                    {
                        Pokemon pokemon = resourcePrefab.GetComponent<Pokemon>();
                        if ((pokemon && pokemon.type == PokemonType.Bunny) || resourcePrefab.CompareTag("Air"))
                        {
                            Instantiate(resourcePrefab, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
                        }
                        else { 
                            Vector3 vector = new Vector3(0, 5, 0);
                            Instantiate(resourcePrefab, hit.point + vector, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
                        }
                    }
                }
            }
        }
    }
}