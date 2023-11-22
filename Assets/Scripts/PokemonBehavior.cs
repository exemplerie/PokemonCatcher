using Unity.VisualScripting;
using UnityEngine;

public class PokemonBehavior : MonoBehaviour
{
    public float speed = 0.4f;
    public float obstacleRange = 5.0f;
    public float rotationSpeed = 1.0f;
    public float sightRange = 100.0f;
    public bool isChasing;

    private Transform player;

    Animator animator;

    void Start()
    {
        isChasing = false;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= sightRange)
        {
            MyUpdate();
        }
    }

    private void MyUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        PerformObstacleCheck();
    }

    private void PerformObstacleCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (!isChasing && Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hit.distance < obstacleRange)
                {
                    RotateToClearPath();
                }
            
        }
    }

    private void RotateToClearPath()
    {
        float angle = -110;
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

        while (angle <= 110)
        {
            angle += rotationSpeed * Time.deltaTime;
            targetRotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit) && hit.distance >= obstacleRange)
                break;

        }
    }
}
