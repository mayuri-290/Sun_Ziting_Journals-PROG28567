using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float moveSpeed = 4f;
    public float arrivalDistance;
    float maxFloatDistance;

    Vector2 direction;
    Vector2 targetPt;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);
        targetPt = Camera.main.ScreenToWorldPoint(new Vector2(randomX, randomY));
        
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        maxFloatDistance = ((Vector3)targetPt - transform.position).magnitude;
        if (maxFloatDistance > arrivalDistance)
        {
            direction = (Vector3)targetPt - transform.position;

            transform.position += (Vector3)direction.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);
        targetPt = Camera.main.ScreenToWorldPoint(new Vector2(randomX, randomY));
        }

        
    }
}
