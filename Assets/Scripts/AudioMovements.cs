using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMovements : MonoBehaviour
{
    public float speed = 6.0f;
    public float sprintSpeed = 12.0f;

    [SerializeField] AudioSource walkingSoundSource;
    [SerializeField] AudioClip walkingSound;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        walkingSoundSource.clip = walkingSound;
    }

    void Update()
    {
 
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        float deltaX = Input.GetAxis("Horizontal") * currentSpeed;
        float deltaZ = Input.GetAxis("Vertical") * currentSpeed;
        float dt = Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, currentSpeed);

        if (currentSpeed > speed)
        {
            walkingSoundSource.pitch = 1.5f;
        }
        else
        {
            walkingSoundSource.pitch = 1.0f;
        }

        if (movement.magnitude > 0.1f && !walkingSoundSource.isPlaying)
        {
            walkingSoundSource.Play();
        }

        if (movement.magnitude <= 0.1f)
        {
            walkingSoundSource.Stop();
        }
    }
}
