using UnityEngine;
using System.Collections.Generic;

public class TrigExperiments : MonoBehaviour
{
    public List<float> angles = new List<float>();
    public float radius;
    public Vector3 circlePosition;
    private int currentAngleIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        float angleInDegrees = angles[currentAngleIndex];
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Sin(angleInRadians);

        Vector3 pointOnCircle = new Vector3(x, y, 0) * radius + circlePosition;

        Debug.DrawLine(circlePosition, pointOnCircle, Color.red);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentAngleIndex++;

            if(currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0;
            }
        }
    }
}
