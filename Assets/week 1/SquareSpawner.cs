using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    bool mouseClick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClick = true;

             Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            {
                Vector2 start = new Vector2(0f, 1f)+mouse;
                Vector2 end = new Vector2(0f, 0f)+mouse;      

                Debug.DrawLine(start, end, Color.white);

                start = new Vector2(0f, 0f)+mouse;
                end = new Vector2(1f, 0f)+mouse;            

                Debug.DrawLine(start, end, Color.white);

                start = new Vector2(1f, 0f)+mouse;
                end = new Vector2(1f, 1f)+mouse;

                Debug.DrawLine(start, end, Color.white);

                start = new Vector2(1f, 1f)+mouse;
                end = new Vector2(0f, 1f)+mouse;

                Debug.DrawLine(start, end, Color.white);
            }
        }
    }


}
