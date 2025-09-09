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
        if (Input.GetKeyDown(KeyCode.B))
        {
        SpawnBombAtOffset(new Vector3 (0,1));
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffSet)
    {
        Instantiate(bombPrefab, inOffSet, Quaternion.identity);
    }
}
