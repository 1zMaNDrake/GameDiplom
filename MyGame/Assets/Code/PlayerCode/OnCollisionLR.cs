using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionLR : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPhysics.AngleX *= -1;
    }
}
