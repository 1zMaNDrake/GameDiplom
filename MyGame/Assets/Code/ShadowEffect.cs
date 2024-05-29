using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    public Vector2 offset = new Vector2(-1, -1);
    private SpriteRenderer sptriteRenderCaster;
    private SpriteRenderer spriteRenderShadow;

    private Transform transformCaster;
    private Transform transformShadow;

    public Material shadowMaterial;
    public Color shadowColor;

    private void Start()
    {
        transformCaster = transform;
        transformShadow = new GameObject().transform;
        transformShadow.parent = transformCaster;
        transformShadow.gameObject.name = "Shadow";
        transformShadow.localScale = new Vector3(1, 1, 0);
        transformShadow.localRotation = Quaternion.identity;

        sptriteRenderCaster = GetComponent<SpriteRenderer>();
        spriteRenderShadow = transformShadow.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderShadow.material = shadowMaterial;
        spriteRenderShadow.color = shadowColor;
        spriteRenderShadow.sortingLayerName = sptriteRenderCaster.sortingLayerName;
        spriteRenderShadow.sortingOrder = sptriteRenderCaster.sortingOrder - 2;
        
    }

    private void LateUpdate()
    {
        transformShadow.position = new Vector2(transformCaster.position.x + offset.x, transformCaster.position.y + offset.y);
        spriteRenderShadow.sprite = sptriteRenderCaster.sprite;
    }
}
