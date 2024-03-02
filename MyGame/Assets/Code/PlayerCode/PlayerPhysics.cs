using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float speed;
    public static float AngleX;
    public static float AngleY;

    void Start()
    {
        AngleX = 1f;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                AngleY = 1f;
        }
        if (Input.GetMouseButtonDown(1))
        {
                AngleY =  -1f;
        }

        transform.position += new Vector3(AngleX * speed * Time.deltaTime, AngleY * speed * Time.deltaTime, 0);
    }
}
