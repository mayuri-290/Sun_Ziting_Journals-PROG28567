using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    private float radius=3f;
    public float speed= 30f;
    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }
    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angle += speed * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians) * radius;
        float y = Mathf.Sin(radians) * radius;
        transform.position = target.position + new Vector3(x, y, 0f);
    }
}
