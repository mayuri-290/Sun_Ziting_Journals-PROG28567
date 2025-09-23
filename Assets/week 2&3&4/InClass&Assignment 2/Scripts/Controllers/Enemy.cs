using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private float speed = 2f;

    private void Update()
    {
    EnemyMovement();
    }
    public void EnemyMovement()
    {
    Vector3 enemyDirection = (playerTransform.position - transform.position).normalized;
    transform.position += enemyDirection * speed * Time.deltaTime;
    }
}
