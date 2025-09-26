using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = transform.position;
        playerPos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        playerPos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = playerPos;   }
}
