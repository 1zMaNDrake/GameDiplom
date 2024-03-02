using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionUD : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPhysics.AngleY *= -1;
    }
}
