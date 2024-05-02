using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private bool closedLoop;
    [SerializeField] private GameObject sawPrefab;
    [SerializeField] private Vector2[] sawPoints;
    [SerializeField] private float sawSpeed;

    private GameObject sawBlade;
    private Rigidbody2D sawBladeRB;

    void Start()
    {
        CreateSawBlade();
        MoveSawBlade();
    }


    private void CreateSawBlade()
    {
        Vector2 startPos = new(sawPoints[0].x, sawPoints[0].y);
        sawBlade = Instantiate(sawPrefab, startPos, Quaternion.identity, this.transform) as GameObject;
        sawBladeRB = sawBlade.GetComponent<Rigidbody2D>();
    }

    private void MoveSawBlade()
    {
        Sequence s = DOTween.Sequence();
        if (closedLoop)
        {
            Vector2[] newArray = new Vector2[sawPoints.Length + 1];
            for (int i = 0; i < sawPoints.Length; i++)
            {
                newArray[i] = sawPoints[i];
            }
            newArray[^1] = sawPoints[0];
            s.Append(sawBladeRB.DOPath(newArray, sawSpeed, PathType.Linear).SetEase(Ease.Linear));
            s.SetLoops(-1, LoopType.Restart);
        }
        else
        {
            s.Append(sawBladeRB.DOPath(sawPoints, sawSpeed, PathType.Linear).SetEase(Ease.Linear));
            s.SetLoops(-1, LoopType.Yoyo);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < sawPoints.Length; i++)
        {
            Vector2 pos = new(sawPoints[i].x, sawPoints[i].y);
            Gizmos.DrawSphere(pos, 0.3f);
        }
    }
}