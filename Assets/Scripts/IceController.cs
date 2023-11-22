using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public float slideForce = 5.0f;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody)
        {
            Vector3 slideDirection = collision.rigidbody.velocity.normalized;
            collision.rigidbody.AddForce(slideDirection * slideForce);
        }
    }
}
