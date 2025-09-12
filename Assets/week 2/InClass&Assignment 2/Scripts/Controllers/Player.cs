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
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(0, -i*bombTrailSpacing-1);//find the correct position to spawn bombs in Y axis. 
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

        }
    }
}
