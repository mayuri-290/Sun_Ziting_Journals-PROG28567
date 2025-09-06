using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public Transform square;
    public float squareLength = 1f;
    public float scale = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        squareLength += Input.mouseScrollDelta.y * scale;
        square.localScale = new Vector2(squareLength *2, squareLength *2);

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, mousePosition.y);

        if (Input.GetMouseButtonDown(0))
        {
            {
                Vector2 start = new Vector2(-squareLength, squareLength) + mousePosition;
                Vector2 end = new Vector2(-squareLength, -squareLength) + mousePosition;
                Debug.DrawLine(start, end, Color.white, 2);

                start = new Vector2(-squareLength, -squareLength) + mousePosition;
                end = new Vector2(squareLength, -squareLength) + mousePosition;
                Debug.DrawLine(start, end, Color.white, 2);

                start = new Vector2(squareLength, -squareLength) + mousePosition;
                end = new Vector2(squareLength, squareLength) + mousePosition;
                Debug.DrawLine(start, end, Color.white, 2);

                start = new Vector2(squareLength, squareLength) + mousePosition;
                end = new Vector2(-squareLength, squareLength) + mousePosition;
                Debug.DrawLine(start, end, Color.white, 2);
            }
        }

        }
    


}
