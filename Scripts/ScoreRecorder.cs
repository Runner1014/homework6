using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    static ScoreRecorder instance;

    public int score; //总分

    // Use this for initialization  
    void Start()
    {
        score = 0;
    }

    private ScoreRecorder() { }
    public static ScoreRecorder getInstance()
    {
        if (instance == null)
        {
            instance = new ScoreRecorder();
        }
        return instance;
    }

    public void Record(GameObject disk)
    {
        score += 1;
    }

    public int getScore()
    {
        return score;
    }

    public void Reset()
    {
        score = 0;
    }
}