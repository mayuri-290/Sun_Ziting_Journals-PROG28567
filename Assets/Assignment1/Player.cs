using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float boostSpeed = 10f;
    public float boostTime = 2f;
    private float currentSpeed;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = speed;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = transform.position;
        playerPos.y += Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        if(playerPos.y > 4.5f)
        {
            playerPos.y = 4.5f;
        }
        if (playerPos.y < -4.5f)
        {
            playerPos.y = -4.5f;
        }
        transform.position = playerPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = boostSpeed;
            timer = boostTime;
        }
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentSpeed = speed;
            }
        }
    }
 }
