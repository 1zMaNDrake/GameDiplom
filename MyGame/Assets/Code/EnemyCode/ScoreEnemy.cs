using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnemy : MonoBehaviour
{
    [SerializeField] private int _killScore;

    private ScoreController _controller;

    private void Awake()
    {
        _controller = FindAnyObjectByType<ScoreController>();
    }

    public void AllocateScore()
    {
        _controller.AddScore(_killScore);
    }
}
