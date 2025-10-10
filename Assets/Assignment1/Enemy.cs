using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private float speed = 4f;
    public float angularSpeed;

    public float shootSpeed = 3f;
    public GameObject bulletPrefab;
    public float shootInterval = 1f;
    public float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        EnemyRotation();
        ShootBulletsToPlayer();
    }

    public void EnemyMovement()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, playerTransform.position.y, speed * Time.deltaTime);
        transform.position = pos;
    }

    public void EnemyRotation()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float currentAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.up.y, transform.up.x);
        float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(directionToPlayer.y, directionToPlayer.x);
        float angleRemaining = Mathf.DeltaAngle(currentAngle, targetAngle);

        float dotProduct = Vector3.Dot(transform.right, directionToPlayer);
        float changeInAngle;

        if (dotProduct > 0)
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

    public void ShootBulletsToPlayer()
    {
        time += Time.deltaTime;
        if (time >= shootInterval)
        {
            time = 0f;
            Vector3 directionToPlayer = (playerTransform.position - transform.position);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = directionToPlayer;
        }
    }
}