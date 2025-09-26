using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector3 enemyDirection = (playerTransform.position - transform.position).normalized;
        transform.position += enemyDirection * speed * Time.deltaTime;
    }
}
