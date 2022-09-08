using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScene : MonoBehaviour
{
    [SerializeField] private QuizManager _quizManager;
    [SerializeField] private GameFlow _gameFlow;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        string code = CurrentSellectedLevel.Instance.GetPackCode();
        int lvl = CurrentSellectedLevel.Instance.GetLevel();

        QuizLevel quiz = QuizDatabase.Instance.GetQuizPack(code).GetQuizLevel(lvl);
        _gameFlow.SetCorrectAnswer(quiz.AnswerCorrect);


        _quizManager.SetQuiz(
            _gameFlow,
            quiz
            );

        _backButton.onClick.AddListener(() => SceneManager.LoadScene("Level"));
    }
}
