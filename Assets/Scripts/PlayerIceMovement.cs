using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIceMovement : MonoBehaviour
{
    public float slideSpeed = 1000f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 slideDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(slideDirection * slideSpeed);
    }
}
