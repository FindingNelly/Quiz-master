using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30;
    [SerializeField] float timeToNextQuestion = 10;
    float timerTime;
    public float fillFraction;
    [SerializeField] public bool isAnswringQuestion = false;

    private void Start()
    {
        timerTime = timeToCompleteQuestion;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        
        timerTime -= Time.deltaTime;
        
        if (isAnswringQuestion &&timerTime<=0)
        {            
           timerTime = timeToNextQuestion;
            isAnswringQuestion = false;
        }
        else if(!isAnswringQuestion&&timerTime<=0)
        {
           timerTime = timeToCompleteQuestion;
            isAnswringQuestion = true;
        }
        Debug.Log(timerTime);

        if (isAnswringQuestion)
        {
            fillFraction=timerTime/timeToCompleteQuestion;
        }
        else if (!isAnswringQuestion)
        {
            fillFraction = timerTime / timeToNextQuestion;
        }
        Debug.Log(fillFraction);
    }
    public void LoadNextQuestion()
    {
        
        timerTime = 0.1f;       
        
    }
}
