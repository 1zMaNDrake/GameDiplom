using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SetFontFilteringToPoint : MonoBehaviour
{
    [SerializeField] Font[] fonts;
    void Start()
    {
       for(int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}