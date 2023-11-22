using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildActivation : MonoBehaviour
{
    void Start()
    {
        DeactivateAllChildrenExceptRandom();
    }

    void DeactivateAllChildrenExceptRandom()
    {
        int childCount = transform.childCount;
        int randomChildIndex = Random.Range(0, childCount);

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(i == randomChildIndex);
        }
    }
}