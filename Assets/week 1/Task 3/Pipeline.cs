using UnityEngine;
public class Pipeline : MonoBehaviour
{
    private float timer;
     Vector2 lastPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;

            if (timer > 0.1f)
            {
                Vector2 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.DrawLine(newPoint, lastPoint, Color.black, 1f);

                lastPoint = newPoint;
                timer = 0f;
            }
        }
    }
}
