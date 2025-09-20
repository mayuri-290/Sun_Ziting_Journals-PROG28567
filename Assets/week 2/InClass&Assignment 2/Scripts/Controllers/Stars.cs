using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    int start = 0;
    int end = 1;
    float timer = 0;
    public List<Transform> starTransforms;
    public float drawingTime;
    
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        if (starTransforms.Count < 2 || drawingTime>0f)
        {
            Vector3 a = starTransforms[start].position;
            Vector3 b = starTransforms[end].position;

            timer += Time.deltaTime / drawingTime;
            float t = Mathf.Min(timer, 1f);

            Vector3 currentPos = Vector3.Lerp(a, b, t);
            Debug.DrawLine(a, currentPos, Color.white);

            if (t >= 1f)
            {
                start = (start + 1) % starTransforms.Count;
                end = (start + 1) % starTransforms.Count;
                timer = 0;
            }
        }
        
    }
}
