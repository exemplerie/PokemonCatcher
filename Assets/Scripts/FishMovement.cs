using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float swimSpeed = 2.0f;
    public float minSwimDuration = 10.0f;
    public float maxSwimDuration = 20.0f;
    public float minHeightAboveTerrain = 20.0f;
    public Vector2 xzBounds = new Vector2(0.0f, 1000.0f);

    private float currentTerrainHeight;
    private Vector3 targetPosition;
    private float swimTimer;
    private Terrain terrain;

    public bool flag = false;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        transform.position = transform.position + new Vector3(0, 20, 0);
        SetNewTargetPosition();
    }

    void Update()
    {
        currentTerrainHeight = terrain.SampleHeight(transform.position);

        if (!flag && (transform.position.y - currentTerrainHeight) < minHeightAboveTerrain)
        {
            flag = true;
            targetPosition = targetPosition + new Vector3(0, 30, 0);
        }

        if (flag && (transform.position.y - currentTerrainHeight) < minHeightAboveTerrain) {
            flag = false;
        }

        swimTimer += Time.deltaTime;
        if (swimTimer >= Random.Range(minSwimDuration, maxSwimDuration))
        {
            SetNewTargetPosition();
            swimTimer = 0;
        }

        SwimToTarget();
    }

    void SetNewTargetPosition()
    {
        float x = Random.Range(xzBounds.x, xzBounds.y);
        float z = Random.Range(xzBounds.x, xzBounds.y);

        targetPosition = new Vector3(x, currentTerrainHeight + minHeightAboveTerrain + Random.Range(0f, 30f), z);
    }

    void SwimToTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        transform.Translate(Vector3.forward * swimSpeed * Time.deltaTime);
    }
}