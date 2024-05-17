using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemyLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    private float AngleX;
    private float AngleY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Trajectory();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Trajectory()
    {
        AngleX = Random.value < 0.5f ? -1f : 1f;
        AngleY = Random.value < 0.5f ? -1f : 1f;
    }

    private void Movement()
    {
        Vector2 direction = new Vector2(AngleX, AngleY).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wallbasic"))
        {
            AngleY *= -1;
        }
        if (collision.gameObject.CompareTag("Wallliteral"))
        {
            AngleX *= -1;
        }
    }
}
