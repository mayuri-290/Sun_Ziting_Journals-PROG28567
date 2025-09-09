using UnityEngine;

public class MathFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 position = transform.position;

        float magnitude = Mathf.Sqrt(position.x * position.x + position.y * position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static float GetMagnitude(Vector2 position) //static method to get the magnitude of a vector, can call from other scripts.
    {
        return Mathf.Sqrt(position.x * position.x + position.y * position.y); //returns the magnitude of the vector
    }

    public static void DrawSquare(Vector2 position,float size,Color color, float duration)
    {
        Vector2 topLeftPoint = position + Vector2.up * size / 2f + Vector2.left * size / 2;
        Vector2 topRightPoint = position + Vector2.up * size / 2f + Vector2.right * size / 2;
        Vector2 bottomLeftPoint = position + Vector2.down * size / 2f + Vector2.left * size / 2;
        Vector2 bottomRightPoint = position + Vector2.down * size / 2f + Vector2.right * size / 2;

        Debug.DrawLine(topLeftPoint, topRightPoint, color, duration);
        Debug.DrawLine(topRightPoint, bottomRightPoint, color, duration);
        Debug.DrawLine(bottomRightPoint, bottomLeftPoint, color, duration);
        Debug.DrawLine(bottomLeftPoint, topLeftPoint, color, duration);


    }
}
