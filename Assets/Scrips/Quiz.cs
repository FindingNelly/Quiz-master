using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAsnwer;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();


        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
        
    }

    void Update()
    {
        
    }


    public void OnAnswerSelected(int index)
    {
        Debug.Log("ll");
        Image buttonImage;
        correctAsnwer = question.GetCorrectAnswer();
        if (index == question.GetCorrectAnswer())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else if (index != question.GetCorrectAnswer())
        {
            questionText.text = "Sorry wrong answer\n The right answer is";
            buttonImage = answerButtons[correctAsnwer].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;


        }
            
    }
}
