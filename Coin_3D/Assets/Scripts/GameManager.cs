using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score; 
    public int Score {  get { return score; } set { score = value; } }

    private bool timerIsStop;
    public bool TimerIsStop { get { return timerIsStop; } set { timerIsStop = value; } }
    
    private float time;
    public float Time { get {return time; } set { time = value; } }

    private int killCount;
    public int KillCount { get { return killCount; } set { killCount = value; } }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

}
