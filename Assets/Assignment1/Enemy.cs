using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private float speed = 4f;
    public float angularSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        SpawnSpaceGarbage();

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);

        transform.Rotate(0f, 0f, angularSpeed * Time.deltaTime);

        Vector3 directionToTarget = playerTransform.position - transform.position;
        Debug.Log("Dot product: " + Vector3.Dot(transform.right, directionToTarget).ToString());


        float dotProduct = Vector3.Dot(transform.right, directionToTarget);

        float currentAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.up.y, transform.up.x);
        float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(directionToTarget.y, directionToTarget.x);

        float angleRemaining = Mathf.DeltaAngle(currentAngle, targetAngle);
        float changeInAngle;

        if (dotProduct > 0f)
        {
            changeInAngle = -angularSpeed * Time.deltaTime;

            if (changeInAngle < angleRemaining)
            {
                transform.Rotate(0f, 0f, angleRemaining);
            }
            else
            {
                transform.Rotate(0f, 0f, changeInAngle);
            }
        }
        else
        {
            changeInAngle = angularSpeed * Time.deltaTime;

            if (changeInAngle > angleRemaining)
            {
                transform.Rotate(0f, 0f, angleRemaining);
            }
            else
            {
                transform.Rotate(0f, 0f, changeInAngle);
            }
        }
    }

    public void EnemyMovement()
    {
        Vector3 enemyDirection = (playerTransform.position - transform.position).normalized;
        transform.position += enemyDirection * speed * Time.deltaTime;

    }

    public void SpawnSpaceGarbage()
    {

    }
}
