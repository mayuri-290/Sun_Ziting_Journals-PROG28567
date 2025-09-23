using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    public float ratio;//set ratio to 1, it will not exceed 1. 

    public Vector3 velocity = new Vector3(0.5f, 0, 0);
    public float distaceToChange = 3f;
    public float duration = 1f;

    //private float speed = 5f;

    public float maxSpeed;
    public float accelerationTime;
    private float acceleration;
    //private float time = 0f;

    public float decelerationTime;
    public float deceleration;



    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //press B to spawn the bomb.
        {
            // SpawnBombAtOffset(new Vector3 (0,1));

            Vector2 offset = new Vector2(3f, 1f); //create an new offset.
            SpawnBombAtOffset(offset);
        }
        if (Input.GetKeyDown(KeyCode.T))//press T to spawn a series of bomb.
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);//activate the function here.
        }
        if (Input.GetKeyDown(KeyCode.M))//press M to spawn a series of bomb.
        {
            SpawnBombOnRandomCorner(2f);//activate the function here.
        }

        float speed = 0.5f;

        Vector2 targetPosition = enemyTransform.position;
        Vector2 startPosition = transform.position;
        Vector2 directionToMove = targetPosition - startPosition;

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position += (Vector3)directionToMove.normalized * speed;
        }

        if (Input.GetKeyDown(KeyCode.R))//click R to move the player. 
        {
            WarpPlayer(enemyTransform, ratio);
        }

        if (Input.GetKey(KeyCode.L))
        {
            DetectAsteroids(2.5f, asteroidTransforms);
        }

        PlayerMovement();
    }

    public void SpawnBombAtOffset(Vector2 inOffSet)
    {
        Vector2 spawnPosition = (Vector2)transform.position + inOffSet;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnBombTrail(float bombTrailSpacing, int numberOfTrailBombs)
    {
        for (int i = 0; i < numberOfTrailBombs; i++)// use for loop to instantiate a series of bombs. 
        {
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(0, -i * bombTrailSpacing - 1);//find the correct position to spawn bombs in Y axis. 
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        int randomPosition = Random.Range(0, 4);//randomly generate a number from 0 to 4.
        Vector3 spawnPosition = transform.position;//get the player's position.

        if (randomPosition == 0)
        {
            Vector3 offset = Vector3.up + Vector3.left;
            spawnPosition = spawnPosition + offset * inDistance;
        }
        if (randomPosition == 1)
        {
            Vector3 offset = Vector3.up + Vector3.right;
            spawnPosition = spawnPosition + offset * inDistance;
        }
        if (randomPosition == 2)
        {
            Vector3 offset = Vector3.down + Vector3.left;
            spawnPosition = spawnPosition + offset * inDistance;
        }
        if (randomPosition == 3)
        {
            Vector3 offset = Vector3.down + Vector3.right;
            spawnPosition = spawnPosition + offset * inDistance;
        }
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, ratio);//use lerp to calculate a start and end position for the player.
        transform.position = newPosition;//activate the movement of player. 
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            float playerDistance = Vector3.Distance(transform.position, asteroid.position);
            if (playerDistance <= inMaxRange)
            {
                Vector3 direction = (asteroid.position - transform.position).normalized;
                Debug.DrawLine(transform.position, transform.position + direction * 2.5f, Color.green, 2f);
            }
        }
    }

    public void PlayerMovement()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }
        direction = direction.normalized;

        if (direction.magnitude > 0f)
        {
            velocity += (Vector3)direction * acceleration * Time.deltaTime;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }
        }
        else
        {
            if (velocity.magnitude > 0f)
            {
                velocity -= velocity.normalized * deceleration * Time.deltaTime;
            }
        }
        transform.position += velocity * Time.deltaTime;

        //when I press the right key:
        //increase the direction to the right by the acceleration.

        //when I press the up key:
        //increase the direction to the up by the acceleration.

        //move the object usig some kind of acceleration logic,
        //The ONLY spot we change the position of the transform.

        //somewhere in your code, you will need to subtract the acceleration.
    }

}
