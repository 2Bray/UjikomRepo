using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelTitle;
    [SerializeField] private TextMeshProUGUI _quizQuestion;
    [SerializeField] private Image _hint;
    [SerializeField] private AnswerButton _answerButtons;
    [SerializeField] private Transform _buttonParent;

    public void SetQuiz(GameFlow gameFlow, QuizLevel quiz)
    {
        _levelTitle.text = "Level : " +
            CurrentSellectedLevel.Instance.GetPackCode() +
            "_" +
            (CurrentSellectedLevel.Instance.GetLevel());

        _quizQuestion.text = quiz.Question;
        _hint.sprite = quiz.ImageHint;

        int[] randomIndex = new int[quiz.Answer.Length];
        int r = 0;

        for (int i = 0; i < quiz.Answer.Length; i++)
        {
            do
            {
                r = UnityEngine.Random.Range(0, randomIndex.Length);
            }
            while (randomIndex[r] < 0);
            randomIndex[r]--;

            AnswerButton _button = Instantiate(_answerButtons, _buttonParent);
            _button.SetInitButton(quiz.Answer[r], gameFlow.PlayerAnswer);
        }
    }
}
