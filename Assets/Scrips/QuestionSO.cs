using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string EnterQuestionHere = "";

    public string GetQuestion()
    {
        return EnterQuestionHere;
    }
    
    
}
