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
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Image timerImage;

    int correctAsnwer;
    Image buttonImage;
    Button button;
    Timer timer;

    void Start()
    {
        timer=FindObjectOfType<Timer>();
        GetNextQuestion();
    }

   

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
    }

    public void GetNextQuestion()
    {
        
        ButtonState(true);
        SetDefultSprite();
        DesplayQuestion();
    }


    public void OnAnswerSelected(int index)
    {
        
        
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

        ButtonState(false);
        


    }

    private void DesplayQuestion()
    {
        
        questionText.text = question.GetQuestion();



        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }


    void ButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefultSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage= answerButtons[i].GetComponentInChildren<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
