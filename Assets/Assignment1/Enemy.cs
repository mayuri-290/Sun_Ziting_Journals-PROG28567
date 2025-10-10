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
    }

    public void EnemyMovement()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, playerTransform.position.y, speed * Time.deltaTime);
        transform.position = pos;
    }
}
