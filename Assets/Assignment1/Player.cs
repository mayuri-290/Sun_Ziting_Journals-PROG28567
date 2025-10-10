using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = transform.position;
        playerPos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = playerPos;

        if(playerPos.y > 4.5f)
        {
            playerPos.y = 4.5f;
        }
        if (playerPos.y < -4.5f)
        {
            playerPos.y = -4.5f;
        }
         transform.position = playerPos; 
    }
 }
