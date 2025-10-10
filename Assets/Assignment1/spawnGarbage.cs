using UnityEngine;

public class spawnGarbage : MonoBehaviour
{
    public GameObject SpaceGarbagePrefab;
    public float spawnInterval = 5f;
    public float timer = 0f;
    public int maxGarbage = 8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            float randomPos = Random.Range(-4f, 4f);
            Instantiate(SpaceGarbagePrefab, new Vector3(14f,randomPos,0f), Quaternion.identity);
        }
        
    }
}
