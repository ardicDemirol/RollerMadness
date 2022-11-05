using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
    [SerializeField] private float levelFinishTime = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time >= levelFinishTime && !gameOver)
        {
            print("5f den büyük");
            gameFinished = true;
        }
        if(gameOver == true)
        {

        }
    }
}
