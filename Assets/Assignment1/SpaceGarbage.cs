using UnityEngine;

public class SpaceGarbage : MonoBehaviour
{
    public float minspeed = 1f;
    public float maxspeed = 4f;
    private float speed;
    public float rotationSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomPos = Random.Range(-5f, 5f);
        transform.position = new Vector3(16f,randomPos, 0f);
        speed = Random.Range(minspeed, maxspeed);
        rotationSpeed = Random.Range(-180f, 180f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (transform.position.x < -16f)
        {
            Destroy(gameObject);
        }
    }
}
