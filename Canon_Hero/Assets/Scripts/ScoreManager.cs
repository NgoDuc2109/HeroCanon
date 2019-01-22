using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private float currentScore;
    public float CurrentScore
    {
        get
        {
            return currentScore;
        }

        private set
        {
            currentScore = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int number)
    {
        CurrentScore += number;
    }
}
