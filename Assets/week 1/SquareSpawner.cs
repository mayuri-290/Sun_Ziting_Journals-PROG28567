using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Vector2 start = new Vector2(0f, 1f);
                Vector2 end = new Vector2(0f, 0f);

                start = new Vector2(0f, 0f);
                end = new Vector2(1f, 0f);
                Debug.DrawLine(start, end, Color.white);

                start = new Vector2(1f, 0f);
                end = new Vector2(1f, 1f);
                Debug.DrawLine(start, end, Color.white);

                start = new Vector2(1f, 1f);
                end = new Vector2(0f, 1f);
                Debug.DrawLine(start, end, Color.white);
            }
        }
    }


}
