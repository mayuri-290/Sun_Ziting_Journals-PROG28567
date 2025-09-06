using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class RowGeneration : MonoBehaviour
{
    public float squareLength = 1f;
    public TMP_InputField squareNumberInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnSquares()
    {
             int count = int.Parse(squareNumberInput.text);

            for (int i = 0; i < count; i++)
        {
            Vector2 squareSequence = new Vector2(i * (squareLength + 2), 0);

            Vector2 start = new Vector2(-squareLength, squareLength) + squareSequence;
            Vector2 end = new Vector2(-squareLength, -squareLength) + squareSequence;
            Debug.DrawLine(start, end, Color.white, 2);

            start = new Vector2(-squareLength, -squareLength) + squareSequence;
            end = new Vector2(squareLength, -squareLength) + squareSequence;
            Debug.DrawLine(start, end, Color.white, 2);

            start = new Vector2(squareLength, -squareLength) + squareSequence;
            end = new Vector2(squareLength, squareLength) + squareSequence;
            Debug.DrawLine(start, end, Color.white, 2);

            start = new Vector2(squareLength, squareLength) + squareSequence;
            end = new Vector2(-squareLength, squareLength) + squareSequence;
            Debug.DrawLine(start, end, Color.white, 2);
        }
    }
}
