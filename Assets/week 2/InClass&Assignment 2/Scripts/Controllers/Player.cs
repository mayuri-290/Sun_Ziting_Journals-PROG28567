using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    public float ratio;//set ratio to 1, it will not exceed 1. 
    // List<int> randomPosition = new List<int>();



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

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += (Vector3)directionToMove.normalized * speed;
        }

        if (Input.GetKeyDown(KeyCode.S))//click s to move the player. 
        {
            WarpPlayer(enemyTransform, ratio);
        }
    }

    public void SpawnBombAtOffset(Vector2 inOffSet)
    {
        //Instantiate(bombPrefab, inOffSet, Quaternion.identity);

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
        //List<int> randomPosition = new List<int> { 1, 2, 3, 4 };

        if (randomPosition == 0)//if the chosen random number is 
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
        //randomPosition.Count = Random.Range(0, randomPosition.Count);
    }

    public void WarpPlayer(Transform target, float ratio)
    {

       // Vector3 startPosition = transform.position;//player's current position
       // Vector3 targetPosition = target.position;//enemies position, so the player will move towards it.

        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, ratio);//use lerp to calculate a start and end position for the player.
        transform.position = newPosition;//activate the movement of player. 

    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {

    }
}
