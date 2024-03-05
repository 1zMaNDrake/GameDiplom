using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    private Material materialBlink;
    private Material materialDefault;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        materialBlink = Resources.Load("Blink", typeof(Material)) as Material;
        materialDefault = spriteRenderer.material;
    }

    // Update is called once per frame
    public void DamagedBlink(float delay)
    {
        spriteRenderer.material = materialBlink;
        Invoke("ResetMaterial", delay);
    }

    public void IgnoreCollision(float delay)
    {
        Invoke("DisableInteraction", 0);
        Invoke("EnableInteraction", delay);
    }

    private void ResetMaterial()
    {
        spriteRenderer.material = materialDefault;
    }

    public void EnableInteraction()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in taggedObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);

        }
    }
    public void DisableInteraction()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in taggedObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(),GetComponent<Collider2D>(), true);
        }
    }
}

