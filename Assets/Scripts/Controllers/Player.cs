using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    void Update()
    {
        float speed = 0.5f;

        Vector2 targetPosition = enemyTransform.position; 
        Vector2 startPosition = transform.position;
        Vector2 directionToMove = targetPosition - startPosition;

        if(Input.GetKeyDown(KeyCode.M))
        {
            transform.position += (Vector3)directionToMove.normalized * speed; //normalized makes the vector a unit vector. 
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            // SpawnBombAtOffset(new Vector3 (0,1));

            Vector2 offset = new Vector2(0f, 1f);
            SpawnBombAtOffset(offset);
        }
    }

    public void SpawnBombAtOffset(Vector2 inOffSet)
    {
        //Instantiate(bombPrefab, inOffSet, Quaternion.identity);
        
        Vector2 spawnPosition = (Vector2)transform.position + inOffSet;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
}
