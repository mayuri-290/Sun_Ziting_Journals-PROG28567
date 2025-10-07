using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle, blueAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float redAngleInRadians = redAngle * Mathf.Deg2Rad;
        Vector3 redConvertedVector = new Vector3(Mathf.Cos(redAngleInRadians), Mathf.Sin(redAngleInRadians)) * 1f;

        float blueAngleInRadians = blueAngle * Mathf.Deg2Rad;
        Vector3 blueConvertedVector = new Vector3(Mathf.Cos(blueAngleInRadians), Mathf.Sin(blueAngleInRadians)) * 1f;

        Debug.DrawLine(Vector3.zero, redConvertedVector, Color.red, 3f);
        Debug.DrawLine(Vector3.zero, blueConvertedVector, Color.blue, 3f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //float redDotBlue = redConvertedVector.x * blueConvertedVector.x + redConvertedVector.y * blueConvertedVector.y;
            float redDotBlue = Vector3.Dot(redConvertedVector, blueConvertedVector);

            Debug.Log("redDotBlue: " + redDotBlue.ToString());
        }
    }
}
